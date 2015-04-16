using UnityEngine;
using System.Collections;
using SimpleJSON;

namespace App360SDK.Api
{
	public class BankTransaction : Transaction
	{
		public BankTransaction (string data)
		{

			var jTransaction = JSON.Parse (data);
			// base
			base.payload = jTransaction ["payload"].Value;
			switch (jTransaction ["status"].Value) {
			case "begin":
				base.status = TransactionStatus.BEGIN;
				break;
			case "completed":
				base.status = TransactionStatus.COMPLETED;
				break;
			case "failed":
				base.status = TransactionStatus.FAILED;
				break;
			case "pending":
				base.status = TransactionStatus.PENDING;
				break;
			default:
				break;
			}

			base.transactionId = jTransaction ["transaction_id"].Value;

			// banking
			amount = jTransaction ["amount"].Value;
			pay_url = jTransaction ["pay_url"].Value;
		}

		public string pay_url {
			get;
			private set;
		}

		public string amount {
			get;
			private set;
		}
	}
}
