#if UNITY_WP8
using System;
using UnityEngine;
using System.Collections;
using App360SDK.Common;

namespace App360SDK.Platforms.WP8
{
	internal class WPCardRequestClient : ICardRequestClient
	{
		ICardRequestListener listener;
		public WPCardRequestClient (ICardRequestListener listener)
		{
			this.listener =listener;
		}

		#region ICardRequestClient implementation

		public void requestTransaction (string vendor, string cardCode, string cardSerial, string payload)
		{
			var card = App360SDK.UnityWrapper.App360SDKWrapper.CardRequest(vendor, cardCode, cardSerial, payload);
			if(card.IsSuccess)
			{
				listener.onSuccess(card.Message);
			}
			else
			{
				listener.onFailure(card.Message);
			}
		}

		#endregion
	}
}
#endif
