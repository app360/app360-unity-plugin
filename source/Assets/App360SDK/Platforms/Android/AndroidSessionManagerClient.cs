#if UNITY_ANDROID

using System;
using App360SDK.Common;
using UnityEngine;

namespace App360SDK.Android
{
	internal class AndroidSessionManagerClient: ISessionManagerClient
	{
		ISessionListener _listener;

		public AndroidSessionManagerClient (ISessionListener listener)
		{
			_listener = listener;
		}

		#region ISessionManagerClient implementation

		public void createSession (string scopedId)
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("createSession", scopedId, new SessionCallbackProxy (_listener));
		}

		public void createSessionWithService (string service, string token)
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("createSession", service, token, new SessionCallbackProxy (_listener));
		}

		#endregion
	}
}

#endif