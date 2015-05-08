#if UNITY_WP8
using UnityEngine;
using System.Collections;
using App360SDK.Common;
using App360SDK.UnityWrapper;
namespace App360SDK.Platforms.WP8
{
	internal class WPBankRequestClient : App360SDK.Common.IBankRequestClient
	{
		IBankRequestListener listener;
		public WPBankRequestClient (IBankRequestListener listener)
		{
			this.listener = listener;
			
		}
		#region IBankRequestClient implementation
		public void requestTransaction (int amount, string payload)
		{
			var bank = App360SDKWrapper.BankRequest(amount +"",payload);
			if(bank.IsSuccess)
			{
				listener.onSuccess(bank.Message);
			}
			else
			{
				listener.onFailure(bank.Message);
			}
		}
		#endregion
	}
}
#endif