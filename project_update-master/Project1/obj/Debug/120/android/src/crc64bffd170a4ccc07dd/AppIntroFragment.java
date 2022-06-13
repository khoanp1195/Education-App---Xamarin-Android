package crc64bffd170a4ccc07dd;


public class AppIntroFragment
	extends crc64bffd170a4ccc07dd.AppIntroBaseFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AppIntro.AppIntroFragment, AppIntro", AppIntroFragment.class, __md_methods);
	}


	public AppIntroFragment ()
	{
		super ();
		if (getClass () == AppIntroFragment.class)
			mono.android.TypeManager.Activate ("AppIntro.AppIntroFragment, AppIntro", "", this, new java.lang.Object[] {  });
	}


	public AppIntroFragment (int p0)
	{
		super (p0);
		if (getClass () == AppIntroFragment.class)
			mono.android.TypeManager.Activate ("AppIntro.AppIntroFragment, AppIntro", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}

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
