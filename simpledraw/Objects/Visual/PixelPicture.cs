// Created by etar125 in SharpDevelop 5.1
using System;
using System.Drawing;

namespace simpledraw.Objects.Visual
{
	public class PixelPicture
	{
		public Point Location;
		public Image Image;
		public Size newSize;
		
		public PixelPicture() { }
		
		public PixelPicture(Point location, Image image, Size newsize)
		{
			Location = location;
			Image = image;
			newSize = newsize;
		}
	}
}
