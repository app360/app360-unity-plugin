package com.example.app360wrapper;

public interface ISMSRequestListener {
	void onSuccess(String response);
	
	void onFailure(String error);
}
