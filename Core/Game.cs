#pragma warning disable 1998

using System;
using System.Diagnostics;
using Urho;
using Urho.Gui;
using Urho.Shapes;
using Urho.Urho2D;

namespace UrhoTest
{
	public class Balloon : Component
	{
		public void Place(Vector2 position)
		{
			Node.Position = new Vector3(position);
			var sprite = Node.CreateComponent<StaticSprite2D>();
			sprite.Sprite = Application.ResourceCache.GetSprite2D("Images/Balloons_01_64x64_Alt_00_001.png");
		}
	}

	public class Game: Application
	{
		public Game() : base(new ApplicationOptions(assetsFolder: "Data") { Height = 1024, Width = 576, Orientation = ApplicationOptions.OrientationType.Portrait }) { }

		public Game(ApplicationOptions opts) : base(opts) { }

		static Game()
		{
			UnhandledException += (s, e) =>
			{
				if (Debugger.IsAttached)
				{
					Debug.WriteLine(e.Exception.Message);
					Debugger.Break();
				}
				e.Handled = true;
			};
		}

		protected override void Start()
		{
			base.Start();
			CreateScene();
		}

		async void CreateScene()
		{
			Scene scene = new Scene();
			scene.CreateComponent<Octree>();
			scene.CreateComponent<DebugRenderer>();

			var cameraNode = scene.CreateChild("Camera");
			var camera = cameraNode.CreateComponent<Camera>();
			cameraNode.Position = new Vector3(0, 0, -10);
			camera.Orthographic = true;
			camera.OrthoSize = Graphics.Height * PixelSize;

			var balloonNode = scene.CreateChild("Balloon");
			var balloon = balloonNode.CreateComponent<Balloon>();
			balloon.Place(new Vector2(0, 0));

			Renderer.SetViewport(0, new Viewport(Context, scene, camera, null)); 
		}
	}
}
