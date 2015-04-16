using UnityEngine;
using System.Collections;

namespace App360SDK.Common
{
	internal interface ISessionListener
	{
		void onSuccess ();

		void onFailure (string error);
	}
}
