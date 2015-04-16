using UnityEngine;
using System.Collections;
using SimpleJSON;

namespace App360SDK.Api
{
	public class CardTransaction : Transaction
	{
		public CardTransaction (string transaction)
		{
			var jTransaction = JSON.Parse (transaction);
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
			

			// card
			card_code = jTransaction ["card_code"].Value;
			card_serial = jTransaction ["card_serial"].Value;
			vendor = jTransaction ["vendor"].Value;

		}

		public string card_code {
			get;
			private set;
		}

		public string card_serial {
			get;
			private set;
		}

		public string vendor {
			get;
			private set;
		}
	}
}