namespace Tasks_01_04
{
    public class Point
    {
        private static readonly Point PointZero;
        private double x;
        private double y;
        private double z;

        static Point()
        {
            PointZero = new Point(0, 0, 0);
        }

        public Point(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        public double Z
        {
            get
            {
                return this.z;
            }

            set
            {
                this.z = value;
            }
        }

        public static Point ZeroPoint
        {
            get
            {
                return PointZero;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0:0.00}, {1:0.00}, {2:0.00}]", this.X, this.Y, this.Z);
        }
    }
}
