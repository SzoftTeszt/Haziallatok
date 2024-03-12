using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatok.Models
{
    public class Gazda
    {
        public int Id { get; set; }
        public string Nev { get; set; }

        public ICollection<Animal> Animal { get;} = 
            new List<Animal>();

        public Gazda()
        {
        }

        public Gazda(string nev)
        {
            Nev = nev;
        }

        public override string? ToString()
        {
            string s = Nev+" ";
            foreach (var animal in Animal)
            {
                s += animal.ToString()+" ";
            }
            return s;
        }
    }


}
