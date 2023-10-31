// Created by etar125 in SharpDevelop 5.1
using System;
using System.Drawing;

namespace SimpleDraw.Objects.Default
{
	public class Line
	{
		public Pen Pen;
		public PointF Point1;
		public PointF Point2;
		
		public Line() { }
		
		public Line(Pen pen, PointF point1, PointF point2)
		{
			Pen = pen;
			Point1 = point1;
			Point2 = point2;
		}
	}
}
