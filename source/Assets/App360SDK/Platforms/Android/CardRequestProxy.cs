#if UNITY_ANDROID

using System;
using UnityEngine;
using App360SDK.Common;

namespace App360SDK.Android
{
	internal class CardRequestProxy : AndroidJavaProxy
	{
		private ICardRequestListener  listener;

		internal CardRequestProxy (ICardRequestListener _listener)
			: base(Utils.CARD_LISTENER_CLASSNAME)
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