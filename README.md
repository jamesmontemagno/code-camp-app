code-camp-app
=============

## Setup

* Download Location: Since Google has long file paths it is recommended to download this into C:\Source


## Google Play Services

 Maps (special note)
----

`Xamarin.Forms.Maps` uses the native map APIs on each platform. If you are creating your own Xamarin.Forms app, **Xamarin.Forms.Maps** is a a separate NuGet package that you should download. On Android, this also has a dependency on **GooglePlayServices** (another NuGet) which is downloaded automatically. These have already been added to the CodeCamp solution.

After adding a reference to **Xamarin.Forms.Maps** in a new project, you also need to add 

    Xamarin.Forms.FormsMaps.Init()
    
calls to each application. Refer to the CodeCamp example where this is already implemented.


###iOS

On iOS the map control "just works".


###Android

To use the Google Maps API on Android you must generate an **API key** and add it to your Android project. See the Xamarin doc on [obtaining a Google Maps API key](http://developer.xamarin.com/guides/android/platform_features/maps_and_location/maps/obtaining_a_google_maps_api_key/). After following those instructions, paste the **API key** in the `Properties/AndroidManifest.xml` file (view source and find/update the following element):

    <meta-data android:name="com.google.android.maps.v2.API_KEY" android:value="AbCdEfGhIjKlMnOpQrStUvWValueGoesHere" />

You need to follow these instructions in order for the map data to display in CodeCamp on Android.

###Windows Phone

The `Map` control in Windows Phone requires the **ID_Cap_Map** capability to be selected. This has already been done in the source code, but should be kept in mind if you add maps to a new Xamarin.Forms app.
