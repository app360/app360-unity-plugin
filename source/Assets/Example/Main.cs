using UnityEngine;
using System.Collections;
using App360SDK;
using App360SDK.Api;

public class Main : MonoBehaviour {
	
	/// <summary>
	/// Start this instance.
	/// Use this for initialization
	/// </summary>
	void Start () {
		// Create an instance of App360SDK
		App360SDK.Api.App360SDK app360sdk = new App360SDK.Api.App360SDK ();
		// register a handler for the initial event 
		app360sdk.onInitSuccess += HandleonInitSuccess;
		app360sdk.onInitFailure += HandleonInitFailure;
		
		Debug.Log ("Start initialize");	
		// initialize app360 sdk with appId and token secret
		app360sdk.initialize ("1", "wugah");
	}
	
	/// <summary>
	/// Handleons the init failure.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	void HandleonInitFailure (object sender, App360ErrorEventArgs e)
	{
		Debug.Log ("HandleonInitFailure. Error: " + e.errorCode);
	}
	
	/// <summary>
	/// Handleons the init success.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	void HandleonInitSuccess (object sender, System.EventArgs e)
	{
		SessionManager sessionManager = new SessionManager ();
		sessionManager.onSessionSuccess += OnCreateSessionSuccess;
		sessionManager.onSessionFailure += OnCreateSessionFailure;
		sessionManager.createSession ("");
	}
	
	/// <summary>
	/// Raises the create session success event.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	void OnCreateSessionSuccess (object sender, System.EventArgs e)
	{
		// get current user
		ScopedUser scopedUser = ScopedUser.getCurrentUser ();
		
		/// getting user info 
		/// scopedUser.ScopedId
		/// scopedUser.Channel
		/// scopedUser.SubChannel
		/// example:
		Debug.Log("ScopedId:" + scopedUser.ScopedId);
		
		
		// create Payment by SMS
		SMSRequest request = new SMSRequest ();
		request.onSMSRequestSuccess += OnRequestSMSSucsess;
		request.onSMSRequestFailure += OnRequestSMSFailure;
		// Pass amounts of SMS by string that values divided by semi colon
		request.requestTransaction ("1000,5000,15000", "payload");
		
	}
	
	/// <summary>
	/// Raises the request SMS sucsess event.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	void OnRequestSMSSucsess (object sender,  App360TransactionEventArgs e)
	{
		// To checking status of a transaction
		
		/*CheckTransactionStatusRequest request = new CheckTransactionStatusRequest ();
		
		request.OnCheckStatusRequestSuccess += (object s, App360TransactionEventArgs arg) => {
			Debug.Log ("On CHECK Transaction Sucsess : " + arg.transaction.Status+","+arg.transaction.Payload +","+arg.transaction.TransactionId);
		};
		
		request.OnCheckStatusRequestFailure += (bund, arg) => {
			Debug.Log ("On CHECK Transaction Failure : " + arg.errorCode);
		};
		
		request.Check (e.transaction.TransactionId);
		*/
	}
	
	/// <summary>
	/// Raises the request SMS failure event.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	void OnRequestSMSFailure (object sender, App360ErrorEventArgs e)
	{
		Debug.Log ("OnRequestSMSFailure. Error: " + e.errorCode);
	}
	
	/// <summary>
	/// Raises the create session failure event.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	void OnCreateSessionFailure (object sender, System.EventArgs e)
	{
		Debug.Log ("HandleonInitFailure. Error: " + e.ToString());
	}	
	
}
