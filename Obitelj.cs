using System;
namespace ProjektIdio.Models
{
    public class Obitelj
    {
        public Obitelj()
        { }
        public int ID_obitelj { get; set; }
        public int ID_ucenik { get; set; }
        public string Ime { get; set; }
        public string Vrsta { get; set; }
    }
}

