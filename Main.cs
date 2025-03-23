using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Winch.Core;

namespace AutoResume
{
	public static class Main
	{
		public static void Initialize()
		{
			WinchCore.Log.Warn("Auto Resume Initialized");
			new Harmony("megapiggy.autoresume").PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}
