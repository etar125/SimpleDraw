// Created by etar125 in SharpDevelop 5.1
using System;
using System.Drawing;

namespace SimpleDraw.Objects.Extra
{
	public class Text
	{
		public string Data;
		public Font Font;
		public Brush Brush;
		public Point Location;
		
		public Text() { }
		
		public Text(string data, Font font, Brush brush, Point location)
		{
			Data = data;
			Font = font;
			Brush = brush;
			Location = location;
		}
	}
}
