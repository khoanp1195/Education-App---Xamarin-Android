package crc641699dd8f574e7cae;


public class UserAddQuestion_CountDown
	extends android.os.CountDownTimer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFinish:()V:GetOnFinishHandler\n" +
			"n_onTick:(J)V:GetOnTick_JHandler\n" +
			"";
		mono.android.Runtime.register ("Project1.Acitivties.ActivitiesPlaying.UserAddQuestion+CountDown, Project1", UserAddQuestion_CountDown.class, __md_methods);
	}


	public UserAddQuestion_CountDown (long p0, long p1)
	{
		super (p0, p1);
		if (getClass () == UserAddQuestion_CountDown.class)
			mono.android.TypeManager.Activate ("Project1.Acitivties.ActivitiesPlaying.UserAddQuestion+CountDown, Project1", "System.Int64, mscorlib:System.Int64, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public void onFinish ()
	{
		n_onFinish ();
	}

	private native void n_onFinish ();


	public void onTick (long p0)
	{
		n_onTick (p0);
	}

	private native void n_onTick (long p0);

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
