#if UNITY_ANDROID

using System;
using UnityEngine;
using App360SDK.Common;

namespace App360SDK.Android
{
	internal class SMSRequestProxy :  AndroidJavaProxy
	{
		private ISMSRequestListener  listener;

		internal SMSRequestProxy (ISMSRequestListener _listener)
			: base(Utils.SMS_LISTENER_CLASSNAME)
		{
			this.listener = _listener;
		}
		
		void onSuccess (string transactionData)
		{
			listener.onSuccess (transactionData);
		}
		
		void onFailure (string message)
		{
			listener.onFailure (message);
		}
	}
}

#endif