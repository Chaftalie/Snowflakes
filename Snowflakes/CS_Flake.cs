using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snowflakes
{
    public class Flake
    {
        Vector2 position;
        Vector2 velocity;
        Vector2 acceleration;
        int maxForce;
        int maxSpeed;


        Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public int Width { get; }
        public int Height { get; }
        public Flake(int width, int height)
        {
            Width = width;
            Height = height;
            position = new Vector2(rnd.Next(width), rnd.Next(height));
            velocity = new Vector2((float)rnd.Next(100,200) / (float)100, (float)rnd.Next(100, 200) / (float)100);
            acceleration = new Vector2();
            maxForce = 1;
            maxSpeed = 4;
        }

        public void edges()
        {
            if (position.X > Width)
            {
                position.X = 0;
            }
            else if (position.X < 0)
            {
                position.X = Width;
            }
            if (position.Y > Height)
            {
                position.Y = 0;
            }
            else if (position.Y < 0)
            {
                position.Y = Height;
            }
        }

        public void Update()
        {
            position += velocity;
            velocity += acceleration;
            velocity = Vector2.Clamp(velocity, new Vector2(0), new Vector2(maxSpeed));
            acceleration *= 0;
        }

        
        public void show(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.White, position.X, position.Y, rnd.Next(1,5), rnd.Next(1, 5));
        }
    }
}
