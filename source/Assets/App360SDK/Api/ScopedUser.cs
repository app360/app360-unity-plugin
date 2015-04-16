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
		public event EventHandler<EventArgs> onUpdateUserFailure = delegate {};

		public static ScopedUser getCurrentUser()
		{
			IScopedUserClient mClient = App360SDKClientFactory.getScopedUserClient (null);
			return mClient.getCurrentUser ();
		}

		public ScopedUser()
		{
			client = App360SDKClientFactory.getScopedUserClient (this);
		}

		public ScopedUser(string json){

			JSONNode jObj = JSON.Parse (json);
			ScopedId = jObj ["scoped_id"];
			Channel = jObj ["channel"];
			SubChannel = jObj ["sub_channel"];
		}



		public string ScopedId {
			get;
			private set;
		}

		public string Channel {
			get;
			private set;
		}

		public string SubChannel {
			get;
			private set;
		}

		public void linkFacebook(string token)
		{
			client.linkFacebook (token);
		}

		public void linkGoogle(string token)
		{
			client.linkGoogle (token);
		}

		public void unlinkFacebook()
		{
			client.unlinkFacebook ();
		}

		public void unlinkGoogle()
		{
			client.unLinkGoogle ();
		}

		#region IScopedUserListener implementation

		public void onSuccess ()
		{
			onUpdateUserSuccess (this, EventArgs.Empty);
		}

		public void onFailure (string error)
		{
			App360ErrorEventArgs args = new App360ErrorEventArgs ();
			args.errorCode = Convert.ToInt32 (error);
			onUpdateUserFailure (this, args);
		}
		#endregion


	}
}