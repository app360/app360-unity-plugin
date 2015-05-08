#if UNITY_WP8
using UnityEngine;
using System.Collections;
using App360SDK.Common;
namespace App360SDK.Platforms.WP8
{
	internal class WPApp360SDKClient : IApp360SDKClient
	{
		IInitListener listener;
		public WPApp360SDKClient (IInitListener listener)
		{
			this.listener = listener;
		}
		#region IApp360SDKClient implementation

		public void initialize (string appId, string appSecret)
		{
			if(App360SDK.UnityWrapper.App360SDKWrapper.Initialize(appId, appSecret)){
				listener.onSuccess();
			}else{
				listener.onFailure("1");
			}
		}

		public string getChannel ()
		{
			return App360SDK.UnityWrapper.App360SDKWrapper.GetChannel();
		}

		public string getSubChannel ()
		{
			return App360SDK.UnityWrapper.App360SDKWrapper.GetSubChannel();
		}

		public string getNativeSDKVersion ()
		{
			return "1.0.0";
		}

		#endregion


	}

}
#endif