using UnityEngine;
using App360SDK.Api;
using System.Collections.Generic;
using SimpleJSON;

namespace App360SDK.Api
{
	public class SMSTransaction : Transaction
	{
		public SMSTransaction (string transaction)
		{

			var jTransaction = JSON.Parse (transaction);
			// base
			base.payload = jTransaction ["payload"].Value;
			Debug.Log ("payload: " + payload);

			switch (jTransaction ["status"].Value) {
			case "BEGIN":
				base.status = TransactionStatus.BEGIN;
				break;
			case "COMPLETED":
				base.status = TransactionStatus.COMPLETED;
				break;
			case "FAILED":
				base.status = TransactionStatus.FAILED;
				break;
			case "PENDING":
				base.status = TransactionStatus.PENDING;
				break;
			default:
				break;
			}
			Debug.Log ("Status: " + status);
			
			base.transactionId = jTransaction ["transaction_id"].Value;
			Debug.Log ("transactionId: " + transactionId);

			// sms
			amount = jTransaction ["amount"].Value;
			Debug.Log ("payload: " + amount);

			recipient = jTransaction ["recipient"].Value;
			Debug.Log ("recipient: " + recipient);

			syntax = jTransaction ["syntax"].Value;
			Debug.Log ("syntax: " + syntax);

			services = new Dictionary<string, string> ();
			JSONArray jServices = jTransaction ["services"].AsArray;
			foreach (var service in jServices.Childs) {
				services.Add (service ["to"].Value, service ["amount"].Value);
				Debug.Log ("to: " + service ["to"].Value + ",amount" + service ["amount"].Value);
			}
		}

		public string syntax {
			get;
			private set;
		}

		public Dictionary<string, string> services {
			get;
			private set;

		}

		public string amount {
			get;
			private set;
		}

		public string recipient {
			get;
			private set;
		}	
	}
}
