#if UNITY_ANDROID

using UnityEngine;
using App360SDK.Common;
namespace App360SDK.Android
{
	public class InitListenerProxy : AndroidJavaProxy
	{
		private IInitListener listener;
		internal InitListenerProxy (IInitListener _listener)
			: base(Utils.INIT_LISTENER_CLASSNAME)
		{
			this.listener = _listener;
		}
		
		void onSuccess() {
			listener.onSuccess ();
		}
		
		void onFailure(string message) {
			listener.onFailure (message);
		}
	}
}

#endif
