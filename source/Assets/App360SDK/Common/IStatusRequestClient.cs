using UnityEngine;
using System.Collections;

namespace App360SDK.Common
{
	internal interface IStatusRequestClient
	{
		void requestTransaction (string transactionId);
	}
}