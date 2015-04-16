using UnityEngine;
using System.Collections;
using App360SDK.Api;

namespace App360SDK.Common
{
	internal interface ISMSRequestListener
	{
		void onSuccess (string transaction);
		
		void onFailure (string error);
	}
}
