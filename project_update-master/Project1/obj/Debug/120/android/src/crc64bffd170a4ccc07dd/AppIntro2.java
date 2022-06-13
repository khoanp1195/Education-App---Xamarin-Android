package crc64bffd170a4ccc07dd;


public class AppIntro2
	extends crc64bffd170a4ccc07dd.AppIntroBase
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AppIntro.AppIntro2, AppIntro", AppIntro2.class, __md_methods);
	}


	public AppIntro2 ()
	{
		super ();
		if (getClass () == AppIntro2.class)
			mono.android.TypeManager.Activate ("AppIntro.AppIntro2, AppIntro", "", this, new java.lang.Object[] {  });
	}


	public AppIntro2 (int p0)
	{
		super (p0);
		if (getClass () == AppIntro2.class)
			mono.android.TypeManager.Activate ("AppIntro.AppIntro2, AppIntro", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
