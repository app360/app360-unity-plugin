using UnityEngine;
using System.Collections;
using App360SDK.Api;

namespace App360SDK.Common
{
	internal interface IScopedUserClient
	{

		void linkFacebook (string token);

		void linkGoogle (string token);

		void unLinkFacebook ();

		void unLinkGoogle ();

		ScopedUser getActiveUser ();

		string get(string key);

		void put(string key, string value);

		void save();

		Profile getFacebookProfile();

		Profile getGoogleProfile();
	}
}