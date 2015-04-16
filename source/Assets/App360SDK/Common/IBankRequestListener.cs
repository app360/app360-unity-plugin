using UnityEngine;
using System.Collections;
using App360SDK.Api;

namespace App360SDK.Common
{
	internal interface IBankRequestListener
	{
		void onSuccess (string response);
		
		void onFailure (string error);
	}
}
