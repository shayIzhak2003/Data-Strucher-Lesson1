using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes
{
    //EX5

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

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point other = (Point)obj;
                return this.x == other.x && this.y == other.y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }

        public override string ToString()
        {
            return $"({this.x}, {this.y})";
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

        public override string ToString()
        {
            return $"Center: {this.center}, Radius: {this.radius}";
        }
    }
}
