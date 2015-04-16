#if UNITY_ANDROID
using App360SDK.Common;
using System;
using UnityEngine;

namespace App360SDK.Android
{
	internal class AndroidApp360SDKClient: IApp360SDKClient
	{
		private IInitListener _listener;
		AndroidJavaClass app360;

		public AndroidApp360SDKClient (IInitListener listener)
		{
			_listener = listener;
			app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			Debug.Log (app360.CallStatic<string> ("getVersion"));
		}

		public void initialize (string appId, string appSecret)
		{
			try {		

				Debug.Log ("initialize");
				app360.CallStatic ("initialize", appId, appSecret, new InitListenerProxy (_listener));
				
			} catch (Exception exception) {
				Debug.LogError (exception);
			}
		}
		
		public string getChannel ()
		{
			Debug.Log ("getChannel");
			return "";
		}
		
		public string getSubChannel ()
		{
			Debug.Log ("getSubChannel");
			return "";
		}
		
		public string getNativeSDKVersion ()
		{
			return "1.0.0";

		}
	}
}
#endif
