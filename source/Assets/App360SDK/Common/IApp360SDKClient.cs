using UnityEngine;
using System.Collections;

namespace App360SDK.Common
{
	internal interface IApp360SDKClient
	{
		void initialize (string appId, string appSecret);

		string getChannel ();

		string getSubChannel ();

		string getNativeSDKVersion ();

	}
}