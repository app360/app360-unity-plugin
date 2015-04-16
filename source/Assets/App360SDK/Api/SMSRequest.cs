using UnityEngine;
using System.Collections;
using App360SDK.Common;
using System;
using SimpleJSON;
using System.Collections.Generic;
namespace App360SDK.Api
{
	public class SMSRequest : ISMSRequestListener
	{
		ISMSRequestClient client;

		public event EventHandler<App360TransactionEventArgs> onSMSRequestSuccess = delegate {};
		public event EventHandler<App360ErrorEventArgs> onSMSRequestFailure = delegate {};

		public SMSRequest()
		{
			client = App360SDKClientFactory.getSMSRequest (this);
		}

		public void requestTransaction(string amount, string payload)
		{
			client.requestTransaction (amount, payload);
		}

		#region ISMSRequestListener implementation

		public void onSuccess (string transaction)
		{
			App360TransactionEventArgs args = new App360TransactionEventArgs ();			 
			args.transaction = new SMSTransaction (transaction);
			onSMSRequestSuccess (this, args);
		}

		public void onFailure (string error)
		{
			App360ErrorEventArgs args = new App360ErrorEventArgs ();
			args.errorCode = Convert.ToInt32 (error);
			onSMSRequestFailure (this, args);
		}

		#endregion
	}
}
