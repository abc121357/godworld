using System;
using System.IO;
using System.Linq;

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using Debug = UnityEngine.Debug;
using ObfuscatorSeworksLib.Plugin;
using ObfuscatorSeworksLib.Plugin.Utils;

namespace Remiix
{
	internal class SESetting
	{
		static ScriptingImplementation backend;
		string assemblyPath;
		static int platformType = -1;

		public static void SetBuildTarget ()
		{
			BuildTarget[] standaloneLinux = {
				BuildTarget.StandaloneLinux,
				BuildTarget.StandaloneLinux64,
				BuildTarget.StandaloneLinuxUniversal
			};
			BuildTarget[] standaloneOSX = {
				BuildTarget.StandaloneOSXIntel, BuildTarget.StandaloneOSXIntel64, BuildTarget.StandaloneOSX
			};

			BuildTarget[] standaloneWindow = {
				BuildTarget.StandaloneWindows, BuildTarget.StandaloneWindows64
			};

			switch (EditorUserBuildSettings.activeBuildTarget) {
			case BuildTarget.Android:
				platformType = 0;
#if UNITY_5_5_OR_NEWER
				backend = UnityEditor.PlayerSettings.GetScriptingBackend (UnityEditor.BuildTargetGroup.Android);
#else
				backend = (UnityEditor.ScriptingImplementation)UnityEditor.PlayerSettings.GetPropertyInt ("ScriptingBackend", UnityEditor.BuildTargetGroup.Android);
#endif
				break;
			case BuildTarget.iOS:
				platformType = 1;
				break;
			case BuildTarget.WebGL:
				platformType = 2;
				break;
#if !UNITY_5_4_OR_NEWER
			case BuildTarget.WebPlayer:
				platformType = 3;
				break;
#endif
			default:
				if (standaloneOSX.Contains (EditorUserBuildSettings.activeBuildTarget)) {
					platformType = 4;

				} else if (standaloneWindow.Contains (EditorUserBuildSettings.activeBuildTarget)) {
					platformType = 5;
				} else if (standaloneLinux.Contains (EditorUserBuildSettings.activeBuildTarget)) {
					platformType = 6;
				} else {
					backend = UnityEditor.ScriptingImplementation.IL2CPP;
					break;
				}
#if UNITY_5_5_OR_NEWER
				backend = UnityEditor.PlayerSettings.GetScriptingBackend (UnityEditor.BuildTargetGroup.Standalone);
#else
				#if UNITY_5_2_NEWER
				backend = (UnityEditor.ScriptingImplementation)UnityEditor.PlayerSettings.GetPropertyInt ("ScriptingBackend", UnityEditor.BuildTargetGroup.Standalone);
				#else
				backend = UnityEditor.ScriptingImplementation.Mono2x;
				#endif

#endif
				break;
			}
		}

		public static bool IsMono {
			get { return backend == UnityEditor.ScriptingImplementation.Mono2x; }
			set { }
		}

		public static bool IsIL2CPP {
			get { return backend == UnityEditor.ScriptingImplementation.IL2CPP || platformType == 1 || platformType == 2 || platformType == 3; }
			set { }
		}

		bool IsWinEditor ()
		{
			return Application.platform == RuntimePlatform.WindowsEditor;
		}

		bool IsOSXEditor ()
		{
			return Application.platform == RuntimePlatform.OSXEditor;
		}
	}
}