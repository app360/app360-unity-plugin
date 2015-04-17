using UnityEngine;
using System.Collections;
using App360SDK.Api;

namespace App360SDK.Common
{
	internal interface IStatusRequestListener
	{
		void onSuccess (string reponse);
		
		void onFailure (string error);
	}
}

