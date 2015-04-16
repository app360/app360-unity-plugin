using UnityEngine;
using System.Collections;

namespace App360SDK.Common
{
	internal interface ISMSRequestClient
	{
		void requestTransaction (string amount, string payload);
	}
}
