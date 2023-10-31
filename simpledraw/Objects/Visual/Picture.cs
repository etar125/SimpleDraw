// Created by etar125 in SharpDevelop 5.1
using System;
using System.Drawing;

namespace simpledraw.Objects.Visual
{
	public class Picture
	{
		public Point Location;
		public Image Image;
		
		public Picture() { }
		
		public Picture(Point location, Image image)
		{
			Location = location;
			Image = image;
		}
	}
}
