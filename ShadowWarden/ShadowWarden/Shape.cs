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
    public abstract class Shape
    {
        public abstract Rect4 TestCollision(Point2 b, Vect4 mov);
        public abstract Rect4 TestCollision(Point3 b, Vect4 mov);
        public abstract Rect4 TestCollision(Point4 b, Vect4 mov);

        public abstract Rect4 TestCollision(Rect2 b, Vect4 mov);
        public abstract Rect4 TestCollision(Rect3 b, Vect4 mov);
        public abstract Rect4 TestCollision(Rect4 b, Vect4 mov);
    }

    public class Point2 : Shape
    {
        public Vect2 pos;

        public Point2() { }
        public Point2(Vect2 pos)
        {
            this.pos = pos;
        }
        public Point2(double x, double y)
        {
            this.pos = new Vect2(x, y);
        }

        public override Rect4 TestCollision(Point2 b, Vect4 mov)
        { return Rect4.Zero; }
        public override Rect4 TestCollision(Point3 b, Vect4 mov)
        { return new HitBox(pos.x + mov.x == b.pos.x && pos.y + mov.y == b.pos.y); }
        public override Rect4 TestCollision(Point4 b, Vect4 mov)
        { return new HitBox(pos.x + mov.x == b.pos.x && pos.y + mov.y == b.pos.y); }

        public override Rect4 TestCollision(Rect2 r, Vect4 mov)
        {
            if (pos.x + mov.x >= r.pos.x && pos.x + mov.x <= r.size.x &&
                pos.y + mov.y >= r.pos.y && pos.y + mov.y <= r.size.y)
            {
            }
        }
    }

    public class Point3 : Shape
    {
        public Vect3 pos;

        public Point3() { }
        public Point3(Vect3 pos)
        {
            this.pos = pos;
        }
        public Point3(double x, double y, double u)
        {
            this.pos = new Vect3(x, y, u);
        }
    }

    public class Point4 : Shape
    {
        public Vect4 pos;

        public Point4() { }
        public Point4(Vect4 pos)
        {
            this.pos = pos;
        }
        public Point4(double x, double y, double u, double v)
        {
            this.pos = new Vect4(x, y, u, v);
        }
    }

    public class Rect2 : Shape
    {
        public Vect2 pos;
        public Vect2 size;

        public double Left { get { return pos.x; } set { pos.x = value; } }
        public double Top { get { return pos.y; } set { pos.y = value; } }
        public double Width { get { return size.x; } }
        public double Height { get { return size.y; } }
        public double Right { get { return pos.x + size.x; } set { pos.x = value - size.x; } }
        public double Bottom { get { return pos.y + size.y; } set { pos.y = value - size.y; } }

        public Vect2 Center { get { return pos + (size / 2); } set { pos = value - (size / 2); } }

        public Rect2() { }
        public Rect2(Vect2 pos, Vect2 size)
        {
            this.pos = pos;
            this.size = size;
        }
        public Rect2(double x, double y, double width, double height)
        {
            this.pos = new Vect2(x, y);
            this.size = new Vect2(width, height);
        }
    }

    public class Rect3 : Shape
    {
        public Vect3 pos;
        public Vect3 size;

        public double Left { get { return pos.x; } set { pos.x = value; } }
        public double Top { get { return pos.y; } set { pos.y = value; } }
        public double Width { get { return size.x; } }
        public double Height { get { return size.y; } }
        public double Right { get { return pos.x + size.x; } set { pos.x = value - size.x; } }
        public double Bottom { get { return pos.y + size.y; } set { pos.y = value - size.y; } }

        public Vect3 Center { get { return pos + (size / 2); } set { pos = value - (size / 2); } }

        public Rect3() { }
        public Rect3(Vect3 pos, Vect3 size)
        {
            this.pos = pos;
            this.size = size;
        }
        public Rect3(double x, double y, double u, double width, double height, double uWidth)
        {
            this.pos = new Vect3(x, y, u);
            this.size = new Vect3(width, height, uWidth);
        }
    }

    public class Rect4 : Shape
    {
        public Vect4 pos;
        public Vect4 size;

        public double Left { get { return pos.x; } set { pos.x = value; } }
        public double Top { get { return pos.y; } set { pos.y = value; } }
        public double Width { get { return size.x; } }
        public double Height { get { return size.y; } }
        public double Right { get { return pos.x + size.x; } set { pos.x = value - size.x; } }
        public double Bottom { get { return pos.y + size.y; } set { pos.y = value - size.y; } }

        public Vect4 Pos2 { get { return pos + size; } set { pos = value - size; } }
        public Vect4 Center { get { return pos + (size / 2); } set { pos = value - (size / 2); } }

        public Rect4() { }
        public Rect4(Vect4 pos, Vect4 size)
        {
            this.pos = pos;
            this.size = size;
        }
        public Rect4(double x, double y, double u, double v, double width, double height, double uWidth, double vHeight)
        {
            this.pos = new Vect4(x, y, u, v);
            this.size = new Vect4(width, height, uWidth, vHeight);
        }
    }
}