using UnityEngine;
using System.Collections;
using System;
using App360SDK.Common;
using System.Runtime.InteropServices;

namespace App360SDK.iOS
{
	internal class IOSStatusRequestClient : IStatusRequestClient
	{
		#region Init callback
		
		internal delegate void A360StatusRequestSuccess (IntPtr statusRequestClient,string transactionData);
		
		internal delegate void A360StatusRequestFailure (IntPtr statusRequestClient,string error);
		
		#endregion
		
		private IStatusRequestListener listener;
		private IntPtr statusRequestPtr;
		
		public IOSStatusRequestClient (IStatusRequestListener listener)
		{
			this.listener = listener;
			
			IntPtr client = (IntPtr)GCHandle.Alloc (this);
			StatusRequestPtr = Externs.createStatusRequestObject (client);
			Externs.setStatusRequestCallback (StatusRequestPtr, StatusRequestSuccess, StatusRequestFailure);
		}
		
		public IntPtr StatusRequestPtr {
			get {
				return statusRequestPtr;
			}
			set {
				Externs.A360URelease (statusRequestPtr);
				statusRequestPtr = value;
			}
		}

		#region IStatusRequestClient implementation
		public void requestTransaction (string transactionId)
		{
			Externs.requestStatusTransaction (StatusRequestPtr, transactionId);
		}
		#endregion		

		
		#region StatusRequest callback method
		
		[MonoPInvokeCallback(typeof(A360StatusRequestSuccess))]
		private static void StatusRequestSuccess (IntPtr client, string transactionData)
		{
			
			IntPtrToStatusRequestClient (client).listener.onSuccess (transactionData);
		}
		
		[MonoPInvokeCallback(typeof(A360StatusRequestFailure))]
		private static void StatusRequestFailure (IntPtr client, string error)
		{
			IntPtrToStatusRequestClient (client).listener.onFailure (error);
		}
		
		private static IOSStatusRequestClient IntPtrToStatusRequestClient (IntPtr client)
		{
			GCHandle handle = (GCHandle)client;
			return handle.Target as IOSStatusRequestClient;
		}
		
		#endregion
	}
}