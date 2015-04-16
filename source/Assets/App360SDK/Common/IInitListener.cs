using UnityEngine;
using System.Collections;

namespace App360SDK.Common
{
	internal interface IInitListener
	{
		void onSuccess ();

		void onFailure (string error);
	}
}