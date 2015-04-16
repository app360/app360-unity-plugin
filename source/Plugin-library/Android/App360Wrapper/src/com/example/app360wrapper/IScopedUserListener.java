package com.example.app360wrapper;

public interface IScopedUserListener {
	void onSuccess();
	
	void onFailure(String error);
}
