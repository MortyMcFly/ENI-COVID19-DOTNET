namespace Formes
{
    internal class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }

        public override double GetAire()
        {
            return Largeur * Longueur;
        }

        public override double GetPerimetre()
        {
            return 2 * Largeur + 2 * Longueur;
        }

        public override string ToString()
        {
            return $"Rectangle de longueur={Longueur} et largeur={Largeur}"
                + base.ToString();
        }
    }
}