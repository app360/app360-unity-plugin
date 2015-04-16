using UnityEngine;
using System.Collections;
using System;
using App360SDK.Common;
using App360SDK.Api;
using System.Runtime.InteropServices;

namespace App360SDK.iOS
{
	internal class IOSBankRequestClient : IBankRequestClient
	{
		#region Init callback
		
		internal delegate void A360BankRequestSuccess (IntPtr bankRequestClient,string transactionData);

		internal delegate void A360BankRequestFailure (IntPtr bankRequestClient,string error);
		
		#endregion
		
		private IBankRequestListener listener;
		private IntPtr bankRequestPtr;
		
		public IOSBankRequestClient (IBankRequestListener listener)
		{
			this.listener = listener;
		}
		
		public IntPtr BankRequestPtr {
			get {
				return bankRequestPtr;
			}
			set {
				Externs.A360URelease (bankRequestPtr);
				bankRequestPtr = value;
			}
		}

		#region IBankRequestClient implementation

		public void requestTransaction (int amount, string payload)
		{
			throw new NotImplementedException ();
		}

		#endregion
		
		#region BankRequest callback method
		
		[MonoPInvokeCallback(typeof(A360BankRequestSuccess))]
		private static void BankRequestSuccess (IntPtr client, string transactionData)
		{

			IntPtrToBankRequestClient (client).listener.onSuccess (transactionData);
		}
		
		[MonoPInvokeCallback(typeof(A360BankRequestFailure))]
		private static void BankRequestFailure (IntPtr client, string error)
		{
			IntPtrToBankRequestClient (client).listener.onFailure (error);
		}
		
		private static IOSBankRequestClient IntPtrToBankRequestClient (IntPtr client)
		{
			GCHandle handle = (GCHandle)client;
			return handle.Target as IOSBankRequestClient;
		}
		
		#endregion
	}
}
