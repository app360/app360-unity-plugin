package com.example.app360wrapper;

public interface IBankRequestListener {
	void onSuccess(String response);
	
	void onFailure(String error);
}
