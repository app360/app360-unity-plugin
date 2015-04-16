package com.example.app360wrapper;

public interface ICardRequestListener {
	void onSuccess(String response);
	
	void onFailure(String error);
}
