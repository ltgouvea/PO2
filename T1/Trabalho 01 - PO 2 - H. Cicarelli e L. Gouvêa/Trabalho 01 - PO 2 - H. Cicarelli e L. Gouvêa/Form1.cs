﻿using Bestcode.MathParser;
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
        string F;
        double a, b, l, epsilon, delta;
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
            }
            else
            {
                MessageBox.Show("Erro na entrada de dados");
               textBoxA.Focus;
            }
        }
        //Fim - Método de Newton
        
        //Fim dos métodos
    }

}
