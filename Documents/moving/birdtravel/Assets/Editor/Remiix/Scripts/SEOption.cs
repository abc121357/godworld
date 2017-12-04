using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using ObfuscatorSeworksLib.Plugin.Utils;

namespace Remiix {
	internal class WarningMsg {
		static string[] setting = {
			@"설정에 따라서 속도 및 용량에 영향을 줄 수 있습니다.",
			"Certain settings may affect the performance and size of your app."
		};
		static string[] dangerous = {
			@"해당 기능은 프로그램 작동에 큰 지장을 줄 수 있습니다.",
			"This option may affect the running of the app."
		};
		static string[] exception = {
			@"올바른 동작을 위해선 리플렉션 메소드에 대한 예외처리가 필요합니다.",
			"You must create an exception for the reflection method in order for this option to work correctly."
		};

		public static string SETTING {
			get { return setting [LanguageManager.currentLanguage]; }
		}

		public static string DANGEROUS {
			get { return dangerous [LanguageManager.currentLanguage]; }
		}

		public static string EXCEPTION {
			get { return exception [LanguageManager.currentLanguage]; }
		}
	}

	public class OAsset {
		const string targetFileName = @"Assembly-CSharp.dll";
		const string optionFilePath = @"Assets/Editor/Remiix/Data/Option";

		public static string TargetFileName {
			get { return targetFileName; }
		}

		public static string OptionFilePath {
			get { return optionFilePath; }
		}
	}

	public class SEOption : EditorWindow {
		int windowTab;
		bool flag = true;
		Vector2 scrollPosition;
		static bool block = true;
		bool obfuscatingFlag = true;
		[SerializeField]
		static PluginOption option;

		string[] functions = {
			"All",
			"Rename",
			"FakeMethod",
			"StringEncryption"
		};

		[MenuItem ("Window/Remiix/Obfuscator")]
		static void Init ()
		{
			option = LoadOption ();
				
			var window = GetWindow (typeof(SEOption), true, "Remiix");	
			window.minSize = new Vector2 (300, 310);
			window.maxSize = new Vector2 (400, 1000);
			window.Show ();
		}

		void Space (int i = 1)
		{
			for (int j = 0; j < i; j++)
				EditorGUILayout.Space ();
		}

