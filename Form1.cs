using System;
using MonecarloExamen.Algoritmos;
using MonecarloExamen.Modelos;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace MonecarloExamen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Button1_Click(object sender, EventArgs e)
        {
            // Paso 1: Inicializaci�n de par�metros
            float a = float.Parse(textBox1.Text);
            float b = float.Parse(textBox2.Text);
            int n = int.Parse(textBox3.Text);
            int f = int.Parse(textBox4.Text);

            // Paso 1.2: Validación algoritmo
            if (n <= 0 || b <= 0)
            {
                MessageBox.Show("Los números tienen que ser MAYORES QUE CERO");
                return;
            }

            // Paso 1.3: Validación algoritmo
            if (a > b)
            {
                MessageBox.Show("El rango no es correcto.");
                return;
            }

            // Paso 1.3: Validación algoritmo
            if (a != -1 * b)
            {
                MessageBox.Show("El rango no es correcto.");
                return;
            }


            if (f != 1 && f != 2)
            {
                MessageBox.Show("Para funcion 1 escribir 1, para funcion 2 escribir 2.");
                return;
            }

            // Paso 4: Crear DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Replica", typeof(float));
            dt.Columns.Add("X(i)", typeof(float));
            dt.Columns.Add("Área", typeof(float));

            // Paso 2: Declarar clase algoritmo gen�tico
            AlgoritmoSimulacion algoritmo = new AlgoritmoSimulacion();
            // Paso 3: Llamar m�todo principal
            List<Experimento> listaExperimentos = algoritmo.SimulacionMontecarlo(a, b, n, f);

            float sum = 0;
            int sumatoria = 0;
            List<float> valores = new List<float>();
            List<float> intgrs = new List<float>();

            foreach (Experimento experimento in listaExperimentos)
            {
                float fun = f / (Math.Exp(experimento.P) + Math.Exp(-experimento.P));
                sum += fun;
                valores.Add(experimento.P);
                intgrs.Add(fun);
            }

            float integral = sum / n;
            this.textBox5.Text = integral.ToString();

            foreach (float x_i in valores)
            {
                float func = ((b - a) / n) * x_i;
                sumatoria += func;
            }
            float suma = sumatoria;
            this.textBox6.Text = suma.ToString();

            // Paso 5: Llenar DataTable
            for (int i = 0; i < n; i++)
            {
                ////ifloat aleatorio = rand.NextDouble(a, b);
                dt.Rows.Add(i + 1, valores, intgrs);
            }



            // Paso 6: Asignar DataTable a dataGridView1
            dataGridView1.DataSource = dt;
        }

    }
    
}
