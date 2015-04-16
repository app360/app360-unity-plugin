using UnityEngine;
using System.Collections;
using App360SDK.Api;

namespace App360SDK.Common
{
	internal interface IScopedUserClient
	{

		void linkFacebook (string token);

		void linkGoogle (string token);

		void unlinkFacebook ();

		void unLinkGoogle ();

		ScopedUser getCurrentUser ();
	}
}