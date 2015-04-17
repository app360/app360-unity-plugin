using UnityEngine;
using System.Collections;
using SimpleJSON;
namespace App360SDK.Api
{
	public enum TransactionStatus
	{
		BEGIN = 0,
		COMPLETED = 1,
		FAILED = 2,
		PENDING = 3
	}

	public class Transaction
	{
		public Transaction()
		{
		}
		public Transaction(string json){
			var jTransaction = JSON.Parse (json);
			// base
			payload = jTransaction ["payload"].Value;
			switch (jTransaction ["status"].Value) {
			case "begin":
				status = TransactionStatus.BEGIN;
				break;
			case "completed":
				status = TransactionStatus.COMPLETED;
				break;
			case "failed":
				status = TransactionStatus.FAILED;
				break;
			case "pending":
				status = TransactionStatus.PENDING;
				break;
			default:
				break;
			}
			
			transactionId = jTransaction ["transaction_id"].Value;
			

		}
		protected string payload;
		protected TransactionStatus status;
		protected string transactionId;

		public string Payload {
			get {
				return payload;
			}

		}

		public TransactionStatus Status {
			get {
				return status;
			}
		}

		public string TransactionId {
			get {
				return transactionId;
			}
		}
	}
}
