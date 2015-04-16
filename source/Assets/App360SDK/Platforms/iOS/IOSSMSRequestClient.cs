using UnityEngine;
using System.Collections;
using System;
using App360SDK.Common;
using System.Runtime.InteropServices;
using App360SDK.Api;

namespace App360SDK.iOS
{
	internal class IOSSMSRequestClient : ISMSRequestClient
	{
		#region Init callback
		
		internal delegate void A360SMSRequestSuccess (IntPtr smsRequestClient,string transactionData);

		internal delegate void A360SMSRequestFailure (IntPtr smsRequestClient,string error);
		
		#endregion

		private ISMSRequestListener listener;
		private IntPtr smsRequestPtr;

		public IOSSMSRequestClient (ISMSRequestListener listener)
		{
			this.listener = listener;

			IntPtr client = (IntPtr)GCHandle.Alloc (this);
			SmsRequestPtr = Externs.createSMSRequestObject (client);
			Externs.setSMSRequestCallback (SmsRequestPtr, SMSRequestSuccess, SMSRequestFailure);
		}

		public IntPtr SmsRequestPtr {
			get {
				return smsRequestPtr;
			}
			set {
				Externs.A360URelease (smsRequestPtr);
				smsRequestPtr = value;
			}
		}


		#region ISMSRequestClient implementation

		public void requestTransaction (string amount, string payload)
		{
			Externs.requestSMSTransaction (SmsRequestPtr, amount, payload);
		}

		#endregion

		#region SMSRequest callback method
		
		[MonoPInvokeCallback(typeof(A360SMSRequestSuccess))]
		private static void SMSRequestSuccess (IntPtr client, string transactionData)
		{

			IntPtrToSMSRequestClient (client).listener.onSuccess (transactionData);
		}
		
		[MonoPInvokeCallback(typeof(A360SMSRequestFailure))]
		private static void SMSRequestFailure (IntPtr client, string error)
		{
			IntPtrToSMSRequestClient (client).listener.onFailure (error);
		}
		
		private static IOSSMSRequestClient IntPtrToSMSRequestClient (IntPtr client)
		{
			GCHandle handle = (GCHandle)client;
			return handle.Target as IOSSMSRequestClient;
		}
		
		#endregion
	}
}