		void OnGUI ()
		{	
			string[] OBFUSCATOR_BUTTON_DEFAULT = { "기본값", "Set Default" };
			string[] OBFUSCATOR_BUTTON_BUILD = { "빌드", "Build Settigns" };
			string[] OBFUSCATOR_BUTTON_SAVE = { "저장", "Save" };

			windowTab = GUILayout.Toolbar (windowTab, new string[] {
				"Option",
				"Detail",
				"Advanced"
			});

			//scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (position.width), GUILayout.Height (410));

			switch (windowTab) {
			case 0: // First tab
				EditorGUILayout.Space ();
				GUILayout.Label ("Global Options", EditorStyles.boldLabel);

				/* toggle */
				EditorGUI.BeginDisabledGroup (!block);
				try {
					option.EnableObfuscation = EditorGUILayout.Toggle ("Enable", option.EnableObfuscation);
				} catch {
					string[] MSG = {
						@"난독화 옵션 창을 다시 열어주세요.",
						"Please reopen the Protection Option window."
					};
					Debug.Log (MSG [LanguageManager.currentLanguage]);
					this.Close ();
					return;
				}
				EditorGUI.EndDisabledGroup ();

				EditorGUI.BeginDisabledGroup (!option.EnableObfuscation);
				EditorGUILayout.Space ();
				GUILayout.Label ("Features", EditorStyles.boldLabel);
				EditorGUILayout.Space ();

				option.RunRenaming = EditorGUILayout.Toggle ("Renaming", option.RunRenaming); 
				EditorGUILayout.Space ();

				option.RunFakeCode = EditorGUILayout.Toggle ("Fake Method", option.RunFakeCode);
				EditorGUILayout.Space ();

				option.RunStringEncryption = EditorGUILayout.Toggle ("String Encryption", option.RunStringEncryption); 
				EditorGUILayout.Space ();
				EditorGUI.EndDisabledGroup ();
				Space (4);
				if (GUILayout.Button (OBFUSCATOR_BUTTON_DEFAULT [LanguageManager.currentLanguage], GUILayout.Height (20))) {
					option.RunRenaming = true;
					option.RunFakeCode = true;
					option.RunStringEncryption = true;
					option.Renaming.Class = true;
					option.Renaming.Event = true;
					option.Renaming.Field = true;
					option.Renaming.Method = false;
					option.Renaming.Property = true;

					option.NumMangler = true;
					option.maxRenameLength = 32;
				}

				Space ();
				if (GUILayout.Button (OBFUSCATOR_BUTTON_BUILD [LanguageManager.currentLanguage], GUILayout.Height (20))) {
					EditorWindow.GetWindow (System.Type.GetType ("UnityEditor.BuildPlayerWindow,UnityEditor"), true, "Build Settings");
				}

				Space ();
				if (GUILayout.Button (OBFUSCATOR_BUTTON_SAVE [LanguageManager.currentLanguage], GUILayout.Height (23))) {
					SaveOption (option);
					this.Close ();
				}
				break;

			case 1: // Second Tab
				EditorGUILayout.Space ();

				/* Renaming */
				GUILayout.Label ("Renaming", EditorStyles.boldLabel);
				try {
					EditorGUI.BeginDisabledGroup (!option.RunRenaming || !option.EnableObfuscation);
				} catch {
					string[] MSG = {
						@"난독화 옵션 창을 다시 열어주세요.",
						"Please reopen the Protection Option window."
					};
					Debug.Log (MSG [LanguageManager.currentLanguage]);
					this.Close ();
					return;
				}

				option.Renaming.Class = EditorGUILayout.Toggle ("Class", option.Renaming.Class); 
				option.Renaming.Field = EditorGUILayout.Toggle ("Field", option.Renaming.Field); 
				option.Renaming.Event = EditorGUILayout.Toggle ("Event", option.Renaming.Event);
				option.Renaming.Property = EditorGUILayout.Toggle ("Property", option.Renaming.Property);
				EditorGUILayout.Space ();
				option.maxRenameLength = EditorGUILayout.IntSlider ("Rename Max Length", option.maxRenameLength, 16, 256);
				var rests = option.maxRenameLength % 16;
				if (rests > 16)
					option.maxRenameLength += rests;
				else
					option.maxRenameLength -= rests;
				EditorGUI.EndDisabledGroup ();
				EditorGUILayout.Space ();
				EditorGUILayout.Space ();

				/* Control Flow Obfuscation */

				/* Another */
				EditorGUILayout.HelpBox (WarningMsg.SETTING, MessageType.Warning);

				break;

			case 2:
				EditorGUILayout.Space ();
			
                /* Advanced */
				GUILayout.Label ("Advanced", EditorStyles.boldLabel);
				try {
					EditorGUI.BeginDisabledGroup (!option.RunRenaming || !option.EnableObfuscation);
				} catch {
					string[] MSG = {
						@"난독화 옵션 창을 다시 열어주세요.",
						"Please reopen the Protection Option window."
					};
					Debug.Log (MSG [LanguageManager.currentLanguage]);
					this.Close ();
					return;
				}
				option.Renaming.Method = EditorGUILayout.Toggle ("Method Renaming", option.Renaming.Method);
				if (flag && option.Renaming.Method) {
					string[] MSG = {
						@"메소드 리네이밍은 작동에 지장을 줄 수 있습니다.",
						"Method renaming may affect app performance or behavior."
					};
					Debug.LogWarning (MSG [LanguageManager.currentLanguage]);

					flag = false;
				} 
                
				EditorGUILayout.Space ();
				EditorGUILayout.HelpBox (WarningMsg.DANGEROUS, MessageType.Warning);
				EditorGUI.EndDisabledGroup ();
				EditorGUILayout.Space ();
			
				/* Exception */

				EditorGUILayout.Space ();
				obfuscatingFlag = EditorGUILayout.Foldout (obfuscatingFlag, "Exception");
				if (obfuscatingFlag) {
					foreach (var function in functions) {
						EditorGUILayout.TextField (function, string.Format ("[Skip{0}]", function));
					}
				}
				EditorGUILayout.Space ();
				EditorGUILayout.HelpBox (WarningMsg.EXCEPTION, MessageType.Warning);
				break;
			}

			SaveOption (option);
			//GUILayout.EndScrollView ();

		}

		static public PluginOption LoadOption ()
		{
			if (File.Exists (OAsset.OptionFilePath)) {
				var OptionData = new PluginOption ();
				var bin = new BinaryFormatter ();

				using (Stream stream = File.Open (OAsset.OptionFilePath, FileMode.Open)) {
					OptionData = (PluginOption)bin.Deserialize (stream);
				}
				return OptionData; 
			}

			return new PluginOption ();
		}

		static public void SaveOption (PluginOption OptionData)
		{
			var formatter = new BinaryFormatter ();
			using (FileStream stream = File.OpenWrite (OAsset.OptionFilePath)) {
				formatter.Serialize (stream, OptionData);
			}
		}
	}
}

