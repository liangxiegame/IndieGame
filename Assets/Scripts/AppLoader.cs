using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace IndieGame
{
	public class AppLoader : MonoBehaviour 
	{
		void Awake()
		{
			ResMgr.Init ();

			UIMgr.SetResolution (1024, 768, 1.0f);

			DontDestroyOnLoad (UIManager.Instance);
		}

		void Start () 
		{
			UIMgr.OpenPanel<UIHomePanel> ();
		}
	}


	public class GameData
	{
		public static int DeathCountMin
		{
			get
			{
				return PlayerPrefs.GetInt ("DEATH_COUNT_MIN", int.MaxValue);
			}
			set
			{
				PlayerPrefs.SetInt ("DEATH_COUNT_MIN", value);
			}
		}


		public static bool FirstTimeEnterLevel1 {

			get
			{
				return PlayerPrefs.GetInt ("FIRST_TIME_ENTER_LEVEL_1", 1) == 1 ? true : false;
			}
			set
			{
				PlayerPrefs.SetInt ("FIRST_TIME_ENTER_LEVEL_1", value ? 1 : 0);
			}
		}

		public static string CurLevelName
		{
			get { return PlayerPrefs.GetString("CUR_LEVEL_NAME", "Level1"); }
			set { PlayerPrefs.SetString("CUR_LEVEL_NAME", value); }
		}
	}


	public class LevelConfig
	{
		static List<string> mLevelNamesOrder = new List<string>()
		{
			"Level1",
			"Level2",
			"Level3",
			"Level4",
			"Level5",
			"Level6",
			"Level7",
			"Level8",
			"Level9",
			"Level10",
			"Level11",
			"Level12",
			"Level13",
			"Level14",
			"Level15",
			"Level16",
			"Level17",
			"Level18",
			"Level19",
			"Level20",
			"Level21",
			"Level22",
			"Level23",
			"Level24",
			"GameWin",
		};

		public static List<string> LevelNamesOrder
		{
			get { return mLevelNamesOrder; }
		}

		public static int CurrentLevelIndex(string curLevelName)
		{
			var curLevelIndex = mLevelNamesOrder.IndexOf(curLevelName);

			return curLevelIndex;
		}

		public static string GetNextLevelName()
		{
			var curLevelIndex = CurrentLevelIndex(SceneManager.GetActiveScene().name);
			
			curLevelIndex++;
			var nextLevelName = mLevelNamesOrder[curLevelIndex];

			if (curLevelIndex == mLevelNamesOrder.Count - 1)
			{
				GameData.CurLevelName = "Level1";
			}
			else
			{
				GameData.CurLevelName = nextLevelName;
			}

			return nextLevelName;
		}
	}
}