using UnityEngine;
using System.Collections;
using App360SDK.Common;

namespace App360SDK
{
	internal class App360SDKClientFactory
	{
		internal static IBankRequestClient getBankRequest (IBankRequestListener listener)
		{
			#if UNITY_IOS
			return new App360SDK.iOS.IOSBankRequestClient(listener);
			#elif UNITY_ANDROID
			return new App360SDK.Android.AndroidBankRequestClient(listener);			

			#endif
		}

		internal static ISMSRequestClient getSMSRequest (ISMSRequestListener listener)
		{
			#if UNITY_IOS
			return new App360SDK.iOS.IOSSMSRequestClient(listener);
			#elif UNITY_ANDROID
			return new App360SDK.Android.AndroidSMSRequestClient(listener);	
			#endif
		}

		internal static ICardRequestClient getCardRequest (ICardRequestListener listener)
		{
			#if UNITY_IOS
			return new App360SDK.iOS.IOSCardRequestClient(listener);
			#elif UNITY_ANDROID
			return new App360SDK.Android.AndroidCardRequestClient(listener);
			#endif
		}

		internal static IApp360SDKClient getApp360SDKClient (IInitListener listener)
		{
			#if UNITY_IOS
			return new App360SDK.iOS.IOSApp360SDKClient(listener);
			#elif UNITY_ANDROID
			return new App360SDK.Android.AndroidApp360SDKClient(listener);
			#endif 
		}

		internal static ISessionManagerClient getSessionManagerClient (ISessionListener listener)
		{
			#if UNITY_IOS
			return new App360SDK.iOS.IOSSessionManagerClient (listener);
			#elif UNITY_ANDROID
			return new App360SDK.Android.AndroidSessionManagerClient(listener);
			#endif
		}

		internal static IScopedUserClient getScopedUserClient (IScopedUserListener listener)
		{
			#if UNITY_IOS
			return new App360SDK.iOS.IOSScopedUserClient (listener);
			#elif UNITY_ANDROID
			return new App360SDK.Android.AndroidScopedUserClient(listener);
			#endif
		}
	}
}
