
using UnityEngine;
using System.Collections;
using System;
using App360SDK.Common;
using App360SDK.Api;
using System.Runtime.InteropServices;

namespace App360SDK.iOS
{
	internal class IOSCardRequestClient : ICardRequestClient
	{
		#region Init callback
		
		internal delegate void A360CardRequestSuccess (IntPtr cardRequestClient,string transactionData);

		internal delegate void A360CardRequestFailure (IntPtr cardRequestClient,string error);
		
		#endregion
		
		private ICardRequestListener listener;
		private IntPtr cardRequestPtr;
		
		public IOSCardRequestClient (ICardRequestListener listener)
		{
			this.listener = listener;

			IntPtr client = (IntPtr)GCHandle.Alloc (this);
			CardRequestPtr = Externs.createCardRequestObject (client);
			Externs.setSMSRequestCallback (CardRequestPtr, CardRequestSuccess, CardRequestFailure);
		}
		
		public IntPtr CardRequestPtr {
			get {
				return cardRequestPtr;
			}
			set {
				Externs.A360URelease (cardRequestPtr);
				cardRequestPtr = value;
			}
		}

		#region ICardRequestClient implementation

		public void requestTransaction (string vendor, string cardCode, string cardSerial, string payload)
		{
			Externs.requestCardTransaction (CardRequestPtr, vendor, cardCode, cardSerial, payload);
		}

		#endregion
		
		#region CardRequest callback method
		
		[MonoPInvokeCallback(typeof(A360CardRequestSuccess))]
		private static void CardRequestSuccess (IntPtr client, string transactionData)
		{

			IntPtrToCardRequestClient (client).listener.onSuccess (transactionData);
		}
		
		[MonoPInvokeCallback(typeof(A360CardRequestFailure))]
		private static void CardRequestFailure (IntPtr client, string error)
		{
			IntPtrToCardRequestClient (client).listener.onFailure (error);
		}
		
		private static IOSCardRequestClient IntPtrToCardRequestClient (IntPtr client)
		{
			GCHandle handle = (GCHandle)client;
			return handle.Target as IOSCardRequestClient;
		}
		
		#endregion
	}
}
