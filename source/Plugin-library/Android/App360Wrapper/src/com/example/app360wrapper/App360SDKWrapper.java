package com.example.app360wrapper;

import java.util.ArrayList;
import java.util.List;

import org.json.JSONArray;
import org.json.JSONObject;

import vn.mog.app360.sdk.App360SDK;
import vn.mog.app360.sdk.InitListener;
import vn.mog.app360.sdk.payment.BankRequest;
import vn.mog.app360.sdk.payment.CardRequest;
import vn.mog.app360.sdk.payment.PaymentForm;
import vn.mog.app360.sdk.payment.SmsRequest;
import vn.mog.app360.sdk.payment.StatusRequest;
import vn.mog.app360.sdk.payment.data.BankTransaction;
import vn.mog.app360.sdk.payment.data.CardTransaction;
import vn.mog.app360.sdk.payment.data.SmsTransaction;
import vn.mog.app360.sdk.payment.data.Transaction;
import vn.mog.app360.sdk.payment.data.CardTransaction.CardVendor;
import vn.mog.app360.sdk.payment.data.SmsTransaction.SmsService;
import vn.mog.app360.sdk.payment.data.TransactionStatus;
import vn.mog.app360.sdk.payment.interfaces.BankRequestListener;
import vn.mog.app360.sdk.payment.interfaces.CardRequestListener;
import vn.mog.app360.sdk.payment.interfaces.SmsRequestListener;
import vn.mog.app360.sdk.payment.interfaces.StatusRequestListener;
import vn.mog.app360.sdk.payment.utils.Const;
import vn.mog.app360.sdk.scopedid.Profile;
import vn.mog.app360.sdk.scopedid.SaveCallback;
import vn.mog.app360.sdk.scopedid.ScopedUser;
import vn.mog.app360.sdk.scopedid.SessionManager;
import vn.mog.app360.sdk.scopedid.SessionManager.SessionCallback;
import vn.mog.app360.sdk.scopedid.SessionService;

import com.google.gson.Gson;
import com.google.gson.JsonArray;
import com.google.gson.JsonObject;
import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

import android.content.Context;
import android.util.Log;

public class App360SDKWrapper extends UnityPlayerActivity {
	protected static final String TAG = "UNITY";
	static String gameObject;
	static String methodName;
	static Context context;

	public static void initialize(String appId, String appSecret,
			String _gameObject, String _methodCallBack) {
		gameObject = _gameObject;
		methodName = _methodCallBack;
		App360SDK.initialize(appId, appSecret,
				UnityPlayer.currentActivity.getApplicationContext(),
				new InitListener() {

					@Override
					public void onSuccess() {
						UnityPlayer.UnitySendMessage(gameObject, methodName,
								"Init SDK Success");
						SessionService.Session session = SessionManager
								.getCurrentSession();
						if (session == null) { // no cached valid session
							SessionManager.createSession(null,
									new SessionCallback() {

										@Override
										public void onSuccess() {
											// TODO Auto-generated method stub
											Log.d(TAG,
													"Android: Create session success ");
											try {
												UnityPlayer
														.UnitySendMessage(
																gameObject,
																methodName,
																"Android: Create session success\n");
												ScopedUser currentUser = ScopedUser
														.getCurrentUser();

												UnityPlayer.UnitySendMessage(
														gameObject, methodName,
														"Current user: "
																+ currentUser);
											} catch (Exception exception) {
												UnityPlayer.UnitySendMessage(
														gameObject, methodName,
														"Current user: Error");
											}

										}

										@Override
										public void onFailure(Exception arg0) {
											// TODO Auto-generated method stub
											UnityPlayer
													.UnitySendMessage(
															gameObject,
															methodName,
															"Android:  Create session fail ");
										}
									});
						} else {
							Log.d(TAG, "Current session: " + session);
						}
					}

					@Override
					public void onFailure(Exception e) {
						UnityPlayer.UnitySendMessage(gameObject, methodName,
								"Error");
						Log.e(TAG, "Initialization error", e);
					}
				});

	}

	static IInitListener _listener;
	static ISessionListener _sessionCallback;
	static IScopedUserListener _scopedUserListener;

