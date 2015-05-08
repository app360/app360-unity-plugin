using UnityEngine;
using System.Collections;
using App360SDK.Common;
using System;
using SimpleJSON;
namespace App360SDK.Api
{
	public class ScopedUser : IScopedUserListener
	{
		private IScopedUserClient client;

		public event EventHandler<EventArgs> onUpdateUserSuccess = delegate {};
		public event EventHandler<App360ErrorEventArgs> onUpdateUserFailure = delegate {};

		public static ScopedUser getCurrentUser ()
		{
			ScopedUser scopeUser = new ScopedUser ();
			return  scopeUser.getActiveUser ();
		}

		public ScopedUser getActiveUser ()
		{
			if (client != null) {
				return client.getActiveUser ();
			} else {
				return null;
			}
		}

		private ScopedUser ()
		{
			client = App360SDKClientFactory.getScopedUserClient (this);
		}

		public ScopedUser (string json)
		{
			client = App360SDKClientFactory.getScopedUserClient (this);
			JSONNode jObj = JSON.Parse (json);
			ScopedId = jObj ["scoped_id"];
			Channel = jObj ["channel"];
			SubChannel = jObj ["sub_channel"];
		}

		#region IScopedUserClient implementation

		public string get (string key)
		{
			return client.get (key);
		}

		public void put (string key, string value)
		{
			client.put (key, value);
		}

		public void save ()
		{
			client.save ();
		}

		public Profile getFacebookProfile ()
		{
			return client.getFacebookProfile ();
		}

		public Profile getGoogleProfile ()
		{
			return client.getGoogleProfile ();
		}

		public void linkFacebook (string token)
		{
			if (client != null)
				client.linkFacebook (token);
		}
		
		public void linkGoogle (string token)
		{
			if (client != null)
				client.linkGoogle (token);
		}
		
		public void unLinkFacebook ()
		{
			if (client != null)
				client.unLinkFacebook ();
		}
		
		public void unLinkGoogle ()
		{
			if (client != null)
				client.unLinkGoogle ();
		}
		#endregion


		public string ScopedId {
			get;
			set;
		}

		public string Channel {
			get;
			set;
		}

		public string SubChannel {
			get;
			set;
		}

		#region IScopedUserListener implementation

		public void onSuccess ()
		{
			onUpdateUserSuccess (this, EventArgs.Empty);
		}

		public void onFailure (string error)
		{
			App360ErrorEventArgs args = new App360ErrorEventArgs ();
			int errorCode = -1;
			if (int.TryParse (error, out errorCode)) {
				args.errorCode = errorCode;
			} else {
				args.message = error;
			}
			onUpdateUserFailure (this, args);
		}
		#endregion


	}
}