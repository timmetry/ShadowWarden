using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ShadowWarden
{
    public class Vect2
    {
        public double x;
        public double y;

        /// <summary>
        /// Magnitude of a vector: its length calculated by the Pythagorean Theorem
        /// </summary>
        public double M { get { return Math.Sqrt(x * x + y * y); } }

        public Vect2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vect2 Zero
        { get { return new Vect2(0, 0); } }
        public static Vect2 Unit
        { get { return new Vect2(1, 1); } }

        public static Vect2 operator +(Vect2 a, Vect2 b)
        { return new Vect2(a.x + b.x, a.y + b.y); }
        public static Vect2 operator -(Vect2 a, Vect2 b)
        { return new Vect2(a.x - b.x, a.y - b.y); }
        public static Vect2 operator *(Vect2 a, double b)
        { return new Vect2(a.x * b, a.y * b); }
        public static Vect2 operator /(Vect2 a, double b)
        { return new Vect2(a.x / b, a.y / b); }
        public static Vect2 operator *(double a, Vect2 b)
        { return new Vect2(a * b.x, a * b.y); }
        public static Vect2 operator /(double a, Vect2 b)
        { return new Vect2(a / b.x, a / b.y); }
    }

    public class Vect3
    {
        public double x;
        public double y;
        public double u; // Horizontal extra-dimension: blue to red

        /// <summary>
        /// Magnitude of a vector: its length calculated by the Pythagorean Theorem
        /// </summary>
        public double M { get { return Math.Sqrt(x * x + y * y + u * u); } }

        public Vect3(double x, double y, double u)
        {
            this.x = x;
            this.y = y;
            this.u = u;
        }

        public static Vect3 Zero
        { get { return new Vect3(0, 0, 0); } }
        public static Vect3 Unit
        { get { return new Vect3(1, 1, 1); } }

        public static Vect3 operator +(Vect3 a, Vect3 b)
        { return new Vect3(a.x + b.x, a.y + b.y, a.u + b.u); }
        public static Vect3 operator -(Vect3 a, Vect3 b)
        { return new Vect3(a.x - b.x, a.y - b.y, a.u - b.u); }

        public static Vect3 operator +(Vect3 a, Vect2 b)
        { return new Vect3(a.x + b.x, a.y + b.y, a.u); }
        public static Vect3 operator +(Vect2 a, Vect3 b)
        { return new Vect3(a.x + b.x, a.y + b.y, b.u); }
        public static Vect3 operator -(Vect3 a, Vect2 b)
        { return new Vect3(a.x - b.x, a.y - b.y, a.u); }
        public static Vect3 operator -(Vect2 a, Vect3 b)
        { return new Vect3(a.x - b.x, a.y - b.y, b.u); }

        public static Vect3 operator *(Vect3 a, double b)
        { return new Vect3(a.x * b, a.y * b, a.u * b); }
        public static Vect3 operator /(Vect3 a, double b)
        { return new Vect3(a.x / b, a.y / b, a.u / b); }
        public static Vect3 operator *(double a, Vect3 b)
        { return new Vect3(a * b.x, a * b.y, a * b.u); }
        public static Vect3 operator /(double a, Vect3 b)
        { return new Vect3(a / b.x, a / b.y, a / b.u); }
    }

    public class Vect4
    {
        public double x;
        public double y;
        public double u; // Horizontal extra-dimension: blue to red
        public double v; // Vertical extra-dimension: green to yellow

        /// <summary>
        /// Magnitude of a vector: its length calculated by the Pythagorean Theorem
        /// </summary>
        public double M { get { return Math.Sqrt(x * x + y * y + u * u + v * v); } }

        public Vect4(double x, double y, double u, double v)
        {
            this.x = x;
            this.y = y;
            this.u = u;
            this.v = v;
        }

        public static Vect4 Zero
        { get { return new Vect4(0, 0, 0, 0); } }
        public static Vect4 Unit
        { get { return new Vect4(1, 1, 1, 1); } }

        public static Vect4 operator +(Vect4 a, Vect4 b)
        { return new Vect4(a.x + b.x, a.y + b.y, a.u + b.u, a.v + b.v); }
        public static Vect4 operator -(Vect4 a, Vect4 b)
        { return new Vect4(a.x - b.x, a.y - b.y, a.u - b.u, a.v - b.v); }

        public static Vect4 operator +(Vect4 a, Vect3 b)
        { return new Vect4(a.x + b.x, a.y + b.y, a.u + b.u, a.v); }
        public static Vect4 operator +(Vect3 a, Vect4 b)
        { return new Vect4(a.x + b.x, a.y + b.y, a.u + b.u, b.v); }
        public static Vect4 operator -(Vect4 a, Vect3 b)
        { return new Vect4(a.x - b.x, a.y - b.y, a.u - b.u, a.v); }
        public static Vect4 operator -(Vect3 a, Vect4 b)
        { return new Vect4(a.x - b.x, a.y - b.y, a.u - b.u, b.v); }

        public static Vect4 operator +(Vect4 a, Vect2 b)
        { return new Vect4(a.x + b.x, a.y + b.y, a.u, a.v); }
        public static Vect4 operator +(Vect2 a, Vect4 b)
        { return new Vect4(a.x + b.x, a.y + b.y, b.u, b.v); }
        public static Vect4 operator -(Vect4 a, Vect2 b)
        { return new Vect4(a.x - b.x, a.y - b.y, a.u, a.v); }
        public static Vect4 operator -(Vect2 a, Vect4 b)
        { return new Vect4(a.x - b.x, a.y - b.y, b.u, b.v); }

        public static Vect4 operator *(Vect4 a, double b)
        { return new Vect4(a.x * b, a.y * b, a.u * b, a.v * b); }
        public static Vect4 operator /(Vect4 a, double b)
        { return new Vect4(a.x / b, a.y / b, a.u / b, a.v / b); }
        public static Vect4 operator *(double a, Vect4 b)
        { return new Vect4(a * b.x, a * b.y, a * b.u, a * b.v); }
        public static Vect4 operator /(double a, Vect4 b)
        { return new Vect4(a / b.x, a / b.y, a / b.u, a / b.v); }
    }
}
