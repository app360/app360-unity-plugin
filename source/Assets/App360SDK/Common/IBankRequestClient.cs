using UnityEngine;
using System.Collections;

namespace App360SDK.Common
{
	internal interface IBankRequestClient
	{
		void requestTransaction (int amount, string payload);
	}
}
