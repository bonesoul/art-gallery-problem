using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace ArtGalleryProblem
{
    enum prosess_status // prosess status
    {
        WAITING_USER_INPUT,
        DRAWING,
        POLYGON_READY,
        TRIANGULATION_COMPLETED,
        TRICOLOR_COMPLETED,
        ANIMATING
    }

    public partial class Form1 : Form
    {
        #region Form1 members, constructor

        private ArrayList points = new ArrayList(); // clicked points
        private Point[] polygon; // for drawing polygon
        private mPolygonShape m; // art-gallery problem solver
        
        // drawing, animation related
        private prosess_status status;

        // drawing related
        private Pen polygon_pen = new Pen(Color.Black, 2); 
        private SolidBrush[] brushes = new SolidBrush[]
		{
			new SolidBrush(Color.BlueViolet),			
			new SolidBrush(Color.Salmon),
			new SolidBrush(Color.Yellow),
		};

        public Form1()
        {
            status = prosess_status.WAITING_USER_INPUT;
            InitializeComponent(); // init window components
        }
        #endregion

        #region Mouse input handler

        private void panel_screen_MouseUp(object sender, MouseEventArgs e)
        {
            // fires when mouse button is released after click
            
            if (e.Button == MouseButtons.Left) // if left-click
            {
                // we're getting point input from user
                Point p = new Point(e.X, e.Y);
                points.Add(p);
                status = prosess_status.DRAWING;
            }
            else if (e.Button == MouseButtons.Right) // right-click
            {
                if (points.Count < 3) // polygon needs at least 3 points
                {
                    MessageBox.Show("You have to click at least 3 points!");
                    return;
                }
                // construct the polygon from entered points
                polygon = new Point[points.Count];
                for (int i = 0; i < points.Count; i++)
                    polygon[i] = (Point)points[i];

                Graphics g = panel_screen.CreateGraphics();
                g.Clear(Color.CornflowerBlue); // clear background
                draw_polygon(); // draw the polygon

                status = prosess_status.POLYGON_READY;
                cmd_cut.Enabled = true; // enable the triangulate button
            }
        }

        // mouse move handler - for drawing the polygon
        private void panel_screen_MouseMove(object sender, MouseEventArgs e)
        {
            if (status== prosess_status.DRAWING) // if we'r currently in draw-mode
            {
                Point start, end;
                Graphics g = panel_screen.CreateGraphics();
                g.Clear(Color.CornflowerBlue); // we need to clear screen as we drive lines to current mouse point

                // draw all entered vertices markers
                start = (Point)points[0];
                g.DrawLine(new Pen(Color.Yellow, 2), start.X - 6, start.Y, start.X + 6, start.Y);
                g.DrawLine(new Pen(Color.Yellow, 2), start.X, start.Y - 6, start.X, start.Y + 6);

                // continue drawing vertice markers
                for (int i = 0; i < points.Count - 1; i++)
                {
                    start = (Point)points[i];
                    g.DrawLine(new Pen(Color.Yellow, 2), start.X - 6, start.Y, start.X + 6, start.Y);
                    g.DrawLine(new Pen(Color.Yellow, 2), start.X, start.Y - 6, start.X, start.Y + 6);
                    end = (Point)points[i + 1];
                    g.DrawLine(new Pen(Color.Yellow, 2), end.X - 6, end.Y, end.X + 6, end.Y);
                    g.DrawLine(new Pen(Color.Yellow, 2), end.X, end.Y - 6, end.X, end.Y + 6);
                    g.DrawLine(new Pen(Color.Blue, 2), start, end);
                }

                // draw a line from last entered vertice to current mouse cursor coordinate
                start = (Point)points[points.Count - 1];
                end = new Point(e.X, e.Y);
                g.DrawLine(new Pen(Color.Blue, 2), start, end);
                // marker to current mouse coordinate
                g.DrawLine(new Pen(Color.Yellow, 2), end.X - 6, end.Y, end.X + 6, end.Y);
                g.DrawLine(new Pen(Color.Yellow, 2), end.X, end.Y - 6, end.X, end.Y + 6);

            }

            // rulers

            lbl_cords.Text = "X:" + e.X + " , Y:" + e.Y;
            Graphics f = panel_screen.CreateGraphics();
            for (int i = 0; i < panel_screen.Width; i += 100)
                f.DrawString(i.ToString(), lbl_cords.Font, Brushes.Black, i, 3);
            for (int i = 100; i < panel_screen.Height; i += 100)
                f.DrawString(i.ToString(), lbl_cords.Font, Brushes.Black, 3, i);

            Application.DoEvents();
        }

        #endregion

        #region button handlers

        // triangulate button
        private void cmd_cut_Click(object sender, EventArgs e)
        {
            // if there's not a complete polygon yet
            if (polygon == null | status!= prosess_status.POLYGON_READY) 
                return; // cancel prosessing
            if (polygon.Length < 3)
                return;

            m = new mPolygonShape(polygon); // initialize a new polygon-shape
            m.triangulate(); // triangualete 
            m.lb = listBox1; // assign reference of listbox
            listBox1.Items.Clear(); // clear listbox

            Graphics g = panel_screen.CreateGraphics(); // Graphics handle
            g.Clear(Color.CornflowerBlue); // cls screen

            // draw the result
            draw_ears(false); // wire_frame_only=false, allows filling of polygons
            draw_polygon(); // top of it, draw polygon, vertex markers
            status = prosess_status.TRIANGULATION_COMPLETED;
            cmd_3color.Enabled = true;
        }

        private void cmd_clear_Click(object sender, EventArgs e)
        {
            points.Clear(); // clear input points
            polygon = null; 
            m = null; // clear shape
            listBox1.Items.Clear();
            cmb_minumum.Items.Clear();
            cmb_other.Items.Clear();
            Graphics g = panel_screen.CreateGraphics();
            g.Clear(Color.CornflowerBlue);
            cmd_3color.Enabled = false;
            cmd_animate.Enabled = false;
            cmd_cut.Enabled = false;
            cmd_scan1.Enabled = false;
            cmd_scan2.Enabled = false;
            status = prosess_status.WAITING_USER_INPUT;
        }

        // 3-color the polygons
        private void cmd_3color_Click(object sender, EventArgs e) 
        {
            // if triangulation is complete
            if ((m != null) && (status==prosess_status.TRIANGULATION_COMPLETED) ) 
            {
                m.traverse(); // start 3-coloring the graph
                Graphics g = panel_screen.CreateGraphics();
                g.Clear(Color.CornflowerBlue);
                draw_polygon(); // draw markers
                draw_ears(false); // draw wireframe-only triangles
                draw_3colors(); // draw 3-coloring

                // process minumu-guards
                cmb_minumum.Items.Add(m.str_color(m.get_minumum_color())); // find minimum-color
                cmb_minumum.SelectedIndex = 0; 
                lbl_min_guards.Text = "Minumum Guards: " + m.count_colors(m.get_minumum_color()).ToString(); // minimum color count

                // process others
                for (int i = 1; i <= 3; i++)
                {
                    if ((vertex_color)i != m.get_minumum_color())
                    {
                        if (m.count_colors((vertex_color)i) == m.count_colors(m.get_minumum_color()))
                            cmb_minumum.Items.Add(m.str_color((vertex_color)i));
                        else
                            cmb_other.Items.Add(m.str_color((vertex_color)i));
                    }
                }
                if (cmb_other.Items.Count > 0) 
                    cmb_other.SelectedIndex = 0;

                status = prosess_status.TRICOLOR_COMPLETED;
                cmd_animate.Enabled = true;
                cmd_scan1.Enabled = true;
                cmd_scan2.Enabled = true;
            }
        }

        // animate the 3-coloring
        private void cmd_animate_Click(object sender, EventArgs e)
        {
            status = prosess_status.ANIMATING;
            m.animated = new Boolean[m.input_vertices.Length]; // animation construct

            for (int i = 0; i < m.animated.Length; i++)
            {
                m.animated[i] = false; // none of guards shown yet
            }

            for (int i = 0; i < listBox1.Items.Count; i++) // loop through listbox
            {
                listBox1.SelectedIndex = i; // let listbox select the item and show
                if (i != listBox1.Items.Count - 1) 
                {
                    Application.DoEvents(); 
                    Thread.Sleep(750);      // wait 750 ms for next animation step
                }
            }
            status = prosess_status.TRICOLOR_COMPLETED;
        }

        private void cmd_scan1_Click(object sender, EventArgs e)
        {
            scan_colors(m.get_color_index(cmb_minumum.Items[cmb_minumum.SelectedIndex].ToString()));
        }

        private void cmd_scan2_Click(object sender, EventArgs e)
        {
            if (cmb_other.SelectedIndex != -1)
                scan_colors(m.get_color_index(cmb_other.Items[cmb_other.SelectedIndex].ToString()));
        }

        // scans selected guards vision
        private void scan_colors(vertex_color c)
        {
            Point p;
            Graphics g = panel_screen.CreateGraphics();
            Brush b = Brushes.White;

            // set guard colors
            switch (c)
            {
                case vertex_color.Empty:
                    break;
                case vertex_color.Red:
                    b = Brushes.Firebrick;
                    break;
                case vertex_color.Green:
                    b = Brushes.DarkGreen;
                    break;
                case vertex_color.Blue:
                    b = Brushes.RoyalBlue;
                    break;
                default:
                    break;
            }

            g.Clear(Color.CornflowerBlue); 
            status = prosess_status.ANIMATING;
            
            draw_ears(true); // draw tringulated polygon - wireframe-only mode

            for (int i = 0; i < m.vertex_colors.Length; i++) // loop through guards
            {
                if (m.vertex_colors[i] == c) // if this is the guard we'r looking for 
                {
                    p = m.input_vertices[i]; // get guard point
                    Rectangle r = new Rectangle(p.X - 10, p.Y - 10, 20, 20);
                    g.FillEllipse(b, r); // draw guard
                    g.DrawEllipse(new Pen(Color.White, 1), r);
                    Application.DoEvents();
                    Thread.Sleep(750); // wait 750 ms for next step

                    for (int j = 0; j < m.polygons.Length; j++) // loop through polygons and find related polygons to current point
                    {
                        if ((p == m.polygons[j][0]) || (p == m.polygons[j][1]) || (p == m.polygons[j][2])) // if related polygon
                        {
                            g.FillPolygon(b, m.polygons[j]); // draw the polygon
                            g.DrawPolygon(Pens.White, m.polygons[j]);
                            Application.DoEvents();
                            Thread.Sleep(750); // wait 750 ms for next step
                        }
                    }
                    g.FillEllipse(b, r);
                    g.DrawEllipse(new Pen(Color.White, 1), r);
                }
            }

            status = prosess_status.TRICOLOR_COMPLETED;
        }

        private void lnk_about_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutBox a = new AboutBox();
            a.ShowDialog();
        }

        #endregion

        #region drawing functions

        public void draw_polygon() // draws our main-shape
        {
            if (polygon!=null && status!= prosess_status.ANIMATING ) // if we'r not animating
            {
                Graphics g = panel_screen.CreateGraphics();
                for (int i = 0; i< polygon.Length ; i++)
                {
                    // put vertex markers
                    g.DrawLine(new Pen(Color.Yellow, 2), polygon[i].X - 8, polygon[i].Y, polygon[i].X + 8, polygon[i].Y);
                    g.DrawLine(new Pen(Color.Yellow, 2), polygon[i].X, polygon[i].Y - 8, polygon[i].X, polygon[i].Y + 8);
                }
                g.DrawPolygon(polygon_pen, polygon); // draw it
            }
        }

        private void draw_ears(Boolean wireframe_only) // draws tringulated polygons
        {
            if (m == null) // if m has been processed
                return;

            Graphics g = panel_screen.CreateGraphics();

            for (int i = 0; i < m.polygons.Length; i++)
            {
                int brush = i % 3; // for every 3 triangle, use different color
                if (wireframe_only == false) // if wireframe only
                    g.FillPolygon(brushes[brush], m.polygons[i]); // draw filled polygon
                g.DrawPolygon(new Pen(Color.Black, 1), m.polygons[i]); // draw polygon
                Invalidate(); // update screen
            }
            g.DrawPolygon(polygon_pen, polygon);
        }

        public void draw_3colors()
        {
            if (m != null)
            {
                Graphics g = panel_screen.CreateGraphics();
                Brush b = Brushes.White;

                // loop through all vertexes
                for (int i = 0; i < m.input_vertices.Length; i++)
                {
                    if (m.vertex_colors[i] != vertex_color.Empty) 
                    {
                        switch (m.vertex_colors[i]) // find & set according vertex color to brush
                        {
                            case vertex_color.Red:
                                b = Brushes.Red;
                                break;
                            case vertex_color.Green:
                                b = Brushes.Green;
                                break;
                            case vertex_color.Blue:
                                b = Brushes.Blue;
                                break;
                            default:
                                break;
                        }

                        Rectangle r = new Rectangle(m.input_vertices[i].X - 10, m.input_vertices[i].Y - 10, 20, 20); // for guard circle
                        
                        if (status == prosess_status.ANIMATING) // if we're in animation
                        {
                            if (m.animated[i] == true) // just draw the already shown guards
                            {
                                g.FillEllipse(b, r);
                                g.DrawEllipse(new Pen(Color.Black, 1), r);
                            }
                        }
                        else // normal mode - draw all guards
                        {
                            g.FillEllipse(b, r);
                            g.DrawEllipse(new Pen(Color.Black, 1), r);
                        }
                    }
                }
            }
        }

        #endregion

        #region screen_update
        private void panel_screen_Paint(object sender, PaintEventArgs e)
        {
            switch (status)
            {
                case prosess_status.WAITING_USER_INPUT:
                    break;
                case prosess_status.POLYGON_READY:
                    draw_polygon();
                    break;
                case prosess_status.TRIANGULATION_COMPLETED:
                    draw_ears(false);
                    break;
                case prosess_status.TRICOLOR_COMPLETED:
                    break;
                default:
                    break;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel_screen_Paint(this, null);
        }

        #endregion

        #region debug, animator
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String txt;
            String code;
            String type;
            int no;
            string[] _code = new string[1];
            char[] splitter  = {']'};
            txt = listBox1.Items[listBox1.SelectedIndex].ToString(); // read listbox's current item
            _code = txt.Split(splitter); // split it to text and animation code
            code = _code[0];
            type = code.Substring(1, 1);
            no = Int32.Parse(code.Substring(2));

            Graphics g = panel_screen.CreateGraphics();
            g.Clear(Color.CornflowerBlue);
            draw_ears(true); // draw wireframe-only polygons
            draw_3colors();  // draw guards

            if (type == "c") // guards is checked
            {
                // mark the check guard
                g.DrawLine(new Pen(Color.White, 2), m.input_vertices[no].X - 8, m.input_vertices[no].Y, m.input_vertices[no].X + 8, m.input_vertices[no].Y);
                g.DrawLine(new Pen(Color.White, 2), m.input_vertices[no].X, m.input_vertices[no].Y - 8, m.input_vertices[no].X, m.input_vertices[no].Y + 8);
            }
            else if (type == "p") // polygon is checked
            {
                // draw the polygon
                g.FillPolygon(Brushes.RoyalBlue, m.polygons[no]);
                g.DrawPolygon(new Pen(Color.Black,2), m.polygons[no]);
            }
            else if (type == "s") // color set to guard
            {
                Brush b = Brushes.White;
                // find corresponding guard color
                switch (m.vertex_colors[no])
                {
                    case vertex_color.Empty:
                        break;
                    case vertex_color.Red:
                        b = Brushes.Red;
                        break;
                    case vertex_color.Green:
                        b = Brushes.Green;
                        break;
                    case vertex_color.Blue:
                        b = Brushes.Blue;
                        break;
                    default:
                        break;
                }
                Rectangle r = new Rectangle(m.input_vertices[no].X - 10, m.input_vertices[no].Y - 10, 20, 20);
                g.FillEllipse(b, r);
                g.DrawEllipse(new Pen(Color.White, 1), r); // draw the guard with the color set
                
                if (status==prosess_status.ANIMATING ) // if we're animating
                {
                    m.animated[no] = true; // we have drawed the current guard now
                                           // on future screen updates, draw_3colors function can show this guard
                }
            }
        }
        #endregion

    }
}