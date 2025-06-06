using System;
using System.Windows.Forms;


namespace CalculadoraInterface
{
    public partial class Form1 : Form
    {

        TextBox txtDisplay;
        double valor1 = 0;
        string operacao = "";


        public Form1()
        {
            InitializeComponent();
            CriarInterface();
        }

        void CriarInterface()
        {
            this.Text = "Calculadora";
            this.Width = 250;
            this.Height = 350;


            txtDisplay = new TextBox();
            txtDisplay.Top = 10;
            txtDisplay.Left = 10;
            txtDisplay.Width = 210;
            txtDisplay.ReadOnly = true;
            txtDisplayTextAling = HorizontalAlignment.Right;
            this.Controls.Add(txtDisplay);


            string[] botoes = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", "C", "=", "+" };

            int x = 10, y = 50;
            for (int i = 0; i < botoes.Length; i++)
            {
                Button btn = new Button();
                btn.Text = botoes[i];
                btn.Width = 50;
                btn.Height = 40;
                btn.Left = x;
                btn.Top = y;
                btn.Click += Btn_Click;
                this.Controls.Add(btn);


                x += 55;
                if ((i + 1) % 4 == 0)
                {
                    x = 10;
                    y += 45;
                }
            }
        }


        private void Btn_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            string texto = btn.Text;


            if (char.IsDigit(texto, 0))
            {
                txtDisplay.Text += texto;
            }
            else if (texto == "C")
            {
                txtDisplay.Clear();
                valor1 = 0;
                operacao = "";
            }
            else if (texto == "=")
            {
                double valor2 = double.Parse(txtDisplay.Text);
                double resultado = 0;

                switch (operacao)
                {
                    case "+": resultado = valor1 + valor2; break;
                    case "-": resultado = valor1 - valor2; break;
                    case "*": resultado = valor1 * valor2; break;
                    case "/": resultado = valor2 != 0 ? valor1 / valor2 : 0; break;
                }


                txtDisplay.Text = resultado.ToSring();
                operacao = "";
            }

            else {
                valor1 = double.Parse(txtDisplay.Text);
                operacao = texto;
                txtDisplay.Clear();
            }
        }

    }

}