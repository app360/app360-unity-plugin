#if UNITY_ANDROID
using System;
using App360SDK.Common;
using UnityEngine;
using App360SDK.Api;
using SimpleJSON;

namespace App360SDK.Android
{
	internal class AndroidBankRequestClient : IBankRequestClient
	{
		IBankRequestListener _listener;

		public AndroidBankRequestClient (IBankRequestListener listener)
		{
			_listener = listener;

		}

		#region IBankRequestClient implementation
		public void requestTransaction (int amount, string payload)
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("requestBankTransaction", amount, payload, new BankRequestProxy (_listener));
		}
		#endregion
	}
}
#endif