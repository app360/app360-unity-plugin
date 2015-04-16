#if UNITY_ANDROID

using System;
using App360SDK.Common;
using UnityEngine;
using App360SDK.Api;
using SimpleJSON;

namespace App360SDK.Android
{
	internal class AndroidSMSRequestClient : ISMSRequestClient
	{
		ISMSRequestListener _listener;

		public AndroidSMSRequestClient (ISMSRequestListener listener)
		{
			_listener = listener;

		}

		#region ISMSRequestClient implementation
		public void requestTransaction (string amount, string payload)
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("requestSMSTransaction", amount, payload, new SMSRequestProxy (_listener));
		}
		#endregion
	}
}

#endif