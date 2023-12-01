using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonecarloExamen.Modelos
{
    public class Experimento
    {
        public int IdExperimento { get; set; }
        public float P { get; set; } = new float();
        public Experimento() { }
        public Experimento(int idExperimento, int p)
        {
            this.IdExperimento = idExperimento;
            this.P = p;
        }
    }
}
