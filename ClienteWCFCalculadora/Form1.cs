using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClienteWCFCalculadora.ServiceCalculadora;
using System.ServiceModel;

namespace ClienteWCFCalculadora
{

    public partial class Form1 : Form
    {
        ServicioCalculadoraClient client;
        public Form1()
        {
            client=new ServicioCalculadoraClient();
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //capturamos los numeros de las cajas
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;

            if(text1=="" || text2=="")
            {
                MessageBox.Show("Error: Debe introducir un número en ambos campos");
            }
            else
            {
                try
                {
                    float n1 = float.Parse(text1);
                    float n2 = float.Parse(text2);
                    client.Division(n1, n2);
                }
                catch (FaultException<ServiceCalculadora.ExcepcionPersonalizada> ex)
                {
                    MessageBox.Show(ex.Detail.DetailError + "-" + ex.Detail.InternalCodeError+" de "+ex.Detail);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
