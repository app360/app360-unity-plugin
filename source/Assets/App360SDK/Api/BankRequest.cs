
using UnityEngine;
using System.Collections;
using System;
using App360SDK.Common;
using SimpleJSON;
namespace App360SDK.Api
{
	public class BankRequest : IBankRequestListener
	{
		IBankRequestClient client;
		
		public event EventHandler<App360TransactionEventArgs> onBankRequestSuccess = delegate {};
		public event EventHandler<App360ErrorEventArgs> onBankRequestFailure = delegate {};
		
		public BankRequest ()
		{
			client = App360SDKClientFactory.getBankRequest (this);
		}
		
		public void requestTransaction (int amount, string payload)
		{
			if (client != null)
				client.requestTransaction (amount, payload);
		}
		
		#region IBankRequestListener implementation
		
		public void onSuccess (string transaction)
		{
			App360TransactionEventArgs args = new App360TransactionEventArgs ();
			args.transaction = new BankTransaction (transaction);
			onBankRequestSuccess (this, args);
		}
		
		public void onFailure (string error)
		{
			App360ErrorEventArgs args = new App360ErrorEventArgs ();

			int errorCode = -1;
			if (int.TryParse (error, out errorCode)) {
				args.errorCode = errorCode;
			} else {
				args.message = error;
			}

			onBankRequestFailure (this, args);
		}
		
		#endregion
	}
}