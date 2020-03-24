using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class SamouraiViewModel
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes{ get; set; }
        public List<ArtMartial> ArtsMartiaux{ get; set; }
        public int? IdSelectedArme { get; set; }
        public List<int> IdSelectedArtMartiaux { get; set; }
    }
}