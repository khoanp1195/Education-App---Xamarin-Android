package crc64c0f3cf89a950c20c;


public class MainBottomCurvedActivity
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer,
		com.google.android.material.bottomnavigation.BottomNavigationView.OnNavigationItemSelectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onNavigationItemSelected:(Landroid/view/MenuItem;)Z:GetOnNavigationItemSelected_Landroid_view_MenuItem_Handler:Google.Android.Material.BottomNavigation.BottomNavigationView/IOnNavigationItemSelectedListenerInvoker, Xamarin.Google.Android.Material\n" +
			"";
		mono.android.Runtime.register ("Project1.Activities.CurvedBottom.MainBottomCurvedActivity, Project1", MainBottomCurvedActivity.class, __md_methods);
	}


	public MainBottomCurvedActivity ()
	{
		super ();
		if (getClass () == MainBottomCurvedActivity.class)
			mono.android.TypeManager.Activate ("Project1.Activities.CurvedBottom.MainBottomCurvedActivity, Project1", "", this, new java.lang.Object[] {  });
	}


	public MainBottomCurvedActivity (int p0)
	{
		super (p0);
		if (getClass () == MainBottomCurvedActivity.class)
			mono.android.TypeManager.Activate ("Project1.Activities.CurvedBottom.MainBottomCurvedActivity, Project1", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onNavigationItemSelected (android.view.MenuItem p0)
	{
		return n_onNavigationItemSelected (p0);
	}

	private native boolean n_onNavigationItemSelected (android.view.MenuItem p0);

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
