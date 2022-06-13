package crc64bffd170a4ccc07dd;


public abstract class AppIntro
	extends crc64bffd170a4ccc07dd.AppIntroBase
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AppIntro.AppIntro, AppIntro", AppIntro.class, __md_methods);
	}


	public AppIntro ()
	{
		super ();
		if (getClass () == AppIntro.class)
			mono.android.TypeManager.Activate ("AppIntro.AppIntro, AppIntro", "", this, new java.lang.Object[] {  });
	}


	public AppIntro (int p0)
	{
		super (p0);
		if (getClass () == AppIntro.class)
			mono.android.TypeManager.Activate ("AppIntro.AppIntro, AppIntro", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
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
