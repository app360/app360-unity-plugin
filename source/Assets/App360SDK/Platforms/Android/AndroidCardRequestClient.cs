#if UNITY_ANDROID
using System;
using App360SDK.Common;
using UnityEngine;
using App360SDK.Api;
using SimpleJSON;

namespace App360SDK.Android
{
	internal class AndroidCardRequestClient : ICardRequestClient
	{
		ICardRequestListener _listener;

		public AndroidCardRequestClient (ICardRequestListener listener)
		{
			_listener = listener;
		}

		#region ICardRequestClient implementation
		public void requestTransaction (string vendor, string cardCode, string cardSerial, string payload)
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("requestCardTransaction", vendor, cardCode, cardSerial, payload, new CardRequestProxy (_listener));
		}
		#endregion




	}
}

#endif