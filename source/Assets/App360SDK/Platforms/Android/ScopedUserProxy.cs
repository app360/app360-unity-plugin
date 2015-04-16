#if UNITY_ANDROID

using System;
using UnityEngine;
using App360SDK.Common;

namespace App360SDK.Android
{
	internal class ScopedUserProxy: AndroidJavaProxy
	{
		IScopedUserListener listener;

		public ScopedUserProxy (IScopedUserListener _listener)
			: base(Utils.SCOPED_USER_WRAPPER_CLASSNAME)
		{
			this.listener = _listener;
		}
		
		void OnSuccess ()
		{
			listener.onSuccess ();
		}
		
		void onFailure (string message)
		{
			listener.onFailure (message);
		}
	}
}

#endif