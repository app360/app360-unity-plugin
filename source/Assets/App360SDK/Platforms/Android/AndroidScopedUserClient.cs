#if UNITY_ANDROID
using System;
using App360SDK.Common;
using UnityEngine;
using App360SDK.Api;
using SimpleJSON;

namespace App360SDK.Android
{
	internal class AndroidScopedUserClient : IScopedUserClient
	{
		#region IScopedUserClient implementation

		public string get (string key)
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			return app360.CallStatic<string>("getScopeUserProperty", key);
		}

		public void put (string key, string value)
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic("putScopeUserProperty", key, value);
		}

		public void save ()
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic("saveScopeUser", new SaveCallBackProxy(_listener));
		}

		public Profile getFacebookProfile ()
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			var profileString = app360.CallStatic<string>("getFacebookProfileScopeUser");
			return Parse (profileString);
		}

		public Profile getGoogleProfile ()
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			var profileString = app360.CallStatic<string>("getGoogleProfileScopeUser");
			return Parse (profileString);
		}

		Profile Parse (string profileString)
		{
			var jProfile = JSON.Parse (profileString);
			return new Profile {
				accessToken = jProfile ["accessToken"],
				fullName = jProfile ["fullName"],
				profileImage = jProfile ["profileImage"],
				service = jProfile ["service"],
			};
		}

		#endregion

		IScopedUserListener _listener;

		public AndroidScopedUserClient (IScopedUserListener listener)
		{

			_listener = listener;
			//getActiveUser ();
		}

		public string Channel {
			get;
			set;
		}

		public string SubChannel {
			get;
			set;
		}

		public string ScopedId {
			get;
			set;
		}

		public string getScopedId ()
		{
			return ScopedId;
		}
		
		public string getChannel ()
		{
			return Channel;
		}
		
		public string getSubChannel ()
		{
			return SubChannel;
		}
		
		public void linkFacebook (string token)
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("LinkFacebook", token, new ScopedUserProxy (_listener));
		}
		
		public void linkGoogle (string token)
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("LinkGoogle", token, new ScopedUserProxy (_listener));
		}
		
		public void unLinkFacebook ()
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("unLinkFacebook", new ScopedUserProxy (_listener));
		}
		
		public void unLinkGoogle ()
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("unLinkGoogle", new ScopedUserProxy (_listener));
		}

		public ScopedUser getActiveUser ()
		{

			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			string userInfoString = app360.CallStatic<string> ("getCurrentUser");
			Debug.Log("userInfoString" + userInfoString);
			if (string.IsNullOrEmpty (userInfoString)) {
				return null;
			}
			return new ScopedUser (userInfoString);

		}
	}
}

#endif