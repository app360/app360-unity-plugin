#if UNITY_ANDROID
using System;
using App360SDK.Common;
using UnityEngine;
using App360SDK.Api;
using SimpleJSON;

namespace App360SDK.Android
{
	class StatusRequestProxy : AndroidJavaProxy
	{


		private IStatusRequestListener listener;
		internal StatusRequestProxy (IStatusRequestListener _listener):base(Utils.CHECK_TRANSACTION_LISTENER_CLASSNAME)

		{
			this.listener = _listener;
		}
		
		void onSuccess(string response) {
			listener.onSuccess (response);
		}
		
		void onFailure(string message) {
			listener.onFailure (message);
		}
	}

}
#endif