// Created by etar125 in SharpDevelop 5.1
using System;
using SimpleDraw.Objects.Default;
using SimpleDraw.Objects.Visual;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleDraw.Drawing
{
	public class SimpleDrawing
	{
		public SimpleDrawing() { }
		
		public List<object> queue = new List<object>
		{
			
		};
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
					Rectangle k = new Rectangle(g.Location, g.Size);
					a.DrawRectangle(g.Pen, k);
					if(g.Filled)
						a.FillRectangle(g.Brush, k);
				}
				else if(o is Ellipse)
				{
					Ellipse g = (Ellipse)o;
					Rectangle k = new Rectangle(g.Location, g.Size);
					a.DrawEllipse(g.Pen, k);
					if(g.Filled)
						a.FillEllipse(g.Brush, k);
				}
				else if(o is Line)
				{
					Line g = (Line)o;
					a.DrawLine(g.Pen, g.Point1, g.Point2);
				}
				else if(o is Picture)
				{
					Picture g = (Picture)o;
					a.DrawImage(g.Image, g.Location);
				}
				else if(o is PixelPicture)
				{
					PixelPicture g = (PixelPicture)o;
					a.DrawImage(Zoom(g.Image, g.newSize), g.Location);
				}
			}
			ClearQueue();
		}
		public void ClearBuffer(Form f) { Buffer = new Bitmap(f.Width, f.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb); }
		public void ClearQueue() { queue.Clear(); }
		
		public void Request(Form f)
		{
			f.Controls.Add(new PictureBox() { Image = Buffer, Location = new Point(0, 0), Size = Buffer.Size, BackColor = Color.Transparent });
			ClearBuffer(f);
		}
	}
}
