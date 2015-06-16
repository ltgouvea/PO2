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
        double a, b, l, epsilon, delta, x, fx, u, fu, lambda, flambda, minimo;
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
        /// Colocar informações do método aqui
        /// </summary>

        public void BuscaUniforme()
        {
            double fAntigo, xDescarte;
            k = 0;
            m.X = a;
            fAntigo = m.ValueAsDouble;
           

            do
            {
                a += delta;
                m.X = a;
                fx = m.ValueAsDouble;

                if (fx > fAntigo)
                {
                    xDescarte = Convert.ToDouble(m.X);
                    a -= delta;
                    m.X = a;
                    delta = delta / 10;                     
                    while (Convert.ToDouble(m.X) < xDescarte)
                    {
                        k++;
                        fAntigo = m.ValueAsDouble;
                        a += delta;
                        m.X = a;
                        fx = m.ValueAsDouble;
                        if (fx > fAntigo)
                        {
                            minimo = fAntigo;
                            break;
                        }
                    }
                }
                else
                {
                    k++;
                    textBoxResultado.AppendText("\r\n K =" + Convert.ToString(k) +"A: "+ Convert.ToString(a) + " minimo: " + Convert.ToString(minimo));
                }
                minimo = fAntigo;

            } while (fx < fAntigo);


            






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
        /// <summary>
        /// Colocar informações do método aqui
        /// </summary>
        
        public void SecaoAurea()
        {

        }
        //Fim - Seção Áurea

        //Busca Dicotômica
        /// <summary>
        /// Colocar informações do método aqui
        /// </summary>
        
        public void Dicotomica()
        {

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
        //Fim - Método de Newton
        
        //Fim dos métodos
    }

}
