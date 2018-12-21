/****************************************************************************
 * 2018.12 liangxie
 * 
 * 教程地址:http://www.sikiedu.com/course/327
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace IndieGame
{
	public class UIGameOverPanelData : UIPanelData
	{
		public int DeathCountCurrent = 10;
	}

	public partial class UIGameOverPanel : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UIGameOverPanelData ?? new UIGameOverPanelData();
			//please add init code here

			GameData.DeathCountMin = GameData.DeathCountMin >= mData.DeathCountCurrent ? mData.DeathCountCurrent : GameData.DeathCountMin;

			DeathCountCurrent.text = string.Format ("Death Count : {0}", mData.DeathCountCurrent);
			DeathCountMin.text = string.Format ("Death Count Record : {0}", GameData.DeathCountMin);
		}

		protected override void ProcessMsg (int eventId,QMsg msg)
		{
			throw new System.NotImplementedException ();
		}

		protected override void RegisterUIEvent()
		{
			BtnHome.onClick.AddListener (() =>
			{
				SendMsg(new AudioSoundMsg("Click"));
				CloseSelf();
				UIMgr.OpenPanel<UIHomePanel>();
			});
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnClose()
		{
			base.OnClose();
		}

		void ShowLog(string content)
		{
			Debug.Log("[ UIGameOverPanel:]" + content);
		}
	}
}