package crc645e1f78be6b80dd76;


public class XamarinAdapter_XamarinAdapterViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Project1.Adapter.XamarinAdapter+XamarinAdapterViewHolder, Project1", XamarinAdapter_XamarinAdapterViewHolder.class, __md_methods);
	}


	public XamarinAdapter_XamarinAdapterViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == XamarinAdapter_XamarinAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("Project1.Adapter.XamarinAdapter+XamarinAdapterViewHolder, Project1", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
