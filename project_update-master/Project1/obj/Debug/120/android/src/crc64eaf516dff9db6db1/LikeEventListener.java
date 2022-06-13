package crc64eaf516dff9db6db1;


public class LikeEventListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.tasks.OnSuccessListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSuccess:(Ljava/lang/Object;)V:GetOnSuccess_Ljava_lang_Object_Handler:Android.Gms.Tasks.IOnSuccessListenerInvoker, Xamarin.GooglePlayServices.Tasks\n" +
			"";
		mono.android.Runtime.register ("Project1.EventListeners.LikeEventListener, Project1", LikeEventListener.class, __md_methods);
	}


	public LikeEventListener ()
	{
		super ();
		if (getClass () == LikeEventListener.class)
			mono.android.TypeManager.Activate ("Project1.EventListeners.LikeEventListener, Project1", "", this, new java.lang.Object[] {  });
	}

	public LikeEventListener (java.lang.String p0)
	{
		super ();
		if (getClass () == LikeEventListener.class)
			mono.android.TypeManager.Activate ("Project1.EventListeners.LikeEventListener, Project1", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onSuccess (java.lang.Object p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (java.lang.Object p0);

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
