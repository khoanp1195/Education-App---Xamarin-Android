package crc64bffd170a4ccc07dd;


public class AppIntroBase_PagerOnPageChangeListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.viewpager.widget.ViewPager.OnPageChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPageScrollStateChanged:(I)V:GetOnPageScrollStateChanged_IHandler:AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker, Xamarin.AndroidX.ViewPager\n" +
			"n_onPageScrolled:(IFI)V:GetOnPageScrolled_IFIHandler:AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker, Xamarin.AndroidX.ViewPager\n" +
			"n_onPageSelected:(I)V:GetOnPageSelected_IHandler:AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker, Xamarin.AndroidX.ViewPager\n" +
			"";
		mono.android.Runtime.register ("AppIntro.AppIntroBase+PagerOnPageChangeListener, AppIntro", AppIntroBase_PagerOnPageChangeListener.class, __md_methods);
	}


	public AppIntroBase_PagerOnPageChangeListener ()
	{
		super ();
		if (getClass () == AppIntroBase_PagerOnPageChangeListener.class)
			mono.android.TypeManager.Activate ("AppIntro.AppIntroBase+PagerOnPageChangeListener, AppIntro", "", this, new java.lang.Object[] {  });
	}

	public AppIntroBase_PagerOnPageChangeListener (crc64bffd170a4ccc07dd.AppIntroBase p0)
	{
		super ();
		if (getClass () == AppIntroBase_PagerOnPageChangeListener.class)
			mono.android.TypeManager.Activate ("AppIntro.AppIntroBase+PagerOnPageChangeListener, AppIntro", "AppIntro.AppIntroBase, AppIntro", this, new java.lang.Object[] { p0 });
	}


	public void onPageScrollStateChanged (int p0)
	{
		n_onPageScrollStateChanged (p0);
	}

	private native void n_onPageScrollStateChanged (int p0);


	public void onPageScrolled (int p0, float p1, int p2)
	{
		n_onPageScrolled (p0, p1, p2);
	}

	private native void n_onPageScrolled (int p0, float p1, int p2);


	public void onPageSelected (int p0)
	{
		n_onPageSelected (p0);
	}

	private native void n_onPageSelected (int p0);

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
