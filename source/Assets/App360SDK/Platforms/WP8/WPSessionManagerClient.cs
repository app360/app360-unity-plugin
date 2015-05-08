#if UNITY_WP8
using System;
using UnityEngine;
using System.Collections;
using App360SDK.Common;

namespace App360SDK.Platforms.WP8
{
	internal class WPSessionManagerClient : ISessionManagerClient
	{
		ISessionListener listener;
		public WPSessionManagerClient (ISessionListener listener)
		{
			this.listener = listener;
		}

		#region ISessionManagerClient implementation

		public void createSession (string scopedId)
		{
			var result = App360SDK.UnityWrapper.App360SDKWrapper.OpenSession(scopedId);
			if(result.IsSuccess){

				listener.onSuccess();
			}else{
				listener.onFailure(result.Error);
			}

		}

		public void createSessionWithService (string service, string token)
		{
			var result = App360SDK.UnityWrapper.App360SDKWrapper.OpenSessionWithService(service,token);
			if(result.IsSuccess){
				
				listener.onSuccess();
			}else{
				listener.onFailure(result.Error);
			}
		}

		#endregion
	}
}
#endif
