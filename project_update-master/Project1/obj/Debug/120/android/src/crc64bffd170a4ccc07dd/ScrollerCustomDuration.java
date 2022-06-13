package crc64bffd170a4ccc07dd;


public class ScrollerCustomDuration
	extends android.widget.Scroller
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_startScroll:(IIIII)V:GetStartScroll_IIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("AppIntro.ScrollerCustomDuration, AppIntro", ScrollerCustomDuration.class, __md_methods);
	}


	public ScrollerCustomDuration (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ScrollerCustomDuration.class)
			mono.android.TypeManager.Activate ("AppIntro.ScrollerCustomDuration, AppIntro", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ScrollerCustomDuration (android.content.Context p0, android.view.animation.Interpolator p1)
	{
		super (p0, p1);
		if (getClass () == ScrollerCustomDuration.class)
			mono.android.TypeManager.Activate ("AppIntro.ScrollerCustomDuration, AppIntro", "Android.Content.Context, Mono.Android:Android.Views.Animations.IInterpolator, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ScrollerCustomDuration (android.content.Context p0, android.view.animation.Interpolator p1, boolean p2)
	{
		super (p0, p1, p2);
		if (getClass () == ScrollerCustomDuration.class)
			mono.android.TypeManager.Activate ("AppIntro.ScrollerCustomDuration, AppIntro", "Android.Content.Context, Mono.Android:Android.Views.Animations.IInterpolator, Mono.Android:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void startScroll (int p0, int p1, int p2, int p3, int p4)
	{
		n_startScroll (p0, p1, p2, p3, p4);
	}

	private native void n_startScroll (int p0, int p1, int p2, int p3, int p4);

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
