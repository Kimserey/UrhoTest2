#pragma warning disable 1998

using System;
using System.Diagnostics;
using Urho;
using Urho.Gui;

namespace UrhoTest
{
	public class Game: Application
	{
		public Game() : base(new ApplicationOptions(assetsFolder: "Data") { Height = 1024, Width = 576, Orientation = ApplicationOptions.OrientationType.Portrait }) { }

		public Game(ApplicationOptions opts) : base(opts) { }

		static Game()
		{
			UnhandledException += (s, e) =>
			{
				if (Debugger.IsAttached)
					Debugger.Break();
				e.Handled = true;
			};
		}

		protected override void Start()
		{
			base.Start();
			CreateScene();
		}

		Scene _scene;
		Text _helloWorld;

		async void CreateScene()
		{
			_scene = new Scene();
			_scene.CreateComponent<Octree>();

			_helloWorld = new Text { 
				Value = "Hello world",
				HorizontalAlignment = HorizontalAlignment.Center,
				VerticalAlignment = VerticalAlignment.Center
			};
			_helloWorld.SetColor(new Color(0f, 1f, 1f));
			_helloWorld.SetFont(
				ResourceCache.GetFont("Fonts/Font.ttf"), 
				20);
			UI.Root.AddChild(_helloWorld);
		}
	}
}
