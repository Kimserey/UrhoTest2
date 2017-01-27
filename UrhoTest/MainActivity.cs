using Android.App;
using Android.Widget;
using Android.OS;
using Urho.Droid;
using Urho;

namespace UrhoTest
{
	[Activity(Label = "GameTest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			UrhoSurface.RunInActivity<Game>(
				new ApplicationOptions("Data") { 
					Orientation = ApplicationOptions.OrientationType.Portrait 
				}
			);
		}
	}
}