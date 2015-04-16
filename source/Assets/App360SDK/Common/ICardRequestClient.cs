using UnityEngine;
using System.Collections;

namespace App360SDK.Common
{
	internal interface ICardRequestClient
	{
		void requestTransaction (string vendor, string cardCode, string cardSerial, string payload);
	}
}