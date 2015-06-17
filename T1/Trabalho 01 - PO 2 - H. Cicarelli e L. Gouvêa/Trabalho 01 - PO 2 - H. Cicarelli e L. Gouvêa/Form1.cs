using Bestcode.MathParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Trabalho_01___PO_2___H.Cicarelli_e_L.Gouvêa
{
    public partial class Form1 : Form
    {
        
        int metodo = -1;
        int k;
        string F;
        double a, b, l, epsilon, delta, x, u, fu, lambda, flambda, minimo;
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
            return true;
                
        }
        
        //Escolha do método pelos radioButtons
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 5;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            metodo = 6;
        }
        //Fim da escolha dos métodos

        //Métodos propriamente ditos
        
        //Busca Uniforme 
        /// <summary>
        /// fAntigo = valor da função da iteração anterior (f(a - delta))
        /// xDescarte = ponto pra marcar o refinamento
        /// </summary>

        public void BuscaUniforme()
        {
            double fAntigo, fx, q = 0;
            k = 0;
            m.X = a;
            fAntigo = m.ValueAsDouble;
            bool achou = false;


            while ((achou == false) && ((b - a) > l))
            {
                
                a += delta;
                m.X = a;
                fx = m.ValueAsDouble;

                //Refinamento
                if (fx > fAntigo)
                {
                    //xDescarte = Convert.ToDouble(m.X);
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
                            break;
                        }
                    }
                }
                else
                {
                    k++;
                    textBoxResultado.AppendText("\r\n | K = " + Convert.ToString(k) + "|  Delta =  " + Convert.ToString(delta) + "| A =   " + Convert.ToString(a) + "|  F(x)=  " + m.ValueAsString);
                }
                

            }

           

            minimo = fAntigo;
            






        }
        //Fim - Busca Uniforme

        //Bisseção
        /// <summary>
        /// Colocar informações do método aqui
        /// </summary>

        public void Bissecao()
        {

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

                if (k == 100)
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
        /// Colocar informações do método aqui
        /// </summary>
        
        public void BuscaFibonacci()
        {

        }
        //Fim - Fibonacci

        //Newton
        /// <summary>
        /// Colocar informações do método aqui
        /// </summary>
         
        public void Newton()
        {

        }

        //Botão de calcular
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
        //Fim - Método de Newton
        
        //Fim dos métodos
    }

}
