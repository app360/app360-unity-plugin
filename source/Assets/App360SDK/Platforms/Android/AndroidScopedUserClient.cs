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
		IScopedUserListener _listener;

		public AndroidScopedUserClient (IScopedUserListener listener)
		{
			_listener = listener;
			getCurrentUser ();
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
		
		public void unlinkFacebook ()
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("unLinkFacebook", new ScopedUserProxy (_listener));
		}
		
		public void unLinkGoogle ()
		{
			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			app360.CallStatic ("unLinkGoogle", new ScopedUserProxy (_listener));
		}

		public ScopedUser getCurrentUser ()
		{

			AndroidJavaClass app360 = new AndroidJavaClass (Utils.APP360_WRAPPER_CLASSNAME);
			string userInfoString = app360.CallStatic<string> ("getCurrentUser");

			if (string.IsNullOrEmpty (userInfoString)) {
				return null;
			}
			return new ScopedUser (userInfoString);

		}
	}
}

#endif