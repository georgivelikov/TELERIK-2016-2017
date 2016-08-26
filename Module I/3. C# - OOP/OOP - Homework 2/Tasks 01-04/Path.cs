namespace Tasks_01_04
{
    using System.Collections.Generic;

    public class Path
    {
        private List<Point> points;

        public Path()
        {
            this.points = new List<Point>();
        }

        public IEnumerable<Point> Points
        {
            get
            {
                return this.points;
            }
        }

        public void AddPoint(Point p)
        {
            this.points.Add(p);
        }

        public void DeletePoint(Point p)
        {
            this.points.Remove(p);
        }

        public void DeletePointAtIndex(int index)
        {
            this.points.RemoveAt(index);
        }
    }
}
