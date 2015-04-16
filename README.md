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

If these steps didn't work, [the developer docs](https://github.com/app360/app360-ios-sdk) always has the most up-to-date information on how to reference the Google Mobile Ads iOS library.
