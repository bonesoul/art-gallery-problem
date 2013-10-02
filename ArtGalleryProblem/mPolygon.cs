using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ArtGalleryProblem
{
    public enum VertexType
    {
        ErrorPoint,
        ConvexPoint,
        ConcavePoint
    }
    public enum PolygonDirection
    {
        Unknown,
        Clockwise,
        Count_Clockwise
    }

    class mPolygon
    {
        #region members , constructor
        private Point[] vertices; // polygon's vertices as points

        public mPolygon(Point[] points) // constructor
        {
            if (points.Length < 3) // polygon needs at least 3 points
                return;

            vertices = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                vertices[i] = points[i];
            }
        }
        #endregion

        #region misc. functions
        public override string ToString() // returns 3.points of polygon as string
        {
            return "{" + vertices[0] + "," + vertices[1] + "," + vertices[2];
        }
        #endregion

        #region geometric functions

        public Boolean is_vertex(Point p) // check given point is vertex of the polygon
        {
            if (vertex_index(p) != -1)
                return true;
            else
                return false;
        }

        public int vertex_index(Point p) // returns given points vertex index
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i] == p)
                {
                    return i;
                }
            }
            return -1;
        }

        public VertexType vertex_type(Point p) // returns given points vertex type
        {
            if (is_vertex(p)) // is it really a vertex?
            {
                Point curr_point = p;   // check point
                Point next_point = get_next_point(p); // next adjacent point
                Point prev_point = get_prev_point(p); // previous adjacent point

                Double area = PolygonArea(new Point[] { prev_point, curr_point, next_point }); // calculate polygon area

                if (area < 0)                       // convex
                    return VertexType.ConvexPoint;
                else if (area > 0)                  // concave
                    return VertexType.ConcavePoint;
            }

            return VertexType.ErrorPoint; // this is not a vertex!
        }

        public Point get_prev_point(Point p) // find previous. adjacent point to given one
        {
            int v_index;
            v_index = vertex_index(p);      // find given points vertex index
            if (v_index == -1)              // if it's -1, then there's no vertex point p
                return new Point(-1, -1);   // standing for null value
            else            
            {
                if (v_index == 0)                           // if given point is the first vertex of polygon
                    return vertices[vertices.Length - 1];   // return the last vertex of polygon
                else
                    return vertices[v_index - 1];           // return previous point
            }
        }

        public Point get_next_point(Point p)
        {
            int v_index;
            v_index = vertex_index(p);
            if (v_index == -1)
                return new Point(-1, -1); 
            else
            {
                if (v_index == vertices.Length - 1)         // if given point is the last vertex of polygon
                    return vertices[0];                     // return the first vertex of polygon
                else
                    return vertices[v_index + 1];           // return next point
            }
        }

        public static double PolygonArea(Point[] points)    // calculates the given points area
        {
            double area = 0;
            int j;

            for (int i = 0; i < points.Length; i++)
            {
                j = (i + 1) % points.Length;
                area += (points[i].X * points[j].Y);
                area -= (points[i].Y * points[j].X);
            }

            area /= 2;
            return area;
        }

        public static PolygonDirection get_direction(Point[] points) // find given points direction
        {
            if (points.Length < 3)
                return PolygonDirection.Unknown;    // we need at least 3 points!

            int len = points.Length;
            int j, k, count = 0;

            for (int i = 0; i < len; i++)   // loop through points
            {
                //    i         j       k
                // current -> next -> next
                j = (i + 1) % len;  // next point
                k = (i + 2) % len;  // next point's next point

                // calculate cross products
                double cross_product = (points[j].X - points[i].X) * (points[k].Y - points[j].Y);
                cross_product = cross_product - ((points[j].Y - points[i].Y) * (points[k].X - points[j].X));

                if (cross_product > 0)  // if cross product > 0
                    count++;            // increment in positive 
                else
                    count--;            // increment in negative
            }

            if (count < 0)              // if negative 
                return PolygonDirection.Count_Clockwise;    // counter-clockwise
            else if (count > 0)         // if positive
                return PolygonDirection.Clockwise;          // clockwise
            else 
                return PolygonDirection.Unknown; // if 0, unknown!
        }

        public static void reverse_direction(ref Point[] points) // reverses given points directions 
        {
            int lenght = points.Length;
            Point[] tmp = new Point[lenght];    // temp. location

            for (int i = 0; i < lenght; i++)    // copy points to temp. location
                tmp[i] = points[i];

            for (int i = 0; i < lenght; i++)    // copy back points in temp.location to original location in reverse
                points[i] = tmp[lenght - i - 1];
        }

        #endregion
    }
}
