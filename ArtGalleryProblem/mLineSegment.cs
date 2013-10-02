using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ArtGalleryProblem
{
    class mLineSegment
    {
        #region members, constructor, functions
        public Point start_point, end_point; // start and end of line segment

        public mLineSegment(Point start, Point end) // constructor
        {
            start_point = start;
            end_point = end;
        }

        public double get_lenght()  // find line's lenght
        {
            double d = (end_point.X - start_point.X) * (end_point.X - start_point.X);
            d += (end_point.Y - start_point.Y) * (end_point.Y - start_point.Y);
            d = Math.Sqrt(d);
            return d;
        }

        public double get_x_max() // maximum x point
        {
            return Math.Max(start_point.X,end_point.X);
        }
        public double get_x_min() // minumum x point
        {
            return  Math.Min(start_point.X, end_point.X);
        }
        public double get_y_max() // maximum y point
        {
            return Math.Max(start_point.Y, end_point.Y);
        }
        public double get_y_min() // minumum y point
        {
            return  Math.Min(start_point.Y, end_point.Y);
        }

        #endregion
    }
}
