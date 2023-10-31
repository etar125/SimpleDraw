// Created by etar125 in SharpDevelop 5.1
using System;
using System.Drawing;

namespace simpledraw.Objects.Default
{
	public class Ellipse
	{
		public Point Location;
		public Size Size;
		public Pen Pen;
		public Brush Brush;
		public bool Filled = false;
		
		public Ellipse() { }
		
		public Ellipse(Point location, Size size, Pen pen, Brush brush, bool filled)
		{
			Location = location;
			Size = size;
			Pen = pen;
			Brush = brush;
			Filled = filled;
		}
	}
}
