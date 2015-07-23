using Bestcode.MathParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Trabalho_01___PO_2___H.Cicarelli_e_L.Gouvêa
{
    public partial class Form1 : Form
    {
        
        int metodo = -1;
        int k;
        string F;
        double a, b, l, epsilon, delta, x, u, fu, lambda, flambda, minimo;
        double[] x_Zero;
        MathParser m = new MathParser();
        public Form1()
        {
            InitializeComponent();
            
            //Temos que aprender a usar as paradinhas do parser, tem documentação na pasta acho
        }

        //Função pra verificar entrada de dados: O parser não aceita coisas como x² ou 3x representando produto, sempre tem que usar * ou ^ como sinais
        public bool Verifica()
        {
            
            try
            {
                m.Expression = textBoxFuncao.Text;
                m.Parse();
                a = Convert.ToDouble(textBoxA.Text);
                b = Convert.ToDouble(textBoxB.Text);
                l = Convert.ToDouble(textBoxL.Text);
                epsilon = Convert.ToDouble(textBoxEpsilon.Text);
                delta = Convert.ToDouble(textBoxDelta.Text);


            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na entrada de dados: " + e.Message);
                return false;
                
            }

            /// PARA AS MULTIVARIÁVEIS
            if (metodo > 6)
            {
                try
                {
                    x_Zero[0] = Convert.ToDouble(textBox1.Text);
                    x_Zero[1] = Convert.ToDouble(textBox2.Text);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro na entradada de dados.");
                    throw;
                }

            }
            return true;
                
        }
        
        //Escolha do método pelos radioButtons
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 1;
            textBox1.Enabled = false;
            textBox2.Enabled =false;   
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 2;
            textBox1.Enabled = false;
            textBox2.Enabled = false;   
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 3;
            textBox1.Enabled = false;
            textBox2.Enabled = false;   
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 4;
            textBox1.Enabled = false;
            textBox2.Enabled = false;   
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 5;
            textBox1.Enabled = false;
            textBox2.Enabled = false;   
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 6;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 7;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 8;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 9;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 10;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 11;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        //Fim da escolha dos métodos

        //Métodos propriamente ditos

        ///CALCULO DE DERIVADAS
        ///DERIVADA PRIMEIRA
       
        public double DerivadaPrimeira(double x)
        {
            double fx, fxmaish, fxmenosh;
            double h = 0.25;

            double derivada;

            while (h > epsilon)
            {

            
                //f(x)
                m.X = x;
                fx = m.ValueAsDouble;

                //f(x+h)
                x += h;
                m.X = x;
                fxmaish = m.ValueAsDouble;

                //f(x - h) 
                x -= (2 * h);
                m.X = x;
                fxmenosh = m.ValueAsDouble;

                derivada = (fxmaish - fxmenosh) / (2 * h);

                if (derivada <= epsilon)
                {
                    return (derivada);
                }
                else
                {
                    h /= 2;
                    k++;
                }

                if (k == 100)
                {
                    return (derivada);
                }

                }//Fim do loop

            return -1;
            

        }

        //FIM - Derivada primeira
        //Derivada segunda

        public double DerivadaSegunda(double x)
        {
            double fx, fxmaish, fxmenosh;
            double h = 0.25;

            double derivada;

            while (h > epsilon)
            {


                //f(x)
                m.X = x;
                fx = m.ValueAsDouble;

                //f(x+2h)
                x += (2*h);
                m.X = a;
                fxmaish = m.ValueAsDouble;

                //f(x - 2h) 
                x -= 4*h;
                
                fxmenosh = m.ValueAsDouble;

                derivada = ((fxmaish + fxmenosh) - (2*fx)) / (4 * h * h);

                if (derivada <= epsilon)
                {
                    return (derivada);
                }
                else
                {
                    h /= 2;
                    k++;
                }

                if (k == 100)
                {
                    return (derivada);
                }

            }//Fim do loop

            return -1;


        }


        
        //Busca Uniforme 
        /// <summary>
        /// fAntigo = valor da função da iteração anterior (f(a - delta))
        /// xDescarte = ponto pra marcar o refinamento
        /// </summary>

        public void BuscaUniforme()
        {
            textBoxResultado.Clear();
            double fAntigo, fx, q = 0;
            k = 0;
            m.X = a;
            fAntigo = m.ValueAsDouble;
            bool achou = false;


            while ((achou == false) && ((b - a) > l))
            {
                fAntigo = m.ValueAsDouble;
                a += delta;
                m.X = a;
                fx = m.ValueAsDouble;

                //Refinamento
                if (fx > fAntigo)
                {
                    fAntigo = m.ValueAsDouble;
                    a -= (2*delta);
                    m.X = a;
                    q = delta / 10;                     
                    while (fAntigo < fx)
                    {
                        k++;
                        fAntigo = m.ValueAsDouble;
                        a += q;
                        m.X = a;
                        fx = m.ValueAsDouble;
                        textBoxResultado.AppendText("\r\n | K = " + Convert.ToString(k) +"|  Q =  " + Convert.ToString(q) +  "| A =   " + Convert.ToString(a) + "|  F(x)=  " + m.ValueAsString);
                        if (fx > fAntigo)
                        {
                            minimo = Convert.ToDouble(m.X);
                            achou = true;
                            return;
                        }
                    }
                }
                else
                {
                    k++;
                    textBoxResultado.AppendText("\r\n | K = " + Convert.ToString(k) + "|  Delta =  " + Convert.ToString(delta) + "| A =   " + Convert.ToString(a) + "|  F(x)=  " + m.ValueAsString);
        
                }

                if(k == 200)
                {
                    break;
                }
                

            }

           

            minimo = fAntigo;
            






        }
        //Fim - Busca Uniforme

        //Bisseção
        /// <summary>
        /// Bisseção : aparentemente OK
        /// </summary>

        public void Bissecao()
        {
            textBoxResultado.Clear();

            while ((b - a) > l)
            {
                k++;
                x = (a + b) / 2;
                double dfdx = DerivadaPrimeira(x);
                if (dfdx > 0)
                {
                    b = x;
                }
                if (dfdx < 0)
                {
                    a = x;
                }
                if (dfdx == 0)
                {
                    textBoxResultado.AppendText("| K = " + Convert.ToString(k) + " | a = " + Convert.ToString(a) + " | b" + Convert.ToString(b) +
                                                " | x = " + Convert.ToString(x));
                    break;
                }
                if (k == 500)
                {
                    break;
                }

                
            }
            textBoxResultado.AppendText("| K = " + Convert.ToString(k) + " | a = " + Convert.ToString(a) + " | b" + Convert.ToString(b) +
                                        " | x = " + Convert.ToString(x));

        }
        //Fim - Bisseção

        //Seção Áurea
        /// <summary> SEÇÃO ÁUREA
        /// alpha = 0,618
        /// beta = 0,382
        /// 
        /// </summary>
        
        public void SecaoAurea()
        {
            textBoxResultado.Clear();
            double beta = 0.382;
            double alpha = 0.618;

            u = a + beta * (b - a);
            lambda = a + alpha * (b - a);

            while ((b-a) > l)
            {
                k++;
                m.X = u;
                fu = m.ValueAsDouble;
                m.X = lambda;
                flambda = m.ValueAsDouble;
                
                textBoxResultado.AppendText("\r\n| K = " + Convert.ToString(k) + "| u = " + Convert.ToString(u) + "| lambda = " + Convert.ToString(lambda) + "| f(u) = " + Convert.ToString(fu) +"| f(lambda) = " + Convert.ToString(flambda));
                if (fu > flambda)
                {
                    a = u;
                    u = lambda;
                    lambda = a + alpha * (b - a);
                }

                if (flambda > fu)
                {
                    b = lambda;
                    lambda = u;
                    u = a + beta*(b - a);
                }

                if (k >= 100)
                {
                    break;
                }
            }

            x = (a + b) / 2;
            textBoxResultado.AppendText("\r\n X = " + Convert.ToString(x));

        }
        //Fim - Seção Áurea

        //Busca Dicotômica
        /// <summary>
        /// busca Dicotômica
        /// x = (a+b)/2 - epsilon 
        /// z = (a+b)/2 + epsilon
        /// se f(x) > f(z)
        /// a = x
        /// senão
        /// b = z
        /// </summary>
        
        public void Dicotomica()
        {
            textBoxResultado.Clear();
            double Fx, Fz,x, z;
            k = 0;
            //Inicializando variáveis
            while ((b-a) >= l)
            {
                k++;
                x = ((a + b) / 2) - epsilon;
                z = ((a + b) / 2) + epsilon;
                m.X = x;
                Fx = m.ValueAsDouble;
                m.X = z;
                Fz = m.ValueAsDouble;
                if (Fx > Fz)
                {
                    a = x;
                }
                else
                {
                    b = z;
                }
                if ((b - a) <= l)
                {
                    break;
                }
                textBoxResultado.AppendText("\r\n | k = " + Convert.ToString(k) + "| x = " + Convert.ToString(x) + "| z = " + Convert.ToString(z) +
                                            "| F(x) = " + Convert.ToString(Fx) + " | F(z) = " + Convert.ToString(Fz));
                if (k == 1000)
                {
                    break;
                }

            }

            x = (a + b)/2;
            textBoxResultado.AppendText("\r\n X* = " + Convert.ToString(x));


        }
        //Fim - Busca Dicotômica

        //Fibonacci
        /// <summary>
        /// Fibonacci : estoura o vetor às vezes
        /// </summary>
        
        public void BuscaFibonacci()
        {
            textBoxResultado.Clear();
            double[] F;
            double Fn;
            F = new double[110];
            F[0] = 1;
            F[1] = 1;
            int i, j;
            
            Fn = (b-a) / l;
            j = 0;

            for (i = 2; i < 1000; i++)
			{
			    F[i] = F[i-1] + F[i-2];
                if ((F[i] > Fn) || i == 1000)
                {
                    j++;
                    break;
                }
			}
            try
            {
                u = a + (F[j - k - 2] / F[j - k]) * (b - a);
                lambda = a + (F[j - k - 1] / F[j - k]) * (b - a);
            }
               catch (System.IndexOutOfRangeException e)
            {                
                x = (a + b) / 2;
                textBoxResultado.AppendText("\r\n X = " + Convert.ToString(x));
                return;
            }
            while (((b-a) > l) && ((j-k) > 1))
	        {   
	            k++;
                m.X = u;
                fu = m.ValueAsDouble;
                m.X = lambda;
                flambda = m.ValueAsDouble;
                
                textBoxResultado.AppendText("\r\n| K = " + Convert.ToString(k) + "| u = " + Convert.ToString(u) + "| lambda = " + Convert.ToString(lambda) + "| f(u) = " + Convert.ToString(fu) +"| f(lambda) = " + Convert.ToString(flambda));
                if ((i-k) == 0)
                {
                    return;
                }
                if (fu > flambda)
                {
                    a = u;
                    u = lambda;
                    lambda = a + (F[j - k - 1] / F[j - k]) * (b - a);
                }

                if (flambda > fu)
                {
                    b = lambda;
                    lambda = u;
                    u = a + (F[j - k - 2] / F[j - k]) * (b - a);        
                    
                      
                }

                if ((k == 100) ||((i-k) == 0))
                {
                    return;
                }   
	        }
            
            x = (a + b) / 2;
            textBoxResultado.AppendText("\r\n X = " + Convert.ToString(x));

        }        
        //Fim - Fibonacci


        //Newton
        /// <summary>
        /// Algoritmo:
        /// dados: função, ponto inicial (padrão: a + b / 2), erro
        /// x[k+1] = x[k] - derivadaprimeira / derivadasegunda
        /// </summary>
         
        public void Newton()
        {
            textBoxResultado.Clear();
            double x, derivada_prim, derivada_seg;
            double xnovo;
            x = (a + b) / 2;
            m.X = x;
            xnovo = 0;

            derivada_prim = DerivadaPrimeira(x);
            derivada_seg = DerivadaSegunda(x);

            while (Math.Abs(derivada_prim) > epsilon)
            {
                k++;
                xnovo = (x - (derivada_prim / derivada_seg));
                x = xnovo;
                textBoxResultado.AppendText("\r\n| x = " + Convert.ToString(x) + " | F'(x)" + Convert.ToString(derivada_prim) +
                                            " | F''(x) = " + Convert.ToString(derivada_seg));
                if (derivada_prim == 0)
                {
                    break;
                }
                if (k >= 100)
                {
                    break;
                }

                if (Math.Abs(derivada_prim) < epsilon)
                {
                    break;
                }

            }
            
            textBoxResultado.AppendText("\r\n | X* = " + Convert.ToString(xnovo) + " |   F(x) = " + Convert.ToString(m.ValueAsDouble) +
                "| F'(x) =  " + Convert.ToString(DerivadaPrimeira(xnovo)) );

            
        }

        //FIM DOS MÉTODOS PARA MONOVARIÁVEIS
        //Início dos métodos para multivariáveis
        //7 - Hooke and Jeeves
        //8 - Newton
        //9 - Gradiente
        //10 - Fletcher Reeves
        //11 - Davidon Fletcher Powell
        //Botão de calcular

        public void HookeAndJeeves ()
        {
            MessageBox.Show("Método ainda não implementado");
        }
        public void NewtonMultivar ()
        {
            MessageBox.Show("Método ainda não implementado");
        }
        public void Gradiente () 
        {
            MessageBox.Show("Método ainda não implementado");
        }
        public void FletcherReeves ()
        {
            MessageBox.Show("Método ainda não implementado");
        }
        public void DFPowell ()
        {
            MessageBox.Show("Método ainda não implementado");
        }

//Fim dos métodos propriamente ditos

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            if (Verifica() == true)
            {
                //Aplicar o método escolhido
                switch (metodo)
                {
                    case 1:
                        BuscaUniforme();
                        break;
                    case 2:
                        Bissecao();
                        break;
                    case 3:
                        SecaoAurea();
                        break;
                    case 4:
                        Dicotomica();
                        break;
                    case 5:
                        BuscaFibonacci();
                        break;
                    case 6:
                        Newton();
                        break;
                    case 7:
                        HookeAndJeeves();
                        break;
                    case 8:
                        NewtonMultivar();
                        break;
                    case 9:
                        Gradiente();
                        break;
                    case 10:
                        FletcherReeves();
                        break;
                    case 11:
                        DFPowell();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Erro na entrada de dados");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///Limpar campos
            textBoxA.Clear();
            textBoxB.Clear();
            textBoxDelta.Clear();
            textBoxEpsilon.Clear();
            textBoxL.Clear();
            textBoxResultado.Clear();
            textBoxFuncao.Clear();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("\tPrograma desenvolvido por:\r\n\tLucas T. A. Gouvêa\r\n\te\r\n\tHugo Cicarelli\r\n\tUNESP Bauru, 2015");
        }

        
        

        

        
        

        

        
        

        

        
        

        

        
        

        
        
        //Fim dos métodos
    }

}
