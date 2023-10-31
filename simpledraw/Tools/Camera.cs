// Created by etar125 in SharpDevelop 5.1
using System;
using System.Drawing;
using SimpleDraw.Objects.Default;
using SimpleDraw.Objects.Visual;

namespace SimpleDraw.Tools.Camera
{
	public class Camera
	{
		public Point Location;
		public Size Size;
		public Pen Pen;
		
		public Camera() { }
		
		public Camera(Point loc, Size size, Pen pen)
		{
			Location = loc;
			Size = size;
			Pen = pen;
		}
		
		public bool Intersects(object obj)
		{
			if(obj is Box)
			{
				Box o = (Box)obj;
				if(o.Location.X < Location.X && o.Location.Y < Location.Y)
				{
					if(o.Location.X + o.Size.Width < Location.X && o.Location.Y + o.Size.Height < Location.Y)
						return false;
					if(o.Location.X + o.Size.Width < Location.X + Size.Width && o.Location.Y + o.Size.Height < Location.Y + Size.Height)
						return true;
					if(o.Location.X + o.Size.Width > Location.X + Size.Width && o.Location.Y + o.Size.Height > Location.Y + Size.Height)
						return true;
					return false;
				}
				if(o.Location.X < Location.X + Size.Width && o.Location.Y < Location.Y + Size.Height)
					return true;
			}
			throw new Exception("Unkown object type");
		}
	}
}
