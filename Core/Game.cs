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

			var planeNode = scene.CreateChild("Plane");
			var plane = planeNode.CreateComponent<StaticModel>();
			plane.Model = ResourceCache.GetModel("Models/Plane.mdl");
			plane.SetMaterial(ResourceCache.GetMaterial("Materials/StoneTiled.xml"));
			planeNode.Scale = new Vector3(100, 1, 100); 
			planeNode.Position = new Vector3(10, 10, 10);
			         
			var lightNode = scene.CreateChild("DirectionalLight");
			lightNode.SetDirection(new Vector3(0.6f, -1.0f, 0.8f));
			lightNode.CreateComponent<Light>();

			var cameraNode = scene.CreateChild("camera");
			var camera = cameraNode.CreateComponent<Camera>();
			cameraNode.Position = (new Vector3(0.0f, 0.0f, -10.0f));

			Renderer.SetViewport(0, new Viewport(Context, scene, camera, null));
		}
	}
}
