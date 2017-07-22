﻿using UIKit;
using Foundation;

namespace SaveImageToDatabaseSampleApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
		{
			
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			global::Xamarin.Forms.Forms.Init();
			EntryCustomReturn.Forms.Plugin.iOS.CustomReturnEntryRenderer.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(uiApplication, launchOptions);
		}
	}
}
