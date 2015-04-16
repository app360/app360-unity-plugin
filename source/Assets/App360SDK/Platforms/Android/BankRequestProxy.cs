#if UNITY_ANDROID

using System;
using UnityEngine;
using App360SDK.Common;

namespace App360SDK.Android
{
	internal class BankRequestProxy : AndroidJavaProxy
	{

		private IBankRequestListener  listener;

		internal BankRequestProxy (IBankRequestListener _listener)
			: base(Utils.BANK_LISTENER_CLASSNAME)
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