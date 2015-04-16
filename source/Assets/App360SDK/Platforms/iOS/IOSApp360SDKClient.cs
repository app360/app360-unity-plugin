using UnityEngine;
using System.Collections;
using App360SDK.Api;
using App360SDK.Common;
using System;
using System.Runtime.InteropServices;

namespace App360SDK.iOS
{
	internal class IOSApp360SDKClient : IApp360SDKClient
	{

		#region Init callback

		internal delegate void A360InitSuccess (IntPtr app360sdkClient);

		internal delegate void A360InitFailure (IntPtr app360sdkClient,string error);

		#endregion

		private IInitListener listener;
		private IntPtr app360SDKPtr;

		public IOSApp360SDKClient (IInitListener listener)
		{
			this.listener = listener;

			IntPtr app360sdkClient = (IntPtr)GCHandle.Alloc (this);
			App360SDKPtr = Externs.createApp360SDKObject (app360sdkClient);
			
			Externs.setInitCallback (App360SDKPtr, InitSuccess, InitFailure);
		}

		public IntPtr App360SDKPtr {
			get {
				return app360SDKPtr;
			}
			set {
				Externs.A360URelease (app360SDKPtr);
				app360SDKPtr = value;
			}
		}

		#region IApp360SDKClient implementation

		public void initialize (string appId, string appSecret)
		{
			Externs.initialize (App360SDKPtr, appId, appSecret);
		}

		public string getChannel ()
		{
			return Externs.getChannel ();
		}

		public string getSubChannel ()
		{
			return Externs.getSubChannel ();
		}

		public string getNativeSDKVersion ()
		{
			return Externs.getNativeSDKVersion ();
		}

		#endregion

		#region Init callback method

		[MonoPInvokeCallback(typeof(A360InitSuccess))]
		private static void InitSuccess (IntPtr sdkClient)
		{
			IntPtrToApp360SDKClient (sdkClient).listener.onSuccess ();
		}

		[MonoPInvokeCallback(typeof(A360InitFailure))]
		private static void InitFailure (IntPtr sdkClient, string error)
		{
			IntPtrToApp360SDKClient (sdkClient).listener.onFailure (error);
		}

		private static IOSApp360SDKClient IntPtrToApp360SDKClient (IntPtr bannerClient)
		{
			GCHandle handle = (GCHandle)bannerClient;
			return handle.Target as IOSApp360SDKClient;
		}

		#endregion
	}
}