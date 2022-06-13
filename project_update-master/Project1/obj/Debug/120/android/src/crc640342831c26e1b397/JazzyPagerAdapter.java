package crc640342831c26e1b397;


public abstract class JazzyPagerAdapter
	extends androidx.viewpager.widget.PagerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_isViewFromObject:(Landroid/view/View;Ljava/lang/Object;)Z:GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("Jazzy.JazzyPagerAdapter, JazzyViewPager", JazzyPagerAdapter.class, __md_methods);
	}


	public JazzyPagerAdapter ()
	{
		super ();
		if (getClass () == JazzyPagerAdapter.class)
			mono.android.TypeManager.Activate ("Jazzy.JazzyPagerAdapter, JazzyViewPager", "", this, new java.lang.Object[] {  });
	}

	public JazzyPagerAdapter (crc640342831c26e1b397.JazzyViewPager p0)
	{
		super ();
		if (getClass () == JazzyPagerAdapter.class)
			mono.android.TypeManager.Activate ("Jazzy.JazzyPagerAdapter, JazzyViewPager", "Jazzy.JazzyViewPager, JazzyViewPager", this, new java.lang.Object[] { p0 });
	}


	public boolean isViewFromObject (android.view.View p0, java.lang.Object p1)
	{
		return n_isViewFromObject (p0, p1);
	}

	private native boolean n_isViewFromObject (android.view.View p0, java.lang.Object p1);

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
