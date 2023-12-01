using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonecarloExamen.Modelos;

namespace MonecarloExamen.Algoritmos
{
    public class AlgoritmoSimulacion
    {
        public AlgoritmoSimulacion() { }
        public List<Experimento> SimulacionMontecarlo(float a, float b, int n, int f)
        {
            List<Experimento> listaExperimentos = new List<Experimento>();
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                Experimento experimento = new Experimento();
                {
                    experimento.IdExperimento = i + 1;
                    experimento.P = random.Next(a, b);

                

                };
                listaExperimentos.Add(experimento);
            }
            return listaExperimentos;
        }
    }
}
