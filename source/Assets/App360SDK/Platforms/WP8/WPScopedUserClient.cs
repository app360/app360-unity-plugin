#if UNITY_WP8
using System;
using UnityEngine;
using System.Collections;
using App360SDK.Common;
using App360SDK.Api;
using App360SDK.UnityWrapper;
namespace App360SDK.Platforms.WP8
{
	internal class WPScopedUserClient : IScopedUserClient
	{
		UserInfo user;

		static IScopedUserListener listener;
		public WPScopedUserClient (IScopedUserListener listener)
		{
			WPScopedUserClient.listener= listener;
		}

		#region IScopedUserClient implementation

		public string get (string key)
		{
			if(user!=null)
			{
				return user.Get(key);
			} 
			else 
				return null;
		}

		public void put (string key, string value)
		{
			if(user!=null)
			{
				user.Put(key,value);
			}else{
				Debug.Log("WPScopedUserClient.User has been null");
			}
		}

		public void save ()
		{

			if(user!=null)
			{
				if(user.Save())
				{
					getActiveUser();
					WPScopedUserClient.listener.onSuccess();
				}
				else
				{
					WPScopedUserClient.listener.onFailure("1");
				}
			} 
		}



		public App360SDK.Common.Profile getFacebookProfile ()
		{
			if(user!=null && user.FacebookProfile!=null)
			{
				return new App360SDK.Common.Profile()
				{
					accessToken = user.FacebookProfile.accessToken,
					fullName = user.FacebookProfile.fullName,
					service = user.FacebookProfile.service,
					profileImage =user.FacebookProfile.profileImage

				};
			} else
			{
				return null;
			}
		}

		public App360SDK.Common.Profile getGoogleProfile ()
		{
			if(user!=null && user.GoogleProfile!=null)
			{
				return new App360SDK.Common.Profile()
				{
					accessToken = user.GoogleProfile.accessToken,
					fullName = user.GoogleProfile.fullName,
					service = user.GoogleProfile.service,
					profileImage =user.GoogleProfile.profileImage
						
				};
			} else
			{
				return null;
			}
		}

		public void unLinkFacebook ()
		{
			App360SDKWrapper.unlinkFacebook();
		}


		public void linkFacebook (string token)
		{
			App360SDKWrapper.linkWithFacebook(token);
		}

		public void linkGoogle (string token)
		{
			App360SDKWrapper.linkGoogle(token);
		}



		public void unLinkGoogle ()
		{
			App360SDKWrapper.unLinkGoogle();
		}

		public ScopedUser getActiveUser ()
		{
			user = App360SDK.UnityWrapper.App360SDKWrapper.getCurrentUser();
			var scopedUser= (ScopedUser)listener;
			Debug.Log("getActiveUser "+scopedUser.ScopedId+":"+user);
			scopedUser.Channel =user.Channel;
			scopedUser.SubChannel =user.SubChannel;
			scopedUser.ScopedId =user.ScopeId;
			return scopedUser;
		}

		#endregion
	}
}
#endif
