using UnityEngine;
using System.Collections;
using App360SDK.Common;
using System;
using SimpleJSON;

namespace App360SDK.Api
{
	public class CardRequest : ICardRequestListener
	{
		ICardRequestClient client;
		
		public event EventHandler<App360TransactionEventArgs> onCardRequestSuccess = delegate {};
		public event EventHandler<App360ErrorEventArgs> onCardRequestFailure = delegate {};
		
		public CardRequest()
		{
			client = App360SDKClientFactory.getCardRequest (this);
		}
		
		public void requestTransaction(string vendor, string cardCode, string cardSerial, string payload)
		{
			client.requestTransaction (vendor, cardCode, cardSerial, payload);
		}
		
		#region ICardRequestListener implementation
		
		public void onSuccess (string transaction)
		{
			App360TransactionEventArgs args = new App360TransactionEventArgs ();

			args.transaction =new CardTransaction (transaction);

			onCardRequestSuccess (this, args);
		}
		
		public void onFailure (string error)
		{
			App360ErrorEventArgs args = new App360ErrorEventArgs ();
			args.errorCode = Convert.ToInt32 (error);
			onCardRequestFailure (this, args);
		}
		
		#endregion
	}
}
