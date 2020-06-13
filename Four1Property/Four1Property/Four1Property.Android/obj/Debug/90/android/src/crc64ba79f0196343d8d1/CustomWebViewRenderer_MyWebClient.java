package crc64ba79f0196343d8d1;


public class CustomWebViewRenderer_MyWebClient
	extends android.webkit.WebChromeClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPermissionRequest:(Landroid/webkit/PermissionRequest;)V:GetOnPermissionRequest_Landroid_webkit_PermissionRequest_Handler\n" +
			"";
		mono.android.Runtime.register ("Four1Property.Droid.Renders.CustomWebViewRenderer+MyWebClient, Four1Property.Android", CustomWebViewRenderer_MyWebClient.class, __md_methods);
	}


	public CustomWebViewRenderer_MyWebClient ()
	{
		super ();
		if (getClass () == CustomWebViewRenderer_MyWebClient.class)
			mono.android.TypeManager.Activate ("Four1Property.Droid.Renders.CustomWebViewRenderer+MyWebClient, Four1Property.Android", "", this, new java.lang.Object[] {  });
	}

	public CustomWebViewRenderer_MyWebClient (android.app.Activity p0)
	{
		super ();
		if (getClass () == CustomWebViewRenderer_MyWebClient.class)
			mono.android.TypeManager.Activate ("Four1Property.Droid.Renders.CustomWebViewRenderer+MyWebClient, Four1Property.Android", "Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	@android.annotation.TargetApi(
value = 21)

	public void onPermissionRequest (android.webkit.PermissionRequest p0)
	{
		n_onPermissionRequest (p0);
	}

	private native void n_onPermissionRequest (android.webkit.PermissionRequest p0);

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
