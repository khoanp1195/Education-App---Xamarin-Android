package crc647a6e61ec2accee13;


public class ViewHolder1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Project1.Common.ViewHolder1, Project1", ViewHolder1.class, __md_methods);
	}


	public ViewHolder1 ()
	{
		super ();
		if (getClass () == ViewHolder1.class)
			mono.android.TypeManager.Activate ("Project1.Common.ViewHolder1, Project1", "", this, new java.lang.Object[] {  });
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
