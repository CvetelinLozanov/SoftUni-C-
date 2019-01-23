using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double width;
        private double length;
        private double height;
        private double surface;
        private double lateralSurfaceArea;
        private double volume;

        public Box(double width, double length, double height)
        {
            this.Width = width;
            this.Height = height;
            this.Length = length;
            this.Surface = GetSurface(width, length, height);
            this.LateralSurfaceArea = GetLateralSurfaceArea(width, length, height);
            this.Volume = GetVolume(width, length, height);            
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    SizeException();
                }
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    SizeException();
                }
                height = value;
            }
        }

        public double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                {
                    SizeException();
                }
                length = value;
            }
        }

        private double Surface
        {
            get { return surface; }
            set { surface = value; }
        }

        private double LateralSurfaceArea
        {
            get => lateralSurfaceArea;
            set => lateralSurfaceArea = value;
        }

        private double Volume
        {
            get => volume;
            set => volume = value;
        }

        private void SizeException()
        {
            throw new ArgumentException("Width cannot be zero or negative.");
        }

        private double GetSurface(double width, double lenght, double height)
        {            
            return (2 * length * width) + (2 * length * height) + (2 * width * height);
        }

        private double GetLateralSurfaceArea(double width, double lenght, double height)
        {
            return (2 * length * height) + (2 * width * height);
        }

        private double GetVolume(double width, double lenght, double height)
        {
            return width * length * height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area – {this.Surface:F2}");
            sb.AppendLine($"Lateral Surface Area – {this.LateralSurfaceArea:F2}");
            sb.AppendLine($"Volume – {this.Volume:F2}");
            return sb.ToString().Trim();
        }
    }
}
