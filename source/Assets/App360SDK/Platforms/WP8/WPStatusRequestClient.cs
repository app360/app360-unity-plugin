#if UNITY_WP8
using System;
using UnityEngine;
using System.Collections;
using App360SDK.Common;
namespace App360SDK.Platforms.WP8
{
	internal class WPStatusRequestClient : IStatusRequestClient
	{
		IStatusRequestListener listener;

		public WPStatusRequestClient (IStatusRequestListener listener)
		{
			this.listener=listener;
		}

		#region IStatusRequestClient implementation

		public void requestTransaction (string transactionId)
		{
			var status = App360SDK.UnityWrapper.App360SDKWrapper.StatusRequest(transactionId);
			if(status.IsSuccess)
			{
				listener.onSuccess(status.Message);
			}
			else
			{
				listener.onFailure(status.Message);
			}
		}

		#endregion
	}
}

#endif