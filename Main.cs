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
			new Harmony("megapiggy.autoresume").PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}
