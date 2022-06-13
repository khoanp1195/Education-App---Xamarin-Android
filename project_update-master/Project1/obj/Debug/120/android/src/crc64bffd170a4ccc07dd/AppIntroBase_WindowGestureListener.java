package crc64bffd170a4ccc07dd;


public class AppIntroBase_WindowGestureListener
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSingleTapUp:(Landroid/view/MotionEvent;)Z:GetOnSingleTapUp_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("AppIntro.AppIntroBase+WindowGestureListener, AppIntro", AppIntroBase_WindowGestureListener.class, __md_methods);
	}


	public AppIntroBase_WindowGestureListener ()
	{
		super ();
		if (getClass () == AppIntroBase_WindowGestureListener.class)
			mono.android.TypeManager.Activate ("AppIntro.AppIntroBase+WindowGestureListener, AppIntro", "", this, new java.lang.Object[] {  });
	}

	public AppIntroBase_WindowGestureListener (crc64bffd170a4ccc07dd.AppIntroBase p0)
	{
		super ();
		if (getClass () == AppIntroBase_WindowGestureListener.class)
			mono.android.TypeManager.Activate ("AppIntro.AppIntroBase+WindowGestureListener, AppIntro", "AppIntro.AppIntroBase, AppIntro", this, new java.lang.Object[] { p0 });
	}


	public boolean onSingleTapUp (android.view.MotionEvent p0)
	{
		return n_onSingleTapUp (p0);
	}

	private native boolean n_onSingleTapUp (android.view.MotionEvent p0);

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
