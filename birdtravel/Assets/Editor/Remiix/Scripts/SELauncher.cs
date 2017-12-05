using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using Mono.Cecil.Seworks;
using Debug = UnityEngine.Debug;
using ObfuscatorSeworksLib.Plugin;
using ObfuscatorSeworksLib.Plugin.Utils;

namespace Remiix {
	internal static class SELauncher {
		static bool restart = false;
		static bool success = false;
		static bool startObfuscating = false;
		static int buildCount = 0;

		[PostProcessBuild (1)]
		public static void Check (UnityEditor.BuildTarget target, String str)
		{
			string[] SUCCESS_LOG = {
				@"난독화가 정상적으로 수행됐습니다.", 
				"Protection complete."
			};
			string[] FAIL_LOG = {
				@"난독화 중 에러가 발생했습니다.", 
				"An error occurred during the protection process."
			};
			if (startObfuscating) {
				if (success) {
					Debug.Log (SUCCESS_LOG [LanguageManager.currentLanguage]);
				} else {
					Debug.LogError (FAIL_LOG [LanguageManager.currentLanguage]);
				}
			}
		}


		public static IEnumerable<string> GetFiles(string root, string searchPattern)
	    {
	        Stack<string> pending = new Stack<string>();
	        pending.Push(root);
	        while (pending.Count != 0)
	        {
	            var path = pending.Pop();
	            string[] next = null;
	            try
	            {
	                next = Directory.GetFiles(path, searchPattern);                    
	            }
	            catch { }
	            if(next != null && next.Length != 0)
	                foreach (var file in next) yield return file;
	            try
	            {
	                next = Directory.GetDirectories(path);
	                foreach (var subdir in next) pending.Push(subdir);
	            }
	            catch { }
	        }
	    }

		[PostProcessScene (1)]
		public static void Obfuscate ()
		{
			string targetDLL = "Assembly-CSharp.dll";
			string targetDLLPath = FindDllLocation (targetDLL);
			startObfuscating = false;

			if (targetDLLPath == null) {
				Debug.LogError (String.Format ("Can't found {0} in this project", targetDLL));
				return;
			} else if (Application.isPlaying) {
				string[] NOTICE_LOG = {
					@"플레이모드에서는 난독화 서비스를 지원하지 않습니다.", 
					"Obfuscator is only supported when build project not playmode."
				};

				Debug.Log (NOTICE_LOG [LanguageManager.currentLanguage]);
				return;
			} 
            
			var option = SEOption.LoadOption ();
			SESetting.SetBuildTarget ();
			if (SESetting.IsIL2CPP) {
				option.SupportIL2CPP = true;
			} else {
				option.SupportIL2CPP = false;
			}

			EditorApplication.LockReloadAssemblies ();
			if (!restart) {
				restart = true;

				if (option.EnableObfuscation) {
					startObfuscating = true;

					var getFiles = GetFiles(EditorApplication.applicationContentsPath, "UnityEngine.dll");
					var library = new List<String> ();
					foreach (var file in getFiles) {
						if (!library.Contains (file)) {
							library.Add (Path.GetDirectoryName(file));
						}
					}

					getFiles = GetFiles(Path.GetDirectoryName(Application.dataPath), "Assembly-CSharp.dll");
					foreach (var file in getFiles) {
						if (!library.Contains (file)) {
							library.Add (Path.GetDirectoryName(file));
						}
					}

					option.LibraryDirs = library;
					SEOption.SaveOption (option);
					
					Obfuscator.SetPluginOption (option);
					try{
						string result = Obfuscator.Obfuscate (targetDLLPath);
						if (result != null) {
							if (result.StartsWith ("== Obfuscated Result ==")) {
								foreach (string log in result.Split('\n')) {
									Debug.Log (log);
								}
								success = true;
							} else {
								Debug.LogError (String.Format ("Obfuscation Fail : '{0}'", result));
							}
						}
					} catch (AssemblyResolutionException E){
						buildCount++;

						if (buildCount > 2) {
							Debug.LogError (String.Format ("Build Fail : '{0}'", E));
							Debug.LogError ("Please report via email with logs.");	
						}

						string[] BUILD_ERROR = {
							@"원본빌드가 정상적으로 완료된 후 다시 시도해주세요.", 
							"Please try again after your program building successful."
						};

						Debug.Log (BUILD_ERROR [LanguageManager.currentLanguage]);
					}
				}
			}

			EditorApplication.UnlockReloadAssemblies ();
		}

		public static string FindDllLocation (string suffix, string key = null)
		{
			foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
				if (assembly.Location.EndsWith (suffix, StringComparison.Ordinal)) {
					if (key != null && !assembly.Location.Contains (key))
						continue;

					return assembly.Location;
				}
			}

			return null;
		}
	}
}
