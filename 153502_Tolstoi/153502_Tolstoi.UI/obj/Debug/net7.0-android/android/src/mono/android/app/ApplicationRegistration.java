package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("_153502_Tolstoi.UI.MainApplication, 153502_Tolstoi.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64db36c6cfed522230.MainApplication.class, crc64db36c6cfed522230.MainApplication.__md_methods);
		mono.android.Runtime.register ("Microsoft.Maui.MauiApplication, Microsoft.Maui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc6488302ad6e9e4df1a.MauiApplication.class, crc6488302ad6e9e4df1a.MauiApplication.__md_methods);
		
	}
}
