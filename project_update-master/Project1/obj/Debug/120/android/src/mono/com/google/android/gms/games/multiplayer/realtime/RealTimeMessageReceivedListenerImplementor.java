package mono.com.google.android.gms.games.multiplayer.realtime;


public class RealTimeMessageReceivedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.games.multiplayer.realtime.RealTimeMessageReceivedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onRealTimeMessageReceived:(Lcom/google/android/gms/games/multiplayer/realtime/RealTimeMessage;)V:GetOnRealTimeMessageReceived_Lcom_google_android_gms_games_multiplayer_realtime_RealTimeMessage_Handler:Android.Gms.Games.MultiPlayer.RealTime.IRealTimeMessageReceivedListenerInvoker, Xamarin.GooglePlayServices.Games\n" +
			"";
		mono.android.Runtime.register ("Android.Gms.Games.MultiPlayer.RealTime.IRealTimeMessageReceivedListenerImplementor, Xamarin.GooglePlayServices.Games", RealTimeMessageReceivedListenerImplementor.class, __md_methods);
	}


	public RealTimeMessageReceivedListenerImplementor ()
	{
		super ();
		if (getClass () == RealTimeMessageReceivedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Gms.Games.MultiPlayer.RealTime.IRealTimeMessageReceivedListenerImplementor, Xamarin.GooglePlayServices.Games", "", this, new java.lang.Object[] {  });
	}


	public void onRealTimeMessageReceived (com.google.android.gms.games.multiplayer.realtime.RealTimeMessage p0)
	{
		n_onRealTimeMessageReceived (p0);
	}

	private native void n_onRealTimeMessageReceived (com.google.android.gms.games.multiplayer.realtime.RealTimeMessage p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
