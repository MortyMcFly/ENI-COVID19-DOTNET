namespace Formes
{
    public abstract class Forme
    {
        public abstract double GetAire();
        public abstract double GetPerimetre();

        public override string ToString()
        {
            return $"\nAire = { GetAire()}\nPérimètre = { GetPerimetre()}\n";
        }
    }
}