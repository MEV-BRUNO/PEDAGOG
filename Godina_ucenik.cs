using System;
namespace ProjektIdio.Models
{
    public class Godina_ucenik
    {
        public Godina_ucenik()
        { }
            public int ID_ucenik { get; set; }
            public int ID_odjel { get; set; }
            public int ID_skola { get; set; }
            public int Godina{ get; set; }
            public int ID_razrednik { get; set; }
            public string Ponavlja { get; set; }
            public string Putnik { get; set; }
            public string Zaduzenja { get; set; }

        }
    }

