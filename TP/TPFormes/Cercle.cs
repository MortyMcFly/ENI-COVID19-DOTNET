using System;

namespace Formes
{
    internal class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override double GetAire()
        {
            return Math.PI * Rayon * Rayon;
        }

        public override double GetPerimetre()
        {
            return 2 * Math.PI * Rayon;
        }
        public override string ToString()
        {
            return $"Cercle de rayon {Rayon}"
                + base.ToString();
        }
    }
}