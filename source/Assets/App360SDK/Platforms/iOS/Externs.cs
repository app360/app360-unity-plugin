
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace App360SDK.iOS
{
	internal class Externs
	{
		#region Common externs

		[DllImport("__Internal")]
		internal static extern void A360URelease (IntPtr obj);

		#endregion

		#region App360SDK

		[DllImport("__Internal")]
		internal static extern IntPtr createApp360SDKObject (IntPtr app360sdkClient);

		[DllImport("__Internal")]
		internal static extern void setInitCallback (
			IntPtr wrapperObject,
			IOSApp360SDKClient.A360InitSuccess successCallback,
			IOSApp360SDKClient.A360InitFailure failureCallback);

		[DllImport("__Internal")]
		internal static extern void initialize (
			IntPtr wrapperObject,
			string appId,
			string appSecret);

		[DllImport("__Internal")]
		internal static extern string getChannel ();

		[DllImport("__Internal")]
		internal static extern string getSubChannel ();

		[DllImport("__Internal")]
		internal static extern string getNativeSDKVersion ();
			
		#endregion

		#region SessionManager

		[DllImport("__Internal")]
		internal static extern IntPtr createSessionManagerObject (IntPtr sessionManagerClient);

		[DllImport("__Internal")]
		internal static extern void setSessionCallback (
			IntPtr sessionWrapper,
			IOSSessionManagerClient.A360SessionSuccess successCallback,
			IOSSessionManagerClient.A360SessionFailure failureCallback);

		[DllImport("__Internal")]
		internal static extern void createSession (
			IntPtr sessionWrapper,
			string scopedId);

		[DllImport("__Internal")]
		internal static extern void createSessionWithService (
			IntPtr sessionWrapper,
			string service,
			string token);

		#endregion

		#region ScopedUser

		[DllImport("__Internal")]
		internal static extern IntPtr createScopedUserObject (IntPtr scopedUserClient);

		[DllImport("__Internal")]
		internal static extern void setScopedUserCallback (
			IntPtr scopedUserWrapper,
			IOSScopedUserClient.A360UpdateUserSuccess successCallback,
			IOSScopedUserClient.A360UpdateUserFailure failureCallback);

		[DllImport("__Internal")]
		internal static extern string getUserScopedId ();

		[DllImport("__Internal")]
		internal static extern string getUserChannel ();

		[DllImport("__Internal")]
		internal static extern string getUserSubChannel ();

		[DllImport("__Internal")]
		internal static extern void linkFacebook (
			IntPtr scopedUserWrapper,
			string token);

		[DllImport("__Internal")]
		internal static extern void linkGoogle (
			IntPtr scopedUserWrapper,
			string token);

		[DllImport("__Internal")]
		internal static extern void unlinkFacebook (IntPtr scopedUserWrapper);

		[DllImport("__Internal")]
		internal static extern void unlinkGoogle (IntPtr scopedUserWrapper);

		#endregion

		#region SMSRequest

		[DllImport("__Internal")]
		internal static extern IntPtr createSMSRequestObject (IntPtr client);

		[DllImport("__Internal")]
		internal static extern void setSMSRequestCallback (
			IntPtr wrapper,
			IOSSMSRequestClient.A360SMSRequestSuccess successCallback,
			IOSSMSRequestClient.A360SMSRequestFailure failureCallback);

		[DllImport("__Internal")]
		internal static extern void requestSMSTransaction (
			IntPtr wrapper,
			string amount, 
			string payload);

		#endregion

		#region CardRequest
		
		[DllImport("__Internal")]
		internal static extern IntPtr createCardRequestObject (IntPtr client);
		
		[DllImport("__Internal")]
		internal static extern void setCardRequestCallback (
			IntPtr wrapper,
			IOSCardRequestClient.A360CardRequestSuccess successCallback,
			IOSCardRequestClient.A360CardRequestFailure failureCallback);
		
		[DllImport("__Internal")]
		internal static extern void requestCardTransaction (
			IntPtr wrapper,
			string vendor, 
			string cardCode, 
			string cardSerial, 
			string payload);
		
		#endregion

		#region BankRequest
		
		[DllImport("__Internal")]
		internal static extern IntPtr createBankRequestObject (IntPtr client);
		
		[DllImport("__Internal")]
		internal static extern void setBankRequestCallback (
			IntPtr wrapper,
			IOSBankRequestClient.A360BankRequestSuccess successCallback,
			IOSBankRequestClient.A360BankRequestFailure failureCallback);
		
		[DllImport("__Internal")]
		internal static extern void requestBankTransaction (
			IntPtr wrapper,
			int amount, 
			string payload);
		
		#endregion

		#region StatusRequest
		
		[DllImport("__Internal")]
		internal static extern IntPtr createStatusRequestObject (IntPtr client);
		
		[DllImport("__Internal")]
		internal static extern void setStatusRequestCallback (
			IntPtr wrapper,
			IOSStatusRequestClient.A360StatusRequestSuccess successCallback,
			IOSStatusRequestClient.A360StatusRequestFailure failureCallback);
		
		[DllImport("__Internal")]
		internal static extern void requestStatusTransaction (
			IntPtr wrapper,
			string transactionId);
		
		#endregion
	}
}
