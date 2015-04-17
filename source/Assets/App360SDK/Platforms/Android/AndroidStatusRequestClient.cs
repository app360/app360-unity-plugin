using System;
using App360SDK.Common;
using UnityEngine;
using App360SDK.Api;
using SimpleJSON;

namespace App360SDK.Android
{
	internal class AndroidStatusRequestClient : IStatusRequestClient
	{
		IStatusRequestListener _listener;
		
		public AndroidStatusRequestClient (IStatusRequestListener listener)
		{
			_listener = listener;
		}

		#region ICheckTransactionRequestClient implementation

		public void requestTransaction (string transactionId)
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("checkTransactionStatus", transactionId, new StatusRequestProxy (_listener));
		}

		#endregion
	}
}