	public static void initialize(String appId, String appSecret,
			IInitListener listener) {
		Log.d(TAG + "Jar", "add_listener");
		_listener = listener;
		App360SDK.initialize(appId, appSecret,
				UnityPlayer.currentActivity.getApplicationContext(),
				new InitListener() {

					@Override
					public void onSuccess() {
						Log.d(TAG + "Jar", "initialize onSuccess");
						_listener.onSuccess();
					}

					@Override
					public void onFailure(Exception ex) {
						Log.d(TAG + "Jar", "initializeon :" + ex.getMessage());
						_listener.onFailure(ex.getMessage());
					}
				});
	}

	public static String getVersion() {
		return "1.0.0.0";
	}

	public static void createSession(String scopedId, ISessionListener callback) {
		_sessionCallback = callback;
		Log.d(TAG + "Jar", "createSession " + scopedId);
		SessionManager.createSession(scopedId, new SessionCallback() {

			@Override
			public void onSuccess() {
				// TODO Auto-generated method stub
				_sessionCallback.onSuccess();
				Log.d(TAG + "Jar", "initializeon :"
						+ SessionManager.getCurrentSession().toString());
			}

			@Override
			public void onFailure(Exception arg0) {
				// TODO Auto-generated method stub
				_sessionCallback.onFailure(arg0.getMessage());
				Log.d(TAG + "Jar", "createSession " + arg0.getMessage());
			}
		});
	}

	public static void createSession(String service, String token,
			ISessionListener callback) {
		_sessionCallback = callback;
		Log.d(TAG + "Jar", "createSession " + service);
		SessionManager.createSession(service, token, new SessionCallback() {

			@Override
			public void onSuccess() {
				// TODO Auto-generated method stub
				_sessionCallback.onSuccess();
				Log.d(TAG + "Jar",
						"initializeon :" + SessionManager.getCurrentSession());
			}

			@Override
			public void onFailure(Exception arg0) {
				// TODO Auto-generated method stub
				Log.d(TAG + "Jar", "createSession " + arg0.getMessage());
				_sessionCallback.onFailure(arg0.getMessage());
			}
		});
	}

	public static String getCurrentUser() {
		ScopedUser user = ScopedUser.getCurrentUser();
		JsonObject jobj = new JsonObject();
		jobj.addProperty("scoped_id", user.get("scoped_id"));
		jobj.addProperty("channel", user.get("channel"));
		jobj.addProperty("sub_channel", user.get("sub_channel"));
		return jobj.toString();
	}

	public static void LinkFacebook(String token, IScopedUserListener callback) {

		ScopedUser.getCurrentUser().linkFacebook(token,
				new MySaveCallback(callback, "Facebook"));
	}

	public static void LinkGoogle(String token, IScopedUserListener callback) {

		ScopedUser.getCurrentUser().linkGoogle(token,
				new MySaveCallback(callback, "Google"));
	}

	public static void unLinkFacebook(String token, IScopedUserListener callback) {

		ScopedUser.getCurrentUser().unlinkFacebook(
				new MySaveCallback(callback, "Facebook"));
	}

	public static void unLinkGoogle(String token, IScopedUserListener callback) {

		ScopedUser.getCurrentUser().unlinkGoogle(
				new MySaveCallback(callback, "Google"));
	}

	static ICardRequestListener card_listener;

