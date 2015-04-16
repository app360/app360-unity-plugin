using UnityEngine;
using System.Collections;

namespace App360SDK.Common
{
	internal interface IScopedUserListener
	{
		void onSuccess ();
		
		void onFailure (string error);
	}
}
