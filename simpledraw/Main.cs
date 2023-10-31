// Created by etar125 in SharpDevelop 5.1
using System;
using simpledraw.Objects.Default;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace simpledraw.Drawing
{
	public class SimpleDrawing
	{
		public SimpleDrawing() { }
		
		public List<object> queue = new List<object>
		{
			
		};
		public Bitmap Buffer;
		
		public void CreateBuffer(Form f)
		{
			Bitmap bmp = new Bitmap(f.Width, f.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
			Graphics a = Graphics.FromImage(bmp);
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
			}
			ClearQueue();
			Buffer = bmp;
		}
		public void ClearBuffer(Form f) { Buffer = new Bitmap(f.Width, f.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb); }
		public void ClearQueue() { queue.Clear(); }
		
		public void Request(Form f)
		{
			Bitmap bmp = new Bitmap(f.Width, f.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
			Graphics a = Graphics.FromImage(bmp);
			if(Buffer != null)
				a.DrawImage(Buffer, new Point(0, 0));
			f.BackgroundImageLayout = ImageLayout.None;
			f.BackgroundImage = bmp;
		}
	}
}
