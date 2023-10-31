// Created by etar125 in SharpDevelop 5.1
using System;
using System.Drawing;

namespace SimpleDraw.Objects.Default
{
	public class Box
	{
		public Point Location;
		public Size Size;
		public Pen Pen;
		public Brush Brush;
		public bool Filled = false;
		
		public Box() { }
		
		public Box(Point location, Size size, Pen pen, Brush brush, bool filled)
		{
			Location = location;
			Size = size;
			Pen = pen;
			Brush = brush;
			Filled = filled;
		}
	}
}
