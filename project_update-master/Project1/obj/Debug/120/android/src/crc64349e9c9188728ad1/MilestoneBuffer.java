package crc64349e9c9188728ad1;


public class MilestoneBuffer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.lang.Iterable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_iterator:()Ljava/util/Iterator;:GetIteratorHandler:Java.Lang.IIterableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_forEach:(Ljava/util/function/Consumer;)V:GetForEach_Ljava_util_function_Consumer_Handler:Java.Lang.IIterable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_spliterator:()Ljava/util/Spliterator;:GetSpliteratorHandler:Java.Lang.IIterable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Android.Gms.Games.Quest.MilestoneBuffer, Xamarin.GooglePlayServices.Games", MilestoneBuffer.class, __md_methods);
	}


	public MilestoneBuffer ()
	{
		super ();
		if (getClass () == MilestoneBuffer.class)
			mono.android.TypeManager.Activate ("Android.Gms.Games.Quest.MilestoneBuffer, Xamarin.GooglePlayServices.Games", "", this, new java.lang.Object[] {  });
	}


	public java.util.Iterator iterator ()
	{
		return n_iterator ();
	}

	private native java.util.Iterator n_iterator ();


	public void forEach (java.util.function.Consumer p0)
	{
		n_forEach (p0);
	}

	private native void n_forEach (java.util.function.Consumer p0);


	public java.util.Spliterator spliterator ()
	{
		return n_spliterator ();
	}

	private native java.util.Spliterator n_spliterator ();

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
