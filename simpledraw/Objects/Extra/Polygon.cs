// Created by etar125 in SharpDevelop 5.1
using System;
using System.Drawing;

namespace SimpleDraw.Objects.Extra
{
	public class Polygon
	{
		public Point[] Points;
		public Pen Pen;
		public Brush Brush;
		public bool Filled = false;
        public float Angle;
		
		public Polygon() { }
		
		public Polygon(Point[] points, Pen pen, Brush brush, bool filled, float angle)
		{
			Points = points;
			Pen = pen;
			Brush = brush;
			Filled = filled;
            Angle = angle;
		}
	}
}
