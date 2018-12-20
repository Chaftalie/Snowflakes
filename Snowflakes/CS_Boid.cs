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

        Vector2 align(Boid[] boids)
        {
            int perceptionRadius = 50;
            Vector2 steering = new Vector2();
            int total = 0;
            foreach (Boid other in boids)
            {
                float d = Vector2.Distance(this.position, other.position);
                if (other != this && d < perceptionRadius)
                {
                    steering += other.velocity;
                    total++;
                }
            }
            if (total > 0)
            {
                steering /= total;
                //steering.setMag(this.maxSpeed);
                steering -= this.velocity;
                steering = Vector2.Clamp(velocity, new Vector2(0), new Vector2(maxForce));
            }
            return steering;
        }

        Vector2 separation(Boid[] boids)
        {
            int perceptionRadius = 50;
            Vector2 steering = new Vector2();
            int total = 0;
            foreach (Boid other in boids)
            {
                float d = Vector2.Distance(this.position, other.position);
                if (other != this && d < perceptionRadius)
                {
                    Vector2 diff = this.position - other.position;
                    diff /= (d * d);
                    steering += diff;
                    total++;
                }
            }
            if (total > 0)
            {
                steering /= total;
                //steering.setMag(this.maxSpeed);
                steering -= this.velocity;
                steering = Vector2.Clamp(velocity, new Vector2(0), new Vector2(maxForce));
            }
            return steering;
        }

        Vector2 cohesion(Boid[] boids)
        {
            int perceptionRadius = 100;
            Vector2 steering = new Vector2();
            int total = 0;
            foreach (Boid other in boids)
            {
                float d = Vector2.Distance(this.position, other.position);
                if (other != this && d < perceptionRadius)
                {
                    steering += other.position;
                    total++;
                }
            }
            if (total > 0)
            {
                steering /= total;
                steering -= this.position;
                //steering.setMag(this.maxSpeed);
                steering -= this.velocity;
                steering = Vector2.Clamp(velocity, new Vector2(0), new Vector2(maxForce));
            }
            return steering;
        }

        public void flock(Boid[] boids)
        {
            Vector2 alignment = this.align(boids);
            Vector2 cohesion = this.cohesion(boids);
            Vector2 separation = this.separation(boids);

            alignment *= AlignValue;
            cohesion *= CohesionValue;
            separation *= SeperationValue;

            this.acceleration += alignment;
            this.acceleration += cohesion;
            this.acceleration += separation;
        }

        public void update()
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
