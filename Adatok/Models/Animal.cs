using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatok.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Faj { get; set; }
        public int Kor { get; set; }
        public int GazdaId { get; set; }

        public Animal()
        {
        }

        public Animal(string sor)
        {
            var t = sor.Split(';');
            Nev = t[0];
            Faj = t[1];
            Kor = Convert.ToInt32(t[2]);
            GazdaId = Convert.ToInt32(t[3]);
        }

        public override string? ToString()
        {
            return $"(${Nev} - ${Faj}, ${Kor} éves)";
        }
    }
}
