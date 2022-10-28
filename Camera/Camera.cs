using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public sealed class Camera
    {
    private float zoom; // Camera Zoom
    public Matrix transform; // Matrix Transform
    public Vector2 pos; // Camera Position
    private float rotation; // Camera Rotation
    private Vector2 defaultPos;

    private Camera()
    {
        zoom = 1.0f;
        rotation = 0.0f;
        pos = new Vector2(400.0f, 250.0f);
        defaultPos = new Vector2(400.0f, 250.0f);
    }
    private static Camera instance = new Camera();
    public static Camera Instance { get { return instance; } }
    // Sets and gets zoom
    public float Zoom
    {
        get { return zoom; }
        set { zoom = value; if (zoom < 0.1f) zoom = 0.1f; } // Negative zoom will flip image
    }

    public float Rotation
    {
        get { return rotation; }
        set { rotation = value; }
    }

    public void Move(Vector2 amount)
    {
        pos = defaultPos;
        pos += amount;
    }

    public void reset()
    {
        pos = new Vector2(400.0f, 250.0f);
        zoom = 1.0f;
        rotation = 0.0f;
    }

    public Matrix getTransformation(GraphicsDevice graphicsDevice)
    {
        transform =       // Thanks to o KB o for this solution
          Matrix.CreateTranslation(new Vector3(-pos.X, -pos.Y, 0)) *
                                     Matrix.CreateRotationZ(Rotation) *
                                     Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                     Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));
        return transform;
    }
}

