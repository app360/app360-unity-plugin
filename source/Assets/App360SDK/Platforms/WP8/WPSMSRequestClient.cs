#if UNITY_WP8
using System;
using UnityEngine;
using System.Collections;
using App360SDK.Common;

namespace App360SDK.Platforms.WP8
{
	internal class WPSMSRequestClient : ISMSRequestClient
	{
		ISMSRequestListener listener;
		public WPSMSRequestClient (ISMSRequestListener listener)
		{
			this.listener =listener;
		}

		#region ISMSRequestClient implementation

		public void requestTransaction (string amount, string payload)
		{
			var sms = App360SDK.UnityWrapper.App360SDKWrapper.RequestSMSTransaction(amount , payload);
			if(sms.IsSuccess)
			{
				listener.onSuccess(sms.Message);
			}
			else
			{
				listener.onFailure(sms.Message);
			}
		}

		#endregion
	}
}
#endif
