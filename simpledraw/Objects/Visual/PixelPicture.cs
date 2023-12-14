// Created by etar125 in SharpDevelop 5.1
using System;
using System.Drawing;

namespace SimpleDraw.Objects.Visual
{
	public class PixelPicture
	{
		public Point Location;
		public Image Image;
		public Size newSize;
        public float Angle;
		
		public PixelPicture() { }
		
		public PixelPicture(Point location, Image image, Size newsize, float angle)
		{
			Location = location;
			Image = image;
			newSize = newsize;
            Angle = angle;
		}
	}
}
