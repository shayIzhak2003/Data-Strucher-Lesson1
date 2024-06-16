using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure_Lesson1.Classes
{
    // EX4

    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX()
        {
            return this.x;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public int GetY()
        {
            return this.y;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public bool Equals(Point other)
        {
            if (other == null) return false;
            return this.x == other.x && this.y == other.y;
        }

        public override string ToString()
        {
            return $"({this.x}, {this.y})";
        }

        // New GetValue method
        public Point GetValue()
        {
            return this;
        }
    }

    public class Circle
    {
        private Point center;
        private int radius;

        public Circle(Point center, int radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public Point GetCenter()
        {
            return this.center;
        }

        public void SetCenter(Point center)
        {
            this.center = center;
        }

        public int GetRadius()
        {
            return this.radius;
        }

        public void SetRadius(int radius)
        {
            this.radius = radius;
        }

        public bool Equals(Circle other)
        {
            if (other == null) return false;
            return this.radius == other.radius && this.center.Equals(other.center);
        }

        public override string ToString()
        {
            return $"Center: {this.center}, Radius: {this.radius}";
        }
    }
}
