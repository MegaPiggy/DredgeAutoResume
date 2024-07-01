using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Winch.Core;

namespace AutoResume.Patches
{
	[HarmonyPatch(typeof(TitleController), "Awake")]
	public static class TitleController_Patch
	{
		public static bool didOnce = false;

		public static void Prefix(TitleController __instance)
		{
			var buttons = GameObject.Find("Canvases/MenuCanvas/ButtonContainer");
			var continueNew = buttons.GetComponentInChildren<ContinueOrNewButton>(true);
			var button = continueNew.GetComponent<BasicButton>();
			var wrapper = continueNew.GetComponent<BasicButtonWrapper>();
			if (!didOnce)
			{
				didOnce = true;
				continueNew.StartCoroutine(continueNew.WaitFrames(1, () =>
				{
					WinchCore.Log.Info("Auto resuming");
					wrapper.PlaySubmitSFX();
					button.onClick.Invoke();
					wrapper.OnClick.Invoke();
				}));
			}
			var discord = buttons.GetComponentInChildren<DiscordButton>(true);
			GameObject.DestroyImmediate(discord.GetComponent<SKUSpecificDisabler>());
			discord.gameObject.SetActive(true);
		}
	}
}
