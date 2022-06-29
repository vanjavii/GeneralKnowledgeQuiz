using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Response
    {
        public Signal UsernameSignal { get; set; }
        public double Points { get; set; }
        public string PorukaOdServera { get; set; }
        public string Question { get; set; }
        public string Winner { get; set; }
    }
}
