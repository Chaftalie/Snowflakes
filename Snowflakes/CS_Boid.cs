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
    public class Boid
    {
        Vector2 position;
        Vector2 velocity;
        Vector2 acceleration;
        int maxForce;
        int maxSpeed;


        Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public int Width { get; }
        public int Height { get; }
        public float AlignValue { get; }
        public float CohesionValue { get; }
        public float SeperationValue { get; }
        public Vector2 Position { get => position; }
        public Vector2 Velocity { get => velocity; }
        public Vector2 Acceleration { get => acceleration; }
        public int MaxForce { get => maxForce; set => maxForce = value; }
        public int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }

        public Boid(int width, int height, float alignValue, float cohesionValue, float seperationValue)
        {
            Width = width;
            Height = height;
            AlignValue = alignValue;
            CohesionValue = cohesionValue;
            SeperationValue = seperationValue;
            this.position = new Vector2(rnd.Next(width), rnd.Next(height));
            this.velocity = new Vector2((float)rnd.Next(100) / (float)100, (float)rnd.Next(100) / (float)100);
            //this.velocity.setMag(random(2, 4));
            this.acceleration = new Vector2();
            this.maxForce = 1;
            this.maxSpeed = 4;
        }

        public void edges()
        {
            if (this.position.X > Width)
            {
                this.position.X = 0;
            }
            else if (this.position.X < 0)
            {
                this.position.X = Width;
            }
            if (this.position.Y > Height)
            {
                this.position.Y = 0;
            }
            else if (this.position.Y < 0)
            {
                this.position.Y = Height;
            }
        }

        public void Update()
        {
            this.position += this.velocity;
            this.velocity += this.acceleration;
            this.velocity = Vector2.Clamp(velocity, new Vector2(0), new Vector2(maxSpeed));
            this.acceleration *= 0;
        }

        
        public void show(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.White, this.position.X, this.position.Y, rnd.Next(1,5), rnd.Next(1, 5));
        }
    }
}