	public static void requestCardTransaction(String vendor, String cardCode,
			String cardSerial, String payload, ICardRequestListener listener) {
		card_listener = listener;
		CardRequest cardRequest = new CardRequest.Builder()
				.setCardCode(cardCode).setCardSerial(cardSerial)
				.setCardVendor(CardVendor.parseString(vendor))
				.setPayload(payload)
				.setListener(new CardRequestListener() {

					@Override
					public void onSuccess(CardTransaction card) {
						// TODO Parse
						JsonObject jobj = new JsonObject();

						jobj.addProperty("payload", card.getPayload());
						jobj.addProperty("status", card.getStatus().name());
						jobj.addProperty("transaction_id",
								card.getTransactionId());
						jobj.addProperty("card_code", card.getCardCode());
						jobj.addProperty("vendor", card.getCardVendor().name());

						card_listener.onSuccess(jobj.toString());
					}

					@Override
					public void onFailure(Throwable error) {
						card_listener.onFailure(error.getMessage());
					}
				}).build();
		cardRequest.execute();
	}
	
	
	static ISMSRequestListener sms_listener;
	public static void requestSMSTransaction(String amount, String payload,
			ISMSRequestListener listener) {
		sms_listener=listener;
		List<Const.SmsAmount> amounts=new ArrayList<Const.SmsAmount>();
		
		for (String item : amount.split(",")) {
			amounts.add(Const.SmsAmount.fromInt(Integer.parseInt(item)));
			Log.d("WRAPPER","add amount: " +Const.SmsAmount.fromInt(Integer.parseInt(item)));
		}
		SmsRequest smsRequest = new SmsRequest.Builder()
				.setAmounts(amounts.toArray(new Const.SmsAmount[amounts.size()]))
				.setPayload(payload)
				.setListener(new SmsRequestListener() {

					@Override
					public void onSuccess(SmsTransaction sms) {
						Log.d("WRAPPER","sms onSuccess");
						JsonObject jobj = new JsonObject();
						Log.d(TAG + "Jar", "sms request " +  sms.getPayload());
						jobj.addProperty("payload", sms.getPayload());
						jobj.addProperty("status", sms.getStatus().name());
						jobj.addProperty("transaction_id",
								sms.getTransactionId());
						jobj.addProperty("recipient",
								sms.getRecipient());
						jobj.addProperty("syntax",
								sms.getSyntax());
						jobj.addProperty("amount",
								sms.getAmount());
						
						JsonArray jArr=new JsonArray();
						for (SmsService smsService : sms.getServices()) {
							JsonObject temp=new JsonObject();
							temp.addProperty("to",smsService.getRecipient());
							temp.addProperty("amount", smsService.getAmount());
							jArr.add(temp);
						}
						jobj.add("services", jArr);
						Log.d("WRAPPER","sms onSuccess:" +jobj.toString());
						sms_listener.onSuccess(jobj.toString());
					}

					@Override
					public void onFailure(Throwable error) {
						sms_listener.onFailure(error.getMessage());
					}
				}).build();
		
		smsRequest.execute();
	}

	static IBankRequestListener bank_listener;

	public static void requestBankTransaction(int amount, String payload,
			IBankRequestListener listener) {
		bank_listener = listener;
		BankRequest bankRequest = new BankRequest.Builder().setAmount(amount)
				.setPayload(payload)
				.setListener(new BankRequestListener() {

					@Override
					public void onSuccess(BankTransaction bank) {
						JsonObject jobj = new JsonObject();
						Log.d(TAG + "Jar", "bank request " +  bank.getPayload());
						jobj.addProperty("payload", bank.getPayload());
						jobj.addProperty("status", bank.getStatus().name());
						jobj.addProperty("transaction_id",
								bank.getTransactionId());
						jobj.addProperty("amount", bank.getAmount());
						jobj.addProperty("pay_url", bank.getPayUrl());

						bank_listener.onSuccess(jobj.toString());

					}

					@Override
					public void onFailure(Throwable error) {
						bank_listener.onFailure(error.getMessage());
					}
				}).build();
		bankRequest.execute();
	}
	
	static ICheckTransactionRequestListener check_transaction_listener;
	public static void checkTransactionStatus(String transactionId, ICheckTransactionRequestListener listener){
		check_transaction_listener=listener;
		StatusRequest statusRequest = new StatusRequest.Builder()
        .setListener(new StatusRequestListener() {
			
			@Override
			public void onFinish(Transaction status) {
				JsonObject jobj = new JsonObject();
				Log.d(TAG + "Jar", "status transaction: " +  status.getPayload());
				jobj.addProperty("payload", status.getPayload());
				jobj.addProperty("status", status.getStatus().name());
				jobj.addProperty("transaction_id",	status.getTransactionId());
				check_transaction_listener.onSuccess(jobj.toString());
			}
			
			@Override
			public void onError(Throwable error) {
				check_transaction_listener.onFailure(error.getMessage());
				
			}
		})
        .setTransactionId(transactionId)
        .build();
		statusRequest.execute();
	}
}
