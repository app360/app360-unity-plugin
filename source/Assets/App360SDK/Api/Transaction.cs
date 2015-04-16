using UnityEngine;
using System.Collections;

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
