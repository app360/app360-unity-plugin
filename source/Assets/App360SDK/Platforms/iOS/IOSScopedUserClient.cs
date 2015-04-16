
using UnityEngine;
using System.Collections;
using App360SDK.Common;
using System;
using System.Runtime.InteropServices;

namespace App360SDK.iOS
{
	internal class IOSScopedUserClient : IScopedUserClient
	{

		#region ScopedUser callback
		
		internal delegate void A360UpdateUserSuccess (IntPtr scopedUserClient);

		internal delegate void A360UpdateUserFailure (IntPtr scopedUserClient,string error);
		
		#endregion



		private IScopedUserListener listener;
		private IntPtr scopedUserPtr;

		public IOSScopedUserClient (IScopedUserListener listener)
		{
			this.listener = listener;

			IntPtr scopedUserClient = (IntPtr)GCHandle.Alloc (this);
			ScopedUserPtr = Externs.createScopedUserObject (scopedUserClient);
			
			Externs.setSessionCallback (ScopedUserPtr, UpdateUserSuccess, UpdateUserFailure);
		}

		public IntPtr ScopedUserPtr {
			get {
				return scopedUserPtr;
			}
			set {
				scopedUserPtr = value;
			}
		}

		#region IScopedUserClient implementation

		#region IScopedUserClient implementation

		public App360SDK.Api.ScopedUser getCurrentUser ()
		{
			// TODO: pass json to ScopedUser's contructor
			string json = "";
			return new App360SDK.Api.ScopedUser (json);
		}

		#endregion

		public string getScopedId ()
		{
			return Externs.getUserScopedId ();
		}

		public string getChannel ()
		{
			return Externs.getUserChannel ();
		}

		public string getSubChannel ()
		{
			return Externs.getUserSubChannel ();
		}

		public void linkFacebook (string token)
		{
			Externs.linkFacebook (ScopedUserPtr, token);
		}

		public void linkGoogle (string token)
		{
			Externs.linkGoogle (ScopedUserPtr, token);
		}

		public void unlinkFacebook ()
		{
			Externs.unlinkFacebook (ScopedUserPtr);
		}

		public void unLinkGoogle ()
		{
			Externs.unlinkGoogle (ScopedUserPtr);
		}

		#endregion

		#region Session callback method
		
		[MonoPInvokeCallback(typeof(A360UpdateUserSuccess))]
		private static void UpdateUserSuccess (IntPtr scopedUserPtr)
		{
			IntPtrToScopedUserClient (scopedUserPtr).listener.onSuccess ();
		}
		
		[MonoPInvokeCallback(typeof(A360UpdateUserFailure))]
		private static void UpdateUserFailure (IntPtr scopedUserPtr, string error)
		{
			IntPtrToScopedUserClient (scopedUserPtr).listener.onFailure (error);
		}
		
		private static IOSScopedUserClient IntPtrToScopedUserClient (IntPtr scopedUserClient)
		{
			GCHandle handle = (GCHandle)scopedUserClient;
			return handle.Target as IOSScopedUserClient;
		}


		#endregion
	}
}
