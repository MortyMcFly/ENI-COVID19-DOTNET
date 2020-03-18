using ProjetLinq.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAuteurs
{
    public class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        public static void Main(string[] args)
        {
            InitialiserDatas();
            
            Console.WriteLine("Afficher la liste des prénoms des auteurs dont le nom commence par \"G\" : ");
            ListeAuteurs.Where(a => a.Nom.StartsWith("G")).Select(a => a.Prenom).ToList().ForEach(p => Console.WriteLine(p));
            Console.WriteLine("Afficher l’auteur ayant écrit le plus de livres :");
            var aut = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(a => a.Count()).FirstOrDefault().Key;
            Console.WriteLine(aut.Nom + " " + aut.Prenom);
            Console.WriteLine("Afficher le nombre moyen de pages par livre par auteur :");
            ListeLivres.GroupBy(l => l.Auteur).ToList().ForEach(grp => Console.WriteLine(grp.Key.Nom + " " + grp.Key.Prenom + " : " + grp.Average(l => l.NbPages).ToString() + " pages moyennes"));
            Console.WriteLine("Afficher le titre du livre avec le plus de pages :");
            Console.WriteLine(ListeLivres.OrderByDescending(l => l.NbPages).First().Titre);
            Console.WriteLine("Afficher combien ont gagné les auteurs en moyenne (moyenne des factures) :");
            Console.WriteLine(ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant)));
            Console.WriteLine("Afficher les auteurs et la liste de leurs livres :");
            foreach (var livres in ListeLivres.GroupBy(l => l.Auteur))
            {
                Console.WriteLine(livres.Key.Prenom + " " + livres.Key.Nom);
                foreach (var livre in livres)
                {
                    Console.WriteLine(livre.Titre);
                }
            }
            Console.WriteLine("Afficher les titres de tous les livres triés par ordre alphabétique :");
            ListeLivres.Select(l => l.Titre).OrderBy(t => t).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne :");
            var avg = ListeLivres.Average(l => l.NbPages);
            ListeLivres.Where(l => l.NbPages > avg).Select(l => l.Titre).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("Afficher l'auteur ayant écrit le moins de livres :");
            var aut2 = ListeLivres.GroupBy(l => l.Auteur).OrderBy(a => a.Count()).FirstOrDefault().Key;
            Console.WriteLine(aut2.Nom + " " + aut2.Prenom);
            Console.ReadKey();
        }

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
