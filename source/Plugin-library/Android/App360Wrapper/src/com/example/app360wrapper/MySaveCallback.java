package com.example.app360wrapper;

import android.util.Log;
import vn.mog.app360.sdk.scopedid.SaveCallback;
import vn.mog.app360.sdk.scopedid.SessionManager;

public class MySaveCallback implements SaveCallback
{
	private static final String TAG = "Unity";
	IScopedUserListener linkServicecallback;
	String message;
	public MySaveCallback(IScopedUserListener callback,String mss) {
		message=mss;
		linkServicecallback=callback;
				
	}
	public void onSuccess() {
		// TODO Auto-generated method stub
		Log.d(TAG +"Jar", "MySaveCallback :"+ message);
		linkServicecallback.onSuccess();
	}		

	public void onFailure(Exception arg0) {
		// TODO Auto-generated method stub
		Log.d(TAG +"Jar", "MySaveCallback :"+ message);
		linkServicecallback.onFailure(arg0.getMessage());
	}
}
