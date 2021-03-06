# App360SDK Unity Plugin

The App360SDK Unity Plugin helps provides a way to integrate with Unity project deployed as native Android or iOS applications. Plugin features include:
- Create session via AppscopedId SDK
- Get ScopedUser info
- Support make transaction via SMS, card, e-banking (API)

The plugin contains a .unitypackage file for those that want to easily import the plugin, as well as the source code for those that want to iterate on it.

## Downloads

Please check out our [releases](https://github.com/app360/app360-unity-plugin/releases) for the latest downloads for the different sample apps.

## Requirements

- Unity 4.5
- Application Id & Application secret
- To deploy on Android:
    - [App360SDK for Android](https://github.com/app360/app360-android-sdk)
    - Add app360.properties to `Asset`
- To deploy on iOS
    - [App360SDK for iOS](https://github.com/app360/app360-ios-sdk)

## Integrate the Plugin into your Game

1. Open your project in the Unity editor.
2. Navigate to **Assets -> Import Package -> Custom Package**.
3. Select the **App360SDK.unitypackage** file.
4. Import all of the files for the plugins by selecting Import. Make sure to check for any conflicts with files.

![Imgur](http://i.imgur.com/GOFkUqt.png)

![Imgur](http://i.imgur.com/7JL2FNs.png)

## Android Setup

1. Add the `google-play-services_lib` folder, located at `ANDROID_SDK_LOCATION/extras/google/google_play_services/libproject`, into the `Plugins/Android` folder of your project.
2. [For users running a version of Unity earlier than 5.0] Navigate to Temp/StagingArea of your project directory and copy AndroidManifest.xml to Assets/Plugins/Android. Add the following <meta-data> tag to the AndroidManifest.xml file:
```xml
<activity android:name="com.unity3d.player.UnityPlayerActivity" ...>
  ...
  <meta-data android:name="unityplayer.ForwardNativeEventsToDalvik" android:value="true" />
</activity>
```

## iOS Setup

No pre-build setup required.

## Run the project

If you're running the HelloWorld sample project, you should be able to run the project now.

To build and run on Android, click **File -> Build Settings**, select the Android platform, then **Switch Platform**, then **Build and Run**.

To build and run on iOS, click **File -> Build Settings**, select the iOS platform, then **Switch Platform**, then **Build**. This will export an XCode project. You'll need to do the following before you can run it:

1. Drag and drop App360SDK.framework and MWNetworking,framework onto **Embedded Binaries** section.
2. From the Xcode project navigator, right-click on the project, and choose Add Files To "".
3. Navigate to and select MOG.bundle

If these steps didn't work, [the developer docs](https://docs.app360.vn/) always has the most up-to-date information on how to reference the Google Mobile Ads iOS library.

# Get started

## Initialization

Create new instance of App360SDK and Call  Initialize() with Application Id and Secret

```C#
void Start ()
{
	// Create an instance of App360SDK
	App360SDK.Api.App360SDK app360sdk = new App360SDK.Api.App360SDK ();
	
	// register a handler for the initial event 
	app360sdk.onInitSuccess += HandleonInitSuccess;
	app360sdk.onInitFailure += HandleonInitFailure;
	
	// initialize app360 sdk with appId and token secret
	app360sdk.initialize ("application id", "secret");
}
```

```
// Handleons the init failure.
void HandleonInitFailure (object sender, App360ErrorEventArgs e)
{
	Debug.Log ("HandleonInitFailure. Error: code: "+e.errorCode+", message" + e.message);
}
	
// Handleons the init success.	
void HandleonInitSuccess (object sender, System.EventArgs e)
{	
	//TODO: something to do here
}
```

##Session

### Initialize

```C#
SessionManager sessionManager = new SessionManager ();
sessionManager.onSessionSuccess += OnCreateSessionSuccess;
sessionManager.onSessionFailure += OnCreateSessionFailure;
```
### Anonymously

To create an anonymously session:
```C#
sessionManager.createSession ("");
```

### With Facebook/Google access token

To login with Facebook/google:
```
sessionManager.createSessionWithService("facebook", "Accesstoken");
```

### Event callback

```
// Raises the create session success event.
void OnCreateSessionSuccess (object sender, System.EventArgs e)
{
		// get current user
		ScopedUser scopedUser = ScopedUser.getCurrentUser ();
		
		/// getting user info 
		/// scopedUser.ScopedId
		/// scopedUser.Channel
		/// scopedUser.SubChannel
		/// example:
		Debug.Log ("ScopedId:" + scopedUser.ScopedId);

}
	
//Raises the create session failure event.
void OnCreateSessionFailure (object sender, System.EventArgs e)
{
		Debug.Log ("HandleOnCreateSessionFailure. Error: " + e.ToString ());
}	
```

>You can see the example for more details: /Assets/Example/Main.cs

## Payment


###To make a banking charging request

```C#
public void ChargeByBank ()
{				
	BankRequest bank = new BankRequest ();
	bank.onBankRequestSuccess += OnRequestTransactionSucsess;
	bank.onBankRequestFailure += OnRequestTransactionFailure;
	bank.requestTransaction (10000, "my Payload");
}
```

###To make a SMS charging request

```
public void ChargeBySMS ()
{		
	// create Payment by SMS
	SMSRequest request = new SMSRequest ();
	request.onSMSRequestSuccess += OnRequestTransactionSucsess;
	request.onSMSRequestFailure += OnRequestTransactionFailure;
	// Pass amounts of SMS by string that values divided by semi colon
	request.requestTransaction ("1000,5000,15000", "payload");
}
```

###To make a Card charging request

```
public void ChargeByCard ()
{		
	// create Payment by SMS
	CardRequest card = new CardRequest ();
	card.onCardRequestSuccess += OnRequestTransactionSucsess;
	card.onCardRequestFailure += OnRequestTransactionFailure;

	card.requestTransaction ("vinaphone", "12321321313", "2132132132131", "my Payload");
}
```

### Transaction request response 

```
// Raises the request SMS sucsess event.	
void OnRequestTransactionSucsess (object sender, App360TransactionEventArgs e)
{
	// to check type of transaction
	if (e.transaction is SMSTransaction) {
		// SMSTransaction
	} else if (e.transaction is BankTransaction) {
		// BankTransaction		
	} else if (e.transaction is CardTransaction) {
		// CardTransaction
	}		
}	

/// Raises the request SMS failure event.	
void OnRequestTransactionFailure (object sender, App360ErrorEventArgs e)
{
	// TODO: do something when transaction request has been failed
}
```
>You can see the example for more details: /Assets/Example/Main.cs
