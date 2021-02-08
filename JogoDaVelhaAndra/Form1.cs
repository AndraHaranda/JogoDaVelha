using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelhaAndra
{
    public partial class Form1 : Form
    {
        
            //Turn true = X
            //Turn false = O (IA)

            string[] textos = new string[9];
            int rodadas = 0;
        bool turn = true, fimDeJogo = false;
        bool PlayerIA = false;
            Random rdn = new Random();

        void ChecarVencedor()
        {
            // Horizontais:
            string Vazio = turn ? "X" : "O";

            for (int i = 0; i <= 6; i += 3)
            {

                if (textos[i] == Vazio && textos[i] == textos[i + 1] && textos[i] == textos[i + 2])
                {

                    Vencedor();

                }
            }

            // Verticais:
            for (int i = 0; i <= 2; i++)
            {
                if (textos[i] == Vazio && textos[i] == textos[i + 3] && textos[i] == textos[i + 6])
                {

                    Vencedor();

                }
            }

            // Diagonais:
            if (textos[0] == Vazio && textos[0] == textos[4] && textos[0] == textos[8]) { Vencedor(); }; // Diagonal principal
            if (textos[2] == Vazio && textos[2] == textos[4] && textos[2] == textos[6]) { Vencedor(); }; // Diagonal secundária

            // Empate:
            if (rodadas == 9 && !fimDeJogo)
            {

                fimDeJogo = true;
                MessageBox.Show("Empate!");

            }
        }

        void Vencedor()
        {

            fimDeJogo = true;
            MessageBox.Show(String.Format("Jogador {0} venceu!", turn ? "X" : "O"));

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (turn && !fimDeJogo && btn.Text == "")
            {
                btn.Text = "X";
                textos[btn.TabIndex] = btn.Text; rodadas++;
                ChecarVencedor();
                turn = !turn;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

       private void Random()
       {
            //Randomizar um lugar vazio && marcar o botão 
            bool encontrarJogada = false;

            if (!turn)
            {
                while (!encontrarJogada)
                {
                    int sortear = rdn.Next(0, 9);

                    foreach (var bt in Controls.OfType<Button>())
                    {
                        if (bt.Text == "" && bt.TabIndex == sortear)
                        {
                            encontrarJogada = true;
                            PlayIA(sortear);
                        }
                    }
                }

            }
       }

        private void PlayIA(int tabindex)
        {
            foreach (var bt in Controls.OfType<Button>())
            {
                if (bt.TabIndex == tabindex && !turn && bt.Text == "")
                {
                    bt.Text = "O"; textos[bt.TabIndex] = bt.Text; rodadas++;
                    PlayerIA = true; 
                    ChecarVencedor(); 
                    turn = !turn;
                }
            }
        }

        private void ValidaçãoIA (string player)
        {

        }

    }
}
