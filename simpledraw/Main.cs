// Created by etar125 in SharpDevelop 5.1
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimpleDraw.Objects.Default;
using SimpleDraw.Objects.Visual;
using SimpleDraw.Objects.Extra;
using SimpleDraw.Tools;

namespace SimpleDraw.Drawing
{
	public class SimpleDrawing
	{
		public SimpleDrawing() { }
		
		public List<object> queue = new List<object> { };
		public Bitmap Buffer;
		
		public Bitmap Zoom(Image bmp, Size size)
        {
            var result = new Bitmap(size.Width, size.Height);
            using(var gr = Graphics.FromImage(result))
            {
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gr.DrawImage(bmp, 0, 0, size.Width, size.Height);
            }
 
            return result;
        }
		
		public void CreateBuffer(Form f)
		{
			Buffer = new Bitmap(f.Width, f.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics a = Graphics.FromImage(Buffer);
			foreach(object o in queue)
			{
				if(o is Box)
				{
					Box g = (Box)o;
					Rectangle k = new Rectangle(new Point(0, 0), g.Size);
                    //a.TranslateTransform(g.Size.Width + g.Location.X, g.Size.Height + g.Location.Y);
                    a.TranslateTransform(g.Location.X, g.Location.Y);
                    a.RotateTransform(g.Angle);
					a.DrawRectangle(g.Pen, k);
					if(g.Filled)
						a.FillRectangle(g.Brush, k);
                    a.ResetTransform();
				}
				else if(o is Ellipse)
				{
					Ellipse g = (Ellipse)o;
                    Rectangle k = new Rectangle(new Point(0, 0), g.Size);
                    a.TranslateTransform(g.Size.Width + g.Location.X, g.Size.Height + g.Location.Y);
                    a.RotateTransform(g.Angle);
                    a.DrawRectangle(g.Pen, k);
                    if (g.Filled)
                        a.FillEllipse(g.Brush, k);
                    a.ResetTransform();
                }
				else if(o is Line)
				{
					Line g = (Line)o;
					a.DrawLine(g.Pen, g.Point1, g.Point2);
				}
				else if(o is Picture)
				{
					Picture g = (Picture)o;
                    a.TranslateTransform(g.Image.Size.Width + g.Location.X, g.Image.Size.Height + g.Location.Y);
                    a.RotateTransform(g.Angle);
                    a.DrawImage(g.Image, new Point(0, 0));
                    a.ResetTransform();
                }
				else if(o is PixelPicture)
				{
					PixelPicture g = (PixelPicture)o;
                    a.TranslateTransform(g.Image.Size.Width + g.Location.X, g.Image.Size.Height + g.Location.Y);
                    a.RotateTransform(g.Angle);
                    a.DrawImage(Zoom(g.Image, g.newSize), g.Location);
                    a.ResetTransform();
                }
				else if(o is Camera)
				{
					Camera g = (Camera)o;
					a.DrawRectangle(g.Pen, new Rectangle(g.Location, g.Size));
				}
				else if(o is Text)
				{
					Text g = (Text)o;
					a.DrawString(g.Data, g.Font, g.Brush, g.Location);
				}
				else if(o is Polygon)
				{
					Polygon g = (Polygon)o;
					a.DrawPolygon(g.Pen, g.Points);
					if(g.Filled)
						a.FillPolygon(g.Brush, g.Points);
				}
			}
			ClearQueue();
		}
		public void ClearBuffer(Form f) { Buffer = new Bitmap(f.Width, f.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb); }
		public void ClearQueue() { queue.Clear(); }
		
		public List<PictureBox> stack = new List<PictureBox> { };
		public List<Label> fordel1 = new List<Label> { };
		
		public void Request(Form f)
		{
			if(stack.Count == 8)
			{
				f.Controls.Remove(stack[0]);
				stack.RemoveAt(0);
			}
			PictureBox a = new PictureBox() { Image = Buffer, Location = new Point(0, 0), Size = Buffer.Size, BackColor = Color.Transparent, Parent = f };
			f.Controls.Add(a);
			stack.Add(a);
			ClearBuffer(f);
		}
	}
}
