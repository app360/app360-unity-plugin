package com.example.app360wrapper;

import com.unity3d.player.UnityPlayer;

import vn.mog.app360.sdk.scopedid.ScopedUser;
import vn.mog.app360.sdk.scopedid.SessionManager;
import vn.mog.app360.sdk.scopedid.SessionManager.SessionCallback;
import vn.mog.app360.sdk.scopedid.SessionService;

public class MySessionCallback implements SessionCallback {
	
	String _gameObject;
	String _methodName;
	
	public MySessionCallback(String gameObject,String method){
		_gameObject =gameObject;
		_methodName=method;
	}
	@Override
	public void onFailure(Exception ex) {
		// TODO Auto-generated method stub

		UnityPlayer.UnitySendMessage(_gameObject, _methodName, ex.getMessage());
	}

	@Override
	public void onSuccess() {
		SessionService.Session session = SessionManager.getCurrentSession();
		UnityPlayer.UnitySendMessage(_gameObject, _methodName, "Current session: " + session);

        ScopedUser currentUser = ScopedUser.getCurrentUser();
        UnityPlayer.UnitySendMessage(_gameObject, _methodName, "Current user: " + currentUser);
		
	}

}
