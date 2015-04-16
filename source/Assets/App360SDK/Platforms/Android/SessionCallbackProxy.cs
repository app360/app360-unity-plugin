#if UNITY_ANDROID

using System;
using UnityEngine;
using App360SDK.Common;
namespace App360SDK.Android
{
	public class SessionCallbackProxy : AndroidJavaProxy
	{
		private ISessionListener listener;
		internal SessionCallbackProxy (ISessionListener _listener)
			: base(Utils.SESSION_CALLBACK_CLASSNAME)
		{
			this.listener = _listener;
		}
		
		void onSuccess() {
			this.listener.onSuccess();
		}
		
		void onFailure(string message) {
			this.listener.onFailure (message);
		}
	}
}

#endif