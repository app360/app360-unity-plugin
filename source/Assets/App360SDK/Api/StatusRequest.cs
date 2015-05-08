using UnityEngine;
using System.Collections;
using App360SDK.Common;
using System;
using SimpleJSON;

namespace App360SDK.Api
{

	internal class StatusRequest : IStatusRequestListener
	{
		public event EventHandler<App360TransactionEventArgs> OnCheckStatusRequestSuccess = delegate {};
		public event EventHandler<App360ErrorEventArgs> OnCheckStatusRequestFailure = delegate {};

		IStatusRequestClient client;
		public StatusRequest ()
		{
			this.client = App360SDKClientFactory.getCheckTransationRequest(this);
		}
		
		public void Check(string transationId)
		{
			if(client!=null)
				client.requestTransaction (transationId);
		}
		

		#region ICheckTransactionRequestListener implementation
		public void onSuccess (string reponse)
		{
			App360TransactionEventArgs args = new App360TransactionEventArgs ();
			
			args.transaction =new Transaction (reponse);
			OnCheckStatusRequestSuccess (this, args);
		}
		public void onFailure (string error)
		{
			App360ErrorEventArgs args = new App360ErrorEventArgs ();
			args.errorCode = Convert.ToInt32 (error);
			OnCheckStatusRequestFailure (this, args);
		}
		#endregion

	}
}
