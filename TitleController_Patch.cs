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
		public static void Prefix(TitleController __instance)
		{
			var buttons = GameObject.Find("Canvases/MenuCanvas/ButtonContainer");
			var discord = buttons.GetComponentInChildren<DiscordButton>(true);
			GameObject.DestroyImmediate(discord.GetComponent<SKUSpecificDisabler>());
			discord.gameObject.SetActive(true);
		}
	}
}
