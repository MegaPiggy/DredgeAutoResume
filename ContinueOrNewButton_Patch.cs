using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Winch.Core;

namespace AutoResume.Patches
{
	[HarmonyPatch(typeof(ContinueOrNewButton), "Start")]
	public static class ContinueOrNewButton_Patch
	{
		public static bool didOnce = false;

		public static void Postfix(ContinueOrNewButton __instance)
		{
			var button = __instance.GetComponent<BasicButton>();
			var wrapper = __instance.GetComponent<BasicButtonWrapper>();
			if (!didOnce)
			{
				didOnce = true;
				__instance.StartCoroutine(__instance.WaitFrames(1, () => ClickContinueButton(button, wrapper)));
			}
		}

		private static void ClickContinueButton(BasicButton button, BasicButtonWrapper wrapper)
		{
			WinchCore.Log.Info("Auto resuming");
			wrapper.PlaySubmitSFX();
			button.onClick.Invoke();
			wrapper.OnClick.Invoke();
		}
	}
}
