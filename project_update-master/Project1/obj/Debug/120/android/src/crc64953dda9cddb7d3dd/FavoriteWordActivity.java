package crc64953dda9cddb7d3dd;


public class FavoriteWordActivity
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Project1.FavoriteWordActivity, Project1", FavoriteWordActivity.class, __md_methods);
	}


	public FavoriteWordActivity ()
	{
		super ();
		if (getClass () == FavoriteWordActivity.class)
			mono.android.TypeManager.Activate ("Project1.FavoriteWordActivity, Project1", "", this, new java.lang.Object[] {  });
	}


	public FavoriteWordActivity (int p0)
	{
		super (p0);
		if (getClass () == FavoriteWordActivity.class)
			mono.android.TypeManager.Activate ("Project1.FavoriteWordActivity, Project1", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
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
