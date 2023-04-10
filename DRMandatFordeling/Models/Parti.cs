using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRMandatFordeling.Models
{
    internal class Parti
    {
        public string Navn { get; set; }
        public int Stemmer { get; set; }
        public int Mandater { get; set; } = 0;
        
    public Parti(string navn, int stemmer)
        {
            this.Navn = navn;
            this.Stemmer = stemmer;
        }
    }
}
