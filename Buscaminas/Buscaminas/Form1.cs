using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 *  NOMBRE:
 *  APELLIDOS: 
 *  ESTO ES UNA PRUEBA DE GITHUB
 * 
 */

namespace Buscaminas
{
    public partial class Form1 : Form
    {
        //declaro el array de botones
        Button[,] matrizBotones;
        int filas = 20;
        int columnas = 20;
        int anchoBoton = 20;
        int minas = 20;
        public Form1()
        {
            InitializeComponent();
          

            this.Height = columnas * anchoBoton + 40;
            this.Width = filas * anchoBoton + 20;

            matrizBotones = new Button[filas, columnas];

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    Button boton = new Button();
                    //boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    boton.Width = anchoBoton;
                    boton.Height = anchoBoton;
                    boton.Location = new Point(i * anchoBoton, j * anchoBoton);
                    boton.Click += chequeaBoton;
                    boton.Tag = "0";
                    matrizBotones[i, j] = boton;
                    panel1.Controls.Add(boton);

                }
            poneMinas();
            cuentaMinas();
        }

        private void cuentaMinas()
        {
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    int numeroBombas = 0;

                    for (int k = -1; k < 2; k++)
                    {
                        for (int m = -1; m < 2; m++)
                        {
                            int f = i + k;
                            int c = j + m;

                            if ((c < filas) && (c >=0 ) && (f < columnas) && (f >= 0))
                            {

                                if (matrizBotones[c, f].Tag =="B")
                                {
                                    numeroBombas++;
                                }
                            }
                        }
                    }
                    if ((matrizBotones[j, i].Tag != "B")&&
                        (numeroBombas > 0))
                    {
                        matrizBotones[j, i].Tag = numeroBombas.ToString();
                        matrizBotones[j, i].Text = numeroBombas.ToString();
                    }

                }
        }
        private void poneMinas()
        {
            Random aleatorio = new Random();
            int x, y = 0;
            for (int i = 0; i < minas; i++)
            {
                x = aleatorio.Next(filas);
                y = aleatorio.Next(columnas);
                while (!matrizBotones[x, y].Tag.Equals("0"))
                {
                    x = aleatorio.Next(filas);
                    y = aleatorio.Next(columnas);
                }
                    matrizBotones[x, y].Tag = "B";
                    matrizBotones[x, y].Text = "B";
                    matrizBotones[x, y].BackColor = Color.Orange;
                }
        }

        private void chequeaBoton(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            
            //b.BackColor = Color.Linen;
            int columna = b.Location.X / anchoBoton;
            int fila = b.Location.Y / anchoBoton;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((columna + j < filas)&&(columna + j  >= 0)&& (fila +i < columnas)&&(fila+i >=0))
                    {

                        if(matrizBotones[columna + j, fila + i].BackColor != Color.LimeGreen){

                        matrizBotones[columna + j, fila + i].BackColor = Color.LimeGreen;
                        chequeaBoton(matrizBotones[columna + j, fila + i],e );


                    }
                }
            }
            }


          /*  matrizBotones[columna, fila].BackColor = Color.LimeGreen;
            matrizBotones[columna -1, fila].BackColor = Color.LimeGreen;
            matrizBotones[columna+1, fila].BackColor = Color.LimeGreen;
            matrizBotones[columna-1, fila-1].BackColor = Color.LimeGreen;
            matrizBotones[columna, fila-1].BackColor = Color.LimeGreen;
            matrizBotones[columna+1, fila-1].BackColor = Color.LimeGreen;
            matrizBotones[columna-1, fila+1].BackColor = Color.LimeGreen;
            matrizBotones[columna, fila+1].BackColor = Color.LimeGreen;
            matrizBotones[columna+1, fila+1].BackColor = Color.LimeGreen;
             */ 


        }
    }
}
