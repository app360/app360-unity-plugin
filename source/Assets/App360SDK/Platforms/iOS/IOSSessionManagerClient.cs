
using UnityEngine;
using System.Collections;
using App360SDK.Common;
using System;
using System.Runtime.InteropServices;

namespace App360SDK.iOS
{
	internal class IOSSessionManagerClient : ISessionManagerClient
	{
		#region Init callback
		
		internal delegate void A360SessionSuccess (IntPtr sessionManagerClient);

		internal delegate void A360SessionFailure (IntPtr sessionManagerClient,string error);
		
		#endregion

		private ISessionListener listener;
		private IntPtr sessionManagerPtr;

		public IOSSessionManagerClient (ISessionListener listener)
		{
			this.listener = listener;

			IntPtr managerClient = (IntPtr)GCHandle.Alloc (this);
			SessionManagerPtr = Externs.createSessionManagerObject (managerClient);
			
			Externs.setSessionCallback (SessionManagerPtr, SessionSuccess, SessionFailure);
		}

		public IntPtr SessionManagerPtr {
			get {
				return sessionManagerPtr;
			}
			set {
				sessionManagerPtr = value;
			}
		}

		#region ISessionManagerClient implementation

		public void createSession (string scopedId)
		{
			Externs.createSession (SessionManagerPtr, scopedId);
		}

		public void createSessionWithService (string service, string token)
		{
			Externs.createSessionWithService (SessionManagerPtr, service, token);
		}

		#endregion

		#region Session callback method
		
		[MonoPInvokeCallback(typeof(A360SessionSuccess))]
		private static void SessionSuccess (IntPtr managerPtr)
		{
			IntPtrToSessionManagerClient (managerPtr).listener.onSuccess ();
		}
		
		[MonoPInvokeCallback(typeof(A360SessionFailure))]
		private static void SessionFailure (IntPtr managerPtr, string error)
		{
			IntPtrToSessionManagerClient (managerPtr).listener.onFailure (error);
		}
		
		private static IOSSessionManagerClient IntPtrToSessionManagerClient (IntPtr managerClient)
		{
			GCHandle handle = (GCHandle)managerClient;
			return handle.Target as IOSSessionManagerClient;
		}
		
		#endregion
	}
}