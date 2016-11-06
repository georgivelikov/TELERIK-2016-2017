using Abstraction.Interfaces;

namespace Abstraction.Figures
{
    public abstract class Figure : IFigure
    {
        public abstract double CalaculateSurface();

        public abstract double CalculatePerimeter();
    }
}
