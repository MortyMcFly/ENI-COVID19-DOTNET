using System;

namespace Formes
{
    internal class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public override double GetAire()
        {
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }

        public override double GetPerimetre()
        {
            return A + B + C;
        }
        public override string ToString()
        {
            return $"Triangle de côté A={A}, B={B}, C={C}"
                + base.ToString();
        }
    }
}