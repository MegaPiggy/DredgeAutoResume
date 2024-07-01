using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AutoResume
{
	public static class Extensions
	{
		public static GameObject FindChildWithExactName(this GameObject parent, string name)
		{
			var parentTransform = parent.transform;
			for (int i = parentTransform.childCount - 1; i >= 0; i--)
			{
				var childTransform = parentTransform.GetChild(i);
				if (childTransform.name == name)
					return childTransform.gameObject;
			}
			return null;
		}

		public static IEnumerator WaitFrames(this MonoBehaviour component, int n, Action action)
		{
			for (int i = 0; i < n; i++)
			{
				yield return new WaitForEndOfFrame();
			}
			action();
			yield break;
		}
	}
}
