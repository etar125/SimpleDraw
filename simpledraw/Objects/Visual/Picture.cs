// Created by etar125 in SharpDevelop 5.1
using System;
using System.Drawing;

namespace SimpleDraw.Objects.Visual
{
	public class Picture
	{
		public Point Location;
		public Image Image;
        public float Angle;
		
		public Picture() { }
		
		public Picture(Point location, Image image, float angle)
		{
			Location = location;
			Image = image;
            Angle = angle;
		}
	}
}
