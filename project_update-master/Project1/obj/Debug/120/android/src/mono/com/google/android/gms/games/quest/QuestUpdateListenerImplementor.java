package mono.com.google.android.gms.games.quest;


public class QuestUpdateListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.games.quest.QuestUpdateListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onQuestCompleted:(Lcom/google/android/gms/games/quest/Quest;)V:GetOnQuestCompleted_Lcom_google_android_gms_games_quest_Quest_Handler:Android.Gms.Games.Quest.IQuestUpdateListenerInvoker, Xamarin.GooglePlayServices.Games\n" +
			"";
		mono.android.Runtime.register ("Android.Gms.Games.Quest.IQuestUpdateListenerImplementor, Xamarin.GooglePlayServices.Games", QuestUpdateListenerImplementor.class, __md_methods);
	}


	public QuestUpdateListenerImplementor ()
	{
		super ();
		if (getClass () == QuestUpdateListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Gms.Games.Quest.IQuestUpdateListenerImplementor, Xamarin.GooglePlayServices.Games", "", this, new java.lang.Object[] {  });
	}


	public void onQuestCompleted (com.google.android.gms.games.quest.Quest p0)
	{
		n_onQuestCompleted (p0);
	}

	private native void n_onQuestCompleted (com.google.android.gms.games.quest.Quest p0);

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
