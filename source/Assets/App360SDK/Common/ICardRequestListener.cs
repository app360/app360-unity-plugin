using UnityEngine;
using System.Collections;
using App360SDK.Api;

namespace App360SDK.Common
{
	internal interface ICardRequestListener
	{
		void onSuccess (string reponse);
		
		void onFailure (string error);
	}
}