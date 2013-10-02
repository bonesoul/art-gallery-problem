using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace ArtGalleryProblem
{
    public enum vertex_color
    {
        Empty=0,
        Red=1,
        Green=2,
        Blue=3
    }

    class mPolygonShape
    {
        #region consturctor, members
        public Point[] input_vertices;       // user input vertices
        private Point[] updated_vertices;    // updated vertices while triangulation
        ArrayList ears = new ArrayList();    // processed triangulated polygons list
        public Point[][] polygons;           // final triangulated polygons list
        public vertex_color[] vertex_colors; // assigned vertex-colors
        public Boolean[] animated;           // animation-specific structure

        public System.Windows.Forms.ListBox lb; // user interfaces listbox's reference, so we can add debug messages to it
        
        public mPolygonShape(Point[] vertices) // constructure
        {
            if (vertices.Length < 3) // polygon needs to have at least 3 points
                return;

            input_vertices = new Point[vertices.Length];       // init input vertices
            vertex_colors = new vertex_color[vertices.Length]; // init vertex colors
            for (int i = 0; i < vertices.Length; i++)
            {
                input_vertices[i] = vertices[i];               // move given vertices to input vertices
                vertex_colors[i] = vertex_color.Empty;         // set colors to empty
            }

            update_vertices();  // process the given vertices
        }
        #endregion

        #region vertice processing

        private void update_vertices() // copy input vertices to updated_vertices for processing 
        {
            updated_vertices = new Point[input_vertices.Length];
            for (int i = 0; i < input_vertices.Length; i++)
                updated_vertices[i] = input_vertices[i];

            // check input vertices direction
            // we need counter clockwise 
            if (mPolygon.get_direction(updated_vertices) == PolygonDirection.Clockwise) // if clockwise
            {
                mPolygon.reverse_direction(ref updated_vertices); // reverse the vertices
                mPolygon.reverse_direction(ref input_vertices);
            }
        }

        private void update_vertices(Point p)   // called after finding a ear from a vertice
        {                                       // removes the vertice from updates_vertices list
            ArrayList temp_points = new ArrayList();    // temp. location while updating the list

            for (int i = 0; i < updated_vertices.Length; i++) // loop through the list
            {
                if (p == updated_vertices[i])   // if we found the vertice we'r lookig for
                {
                    mPolygon poly = new mPolygon(updated_vertices); 
                    Point curr_point = p;
                    Point next_point = poly.get_next_point(p);  // find the vertices next neighboor
                    Point prev_point = poly.get_prev_point(p);  // find the vertices previous neighboor

                    Point[] ear = new Point[3]; // create a 3 point triangle-polygon from these 3 points
                    ear[0] = prev_point;        // previos vertice
                    ear[1] = curr_point;        // current vertice
                    ear[2] = next_point;        // next vertice

                    ears.Add(ear);              // add this ear to ears list
                }
                else    // this is not the vertice we'r looking for                      
                {
                    temp_points.Add(updated_vertices[i]);   // so add it to temp. vertice list
                }
            }

            if ((updated_vertices.Length - temp_points.Count) == 1) // we removed 1 vertice from the list, check the counts
            {
                updated_vertices = new Point[updated_vertices.Length - 1];  // redimension the list to -1 size, cause we removed 1 vertice
                for (int i = 0; i < temp_points.Count; i++)
                {
                    updated_vertices[i] = (Point)temp_points[i];    // update the newest updated_vertices from temp location
                }

            }
        }

        #endregion

        #region coloring

        public vertex_color get_color_index(string s) // return given string color as vertex_color
        {
            if (s.ToLower() == "red")
                return vertex_color.Red;
            else if (s.ToLower() == "blue")
                return vertex_color.Blue;
            else if (s.ToLower() == "green")
                return vertex_color.Green;
            else return vertex_color.Empty;
        }

        public vertex_color get_minumum_color() // count the each colors, return the minumum count color 
        {                                       // used for deciding the minimum guard
            int red_count = count_colors(vertex_color.Red);
            int blue_count = count_colors(vertex_color.Blue);
            int green_count = count_colors(vertex_color.Green);

            int min = red_count;
            vertex_color min_color = vertex_color.Red;

            if (blue_count < min)
            {
                min = blue_count;
                min_color = vertex_color.Blue;
            }

            if (green_count < min)
            {
                min = green_count;
                min_color = vertex_color.Green;
            }

            return min_color;
        }

        public int count_colors(vertex_color c) // count given colors total occurence
        {
            int count = 0;
            for (int i = 0; i < vertex_colors.Length; i++)
            {
                if (vertex_colors[i] == c)
                    count++;
            }

            return count;
        }

        public void traverse() // travers the triangulated polygons list for assinging 3-colors
        {
            int last_poly = polygons.Length - 1; // find last polygon on list
            lb.Items.Add("[p" + last_poly + "] Last Polygon: \t" + polygons[last_poly][0] + polygons[last_poly][1] + polygons[last_poly][2]); // debug message

            // directly assign last polygons vertex's colors
            vertex_colors[get_index(polygons[last_poly][0])] = vertex_color.Red;
            lb.Items.Add("[s" + get_index(polygons[last_poly][0]) + "] Assigned color:\tRed");
            vertex_colors[get_index(polygons[last_poly][1])] = vertex_color.Blue;
            lb.Items.Add("[s" + get_index(polygons[last_poly][1]) + "] Assigned color:\tBlue");
            vertex_colors[get_index(polygons[last_poly][2])] = vertex_color.Green;
            lb.Items.Add("[s" + get_index(polygons[last_poly][2]) + "] Assigned color:\tGreen");

            colorize(0); // start deep-first 3-color algorithm
        }

        public void colorize(int i) // algorith for colorizing points
        {
            int next = i + 1;
            if (next < input_vertices.Length) // use deep-first strategy
            {
                colorize(next);
            }
            lb.Items.Add("[c" + i + "] Colorizing point \t" + i + " " + input_vertices[i]); // debug message
            find_polygons(input_vertices[i]); // find given points related polygons
        }

        public void find_polygons(Point p) // find given points related polygons
        {
            int v0_index, v1_index, v2_index;

            for (int i = polygons.Length - 1; i > -1; i--) // loop through all polygons
            {
                if ((p == polygons[i][0]) || (p == polygons[i][1]) || (p == polygons[i][2])) // if given point is one of the vertexes of current polygon
                {
                    lb.Items.Add("[p" + i + "] Polygon: \t\t" + polygons[i][0].ToString() + polygons[i][1].ToString() + polygons[i][2].ToString()); // debug message

                    for (int j = 0; j < 3; j++) // check polygons all 3-vertexes colors
                    {                           // vertexes are rounded and each one is checked with two other
                        v0_index = get_index(polygons[i][j]);           // vertex1
                        v1_index = get_index(polygons[i][(j + 1) % 3]); // vertex2
                        v2_index = get_index(polygons[i][(j + 2) % 3]); // vertex3

                        if (vertex_colors[v0_index] == vertex_color.Empty) // if selected vertex's color is not set yet
                        {
                            vertex_colors[v0_index] = find_color(vertex_colors[v1_index], vertex_colors[v2_index]); // try to set a color to it using other two vertexes colors
                            lb.Items.Add("[s" + v0_index + "] Assigned color: \t" + str_color(vertex_colors[v0_index]) + " {" + str_color(vertex_colors[v1_index]) + " ," + str_color(vertex_colors[v2_index]) + "} " + polygons[i][j]); // debug message
                        }
                    }

                }
            }
        }

        public string str_color(vertex_color c) // returns given vertex_colors, color-string
        {
            string r = "";
            switch (c)
            {
                case vertex_color.Empty:
                    r = "EMPTY";
                    break;
                case vertex_color.Red:
                    r = "RED";
                    break;
                case vertex_color.Green:
                    r = "GREEN";
                    break;
                case vertex_color.Blue:
                    r = "BLUE";
                    break;
                default:
                    break;
            }

            return r;
        }

        public vertex_color find_color(vertex_color c1, vertex_color c2) // find a color for vertex using given two other colors
        {
            if (c1 == vertex_color.Red)             // red
            {
                if (c2 == vertex_color.Blue)        // red + blue
                    return vertex_color.Green;      // ===========> green

                else if (c2 == vertex_color.Green)  // red + green
                    return vertex_color.Blue;       // ===========> blue
            }
            else if (c1 == vertex_color.Blue)       // blue
            {
                if (c2 == vertex_color.Red)         // blue + red
                    return vertex_color.Green;      // ===========> green

                else if (c2 == vertex_color.Green)  // blue + green
                    return vertex_color.Red;        // ============> red
            }
            else if (c1 == vertex_color.Green)      // green
            {       
                if (c2 == vertex_color.Red)         // green + red
                    return vertex_color.Blue;       // ===========> blue

                else if (c2 == vertex_color.Blue)   // green + blue
                    return vertex_color.Red;        // ===========> red
            }

            return vertex_color.Empty;              // return decided color
        }

        public int get_index(Point p) // finds given point in input vertices
        {
            for (int i = 0; i < input_vertices.Length; i++)
            {
                if (p == input_vertices[i])
                    return i;
            }

            return -1;
        }

        #endregion

        #region triangulation

        public void triangulate()   // triangulate the bigger polygon-shape
        {
            mPolygon poly = new mPolygon(updated_vertices); // create a polygon from the current vertices
            Boolean finished = false; // triangulation-finished?

            if (updated_vertices.Length == 3) // if there's only 3 points, no need to run algorithm
                finished = true;

            Point p = new Point();

            while (finished == false)   // loop while triangulation not finished yet
            {
                int i = 0;
                Boolean not_found = true;   // did we found an ear? no, not yet
                while (not_found && (i < updated_vertices.Length)) // while we did not found any ear and not yet processed all vertices
                {
                    p = updated_vertices[i];    // get current point
                    if (is_ear(p))              // check if we can get an ear from that vertice
                        not_found = false;      // good we found one
                    else
                        i++;                    // continue to search
                }

                update_vertices(p);             // remove the vertice we found the ear from the updated_vertices list
                poly = new mPolygon(updated_vertices);  // reupdate the polygon from the rest of vertices
                if (updated_vertices.Length == 3)   // if there's only 3 vertice left
                    finished = true;                // this means we finished the triangulation
            }

            // when the CS:IP reaches here, this means triangulation finished
            polygons = new Point[ears.Count + 1][]; // init polygons structure to ears.count + 1(for last 3 points left)
            for (int i = 0; i < ears.Count; i++)
            {
                Point[] points = (Point[])ears[i];  // move ears to final triangulated polygons list
                polygons[i] = new Point[3];
                polygons[i][0] = points[0];
                polygons[i][1] = points[1];
                polygons[i][2] = points[2];
            }

            // we have 3 left vertices on updated_vertices list, - the last triangulated polygon -
            polygons[ears.Count] = new Point[updated_vertices.Length]; // add it to triangulated polygons list also
            for (int i = 0; i < updated_vertices.Length; i++)
            {
                polygons[ears.Count][i] = updated_vertices[i];
            }
        }

        private Boolean is_ear(Point p) // checks if given vertice is in a ear
        {
            mPolygon m = new mPolygon(updated_vertices); // init. a polygon from the current vertices

            if (m.is_vertex(p) == true) // if given point is a vertex
            {
                if (m.vertex_type(p) == VertexType.ConvexPoint) // and it's a convex point
                {
                    Point curr_point = p;   
                    Point prev_point = m.get_prev_point(p); // find previous adjacent point
                    Point next_point = m.get_next_point(p); // find next adjacent point

                    for (int i = updated_vertices.GetLowerBound(0); i < updated_vertices.GetUpperBound(0); i++) // loop through all other vertices
                    {
                        Point pt = updated_vertices[i];
                        if (!(is_points_equal(pt, curr_point) || is_points_equal(pt, prev_point) || is_points_equal(pt, next_point)))
                        {   // if pt is not equal to checked vertice or its's next and prev adjacent vertices
                            if (is_point_in_triangle(new Point[] { prev_point, curr_point, next_point }, pt)) // check pt lies in triangle
                                return false;   // if another vertice lies in this triangle, then this is not an ear
                        }
                    }
                }
                else // concave
                    return false; // we cannot make ears from concave points

                return true;    // if CS:IP reaches here, this means vertice passed the test and is an ear
            }
            return false; // if the given vertex is not an vertex, it's not related to an ear also!
        }

        private Boolean is_point_in_triangle(Point[] triangle, Point p) // check if given point lies in a given triangle
        {
            if (triangle.Length != 3) // check if we have exact-3 points of triangle
                return false;

            for (int i = triangle.GetLowerBound(0); i < triangle.GetUpperBound(0); i++) // loop triangles vertexes
            {
                if (is_points_equal(p,triangle[i])) // given point is equal or very near to one of given triangles vertices
                    return true;
            }
        
            // check line segments of given triangle
            mLineSegment l1 = new mLineSegment(triangle[0], triangle[1]);
            mLineSegment l2 = new mLineSegment(triangle[1], triangle[2]);
            mLineSegment l3 = new mLineSegment(triangle[2], triangle[0]);

            if (is_point_in_line(p, l1) || is_point_in_line(p, l2) || is_point_in_line(p, l3)) // if point lies in one of triangles lines
                return true;

            // check interior triangle area
            double area0 = mPolygon.PolygonArea(new Point[] { triangle[0], triangle[1], p });
            double area1 = mPolygon.PolygonArea(new Point[] { triangle[1], triangle[2], p });
            double area2 = mPolygon.PolygonArea(new Point[] { triangle[2], triangle[0], p });

            if ((area0 > 0) && (area1 > 0) && (area2 > 0))
                return true;
            else if ((area0 < 0) && (area1 < 0) && (area2 < 0))
                return true;

            // if CS:IP reaches here, this means given point passed test and not in anywhere in the triangle
            return false;
        }

        private Boolean is_point_in_line(Point p, mLineSegment line) // is given point lies in given line?
        {
            double Ax, Ay, Bx, By, Cx, Cy;
            Bx = line.end_point.X;
            By = line.end_point.Y;
            Ax = line.start_point.X;
            Ay = line.start_point.Y;
            Cx = p.X;
            Cy = p.Y;

            double line_lenght = line.get_lenght();

            double s = Math.Abs(((Ay - Cy) * (Bx - Ax) - (Ax - Cx) * (By - Ay)) / (line_lenght * line_lenght));

            if (Math.Abs(s - 0) < 0.00001) // does it lie in or very near to line?
            {
                if (is_points_equal(p, line.start_point) || is_points_equal(p, line.end_point))
                    return true;
                else if ((Cx < line.get_x_max()) && (Cx > line.get_x_min()) && (Cy < line.get_y_max()) && (Cy > line.get_y_min()))
                    return true;
            }

            // if CS:IP reaches here, means point does not lie in the line
            return false;
        }

        public bool is_points_equal(Point p1, Point p2) // check if given two points are equal
        {
            double dDeff_X = Math.Abs(p1.X - p2.X);
            double dDeff_Y = Math.Abs(p1.Y - p2.Y);

            if ((dDeff_X < 0.00001) && (dDeff_Y < 0.00001)) // if they're to near to each other, we can say they're equal
                return true;
            else
                return false;
        }

        #endregion

    }
}
