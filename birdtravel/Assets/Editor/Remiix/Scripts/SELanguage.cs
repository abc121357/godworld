using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEditor;
using UnityEngine;

using ObfuscatorSeworksLib.Plugin.Utils;

namespace Remiix
{
	public class LanguageManager
	{
		public enum Language
		{
			Korea,
			English,
		}

		private static Language _curLanguage = (Language)SELanguage.Read ();

		public static int currentLanguage {
			get { return (int)_curLanguage; }
			set { _curLanguage = (Language)value; }

		}
	}

	internal class SELanguage : EditorWindow
	{
		const string LANGUAGE_FILE_PATH = "Assets/Editor/Remiix/Data/Language";

		[MenuItem ("Window/Remiix/Language/Korean", false)]
		static void Korea ()
		{
			LanguageManager.currentLanguage = 0;
			Write (0);
		}

		[MenuItem ("Window/Remiix/Language/English", false)]
		static void English ()
		{
			LanguageManager.currentLanguage = 1;
			Write (1);
		}

		public static void Write (int key)
		{
			using (StreamWriter sw = new StreamWriter (LANGUAGE_FILE_PATH)) {
				sw.Write (key.ToString ());
				sw.Close ();
			}
		}

		public static int Read ()
		{
			if (!File.Exists (LANGUAGE_FILE_PATH)) {
				Write (1);
			}
				
			using (StreamReader sr = new StreamReader (LANGUAGE_FILE_PATH)) {
				return Int32.Parse (sr.ReadToEnd ());
			}
		}
	}

}