using UnityEngine;
using System.Collections;

namespace App360SDK.Common
{
	internal interface ISessionManagerClient
	{
		void createSession (string scopedId);

		void createSessionWithService (string service, string token);
	}
}
