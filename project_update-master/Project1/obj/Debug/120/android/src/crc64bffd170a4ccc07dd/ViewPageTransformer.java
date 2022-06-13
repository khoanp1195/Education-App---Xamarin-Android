package crc64bffd170a4ccc07dd;


public class ViewPageTransformer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.viewpager.widget.ViewPager.PageTransformer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_transformPage:(Landroid/view/View;F)V:GetTransformPage_Landroid_view_View_FHandler:AndroidX.ViewPager.Widget.ViewPager/IPageTransformerInvoker, Xamarin.AndroidX.ViewPager\n" +
			"";
		mono.android.Runtime.register ("AppIntro.ViewPageTransformer, AppIntro", ViewPageTransformer.class, __md_methods);
	}


	public ViewPageTransformer ()
	{
		super ();
		if (getClass () == ViewPageTransformer.class)
			mono.android.TypeManager.Activate ("AppIntro.ViewPageTransformer, AppIntro", "", this, new java.lang.Object[] {  });
	}

	public ViewPageTransformer (int p0)
	{
		super ();
		if (getClass () == ViewPageTransformer.class)
			mono.android.TypeManager.Activate ("AppIntro.ViewPageTransformer, AppIntro", "AppIntro.TransformType, AppIntro", this, new java.lang.Object[] { p0 });
	}


	public void transformPage (android.view.View p0, float p1)
	{
		n_transformPage (p0, p1);
	}

	private native void n_transformPage (android.view.View p0, float p1);

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
