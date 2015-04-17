package com.example.app360wrapper;

public interface ICheckTransactionRequestListener {
	void onSuccess (String reponse);
	
	void onFailure (String error);
}
