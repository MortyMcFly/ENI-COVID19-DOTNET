namespace Formes
{
    internal class Carre : Forme
    {
        public int Longueur { get; set; }

        public override double GetAire()
        {
            return Longueur * Longueur;
        }

        public override double GetPerimetre()
        {
            return Longueur * 4;
        }
        public override string ToString()
        {
            return $"Carré de côté {Longueur}"
                + base.ToString();
        }
    }
}