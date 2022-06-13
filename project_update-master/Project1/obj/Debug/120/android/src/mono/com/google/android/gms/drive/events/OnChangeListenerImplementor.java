package mono.com.google.android.gms.drive.events;


public class OnChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.drive.events.OnChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onChange:(Lcom/google/android/gms/drive/events/ChangeEvent;)V:GetOnChange_Lcom_google_android_gms_drive_events_ChangeEvent_Handler:Android.Gms.Drive.Events.IOnChangeListenerInvoker, Xamarin.GooglePlayServices.Drive\n" +
			"";
		mono.android.Runtime.register ("Android.Gms.Drive.Events.IOnChangeListenerImplementor, Xamarin.GooglePlayServices.Drive", OnChangeListenerImplementor.class, __md_methods);
	}


	public OnChangeListenerImplementor ()
	{
		super ();
		if (getClass () == OnChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Gms.Drive.Events.IOnChangeListenerImplementor, Xamarin.GooglePlayServices.Drive", "", this, new java.lang.Object[] {  });
	}


	public void onChange (com.google.android.gms.drive.events.ChangeEvent p0)
	{
		n_onChange (p0);
	}

	private native void n_onChange (com.google.android.gms.drive.events.ChangeEvent p0);

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
