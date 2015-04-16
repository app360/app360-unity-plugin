using UnityEngine;
using System.Collections;
using App360SDK.Common;
using System;

namespace App360SDK.Api
{
	public class SessionManager : ISessionListener
	{
		private ISessionManagerClient client;

		public event EventHandler<EventArgs> onSessionSuccess = delegate {};
		public event EventHandler<EventArgs> onSessionFailure = delegate {};

		public SessionManager()
		{
			client = App360SDKClientFactory.getSessionManagerClient (this);
		}

		public void createSession(string scopedId)
		{
			client.createSession (scopedId);
		}

		public void createSessionWithService(string service, string token)
		{
			client.createSessionWithService (service, token);
		}

		#region ISessionListener implementation

		public void onSuccess ()
		{
			onSessionSuccess (this, EventArgs.Empty);
		}

		public void onFailure (string error)
		{
			App360ErrorEventArgs args = new App360ErrorEventArgs ();
			args.errorCode = Convert.ToInt32 (error);
			onSessionFailure (this, args);
		}

		#endregion


	}
}
