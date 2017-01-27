using System;
using Urho.Desktop;

namespace UrhoTest.Console
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			DesktopUrhoInitializer.AssetsDirectory = @"../../../Assets";
			new Game().Run();	
		}
	}
}
