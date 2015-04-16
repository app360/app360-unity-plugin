using UnityEngine;
using System.Collections;
using System;
using App360SDK.Common;

namespace App360SDK.Api
{
	public class App360SDK : IInitListener {

		private IApp360SDKClient client;

		// These are the initialize callback events that can be hooked into
		public event EventHandler<EventArgs> onInitSuccess = delegate {};
		public event EventHandler<App360ErrorEventArgs> onInitFailure = delegate {};

		public App360SDK()
		{
			client = App360SDKClientFactory.getApp360SDKClient (this);
		}

		public void initialize(string appId, string appSecret)
		{
			client.initialize (appId, appSecret);
		}

		public string getChannel()
		{
			return client.getChannel ();
		}

		public string getSubChannel()
		{
			return client.getSubChannel ();
		}

		public string getNativeSDKVersion()
		{
			return client.getNativeSDKVersion ();
		}

		public string getUnitySDKVersion()
		{
			return "1.0.0";
		}

		#region IInitListener implementation

		public void onSuccess ()
		{
			onInitSuccess (this, EventArgs.Empty);
		}

		public void onFailure (string error)
		{
			App360ErrorEventArgs args = new App360ErrorEventArgs ();
			args.errorCode = Convert.ToInt32 (error);
			onInitFailure (this, args);
		}

		#endregion
	}
}