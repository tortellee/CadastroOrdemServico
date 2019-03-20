using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CadastroOrdemServico

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

                private void Form1_Load(object sender, EventArgs e )
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            //Cria a pasta no diretorio X
            DirectoryInfo CriarPasta = new DirectoryInfo(@"C:\\Banco De Dados\\Cadastro Ordem Servico");

            //Se Caso a pasta existir Returna para o FORM , caso NÃO ele cria
            if (CriarPasta.Exists)
            {
                return;

            }
            else
            {
                CriarPasta.Create();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter arquivo;
            String caminho = "C:\\Banco De Dados\\Cadastro Ordem Servico\\Cadastro Servicos.txt";
            arquivo = File.AppendText(caminho);
            arquivo.WriteLine(" ");
            arquivo.WriteLine(menu.Text);
            arquivo.WriteLine(label3.Text + txt1.Text + label4.Text);
            arquivo.WriteLine(label2.Text + data.Text);
            arquivo.WriteLine(groupBox3.Text + comboBox3.Text);
            arquivo.WriteLine(groupBox1.Text + comboBox1.Text);
            arquivo.WriteLine(label5.Text + textBox3.Text);
            arquivo.WriteLine(label6.Text + data2.Text);
            arquivo.WriteLine(label7.Text + txt4.Text);                     
            arquivo.WriteLine("Cadastro Realizado: " + lblHora.Text + Environment.NewLine);
            arquivo.WriteLine("=================================================================");
            arquivo.Close();

            //limpa todos os controles do tipo TextBoxx
            txt1.Text = string.Empty;
            data.Text = string.Empty;
            comboBox3.Text = String.Empty;
            comboBox1.Text = String.Empty;
            textBox3.Text = String.Empty;
            data2.Text = String.Empty;
            txt4.Text = String.Empty;

            MessageBox.Show("Cadastrado de serviço realizado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);





            //Cria um botão com dialogo para continuar , S/N
            DialogResult dialogResult = MessageBox.Show("Deseja cadastrar outro serviço ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //Cria um IF para o botao acima , se caso SIM , ele returna para o FORM e o lIMPA os campos , caso NÃO ele o FECHA !
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {                
                return;
            }

            //Caso NÃO ele o FECHA !
            else
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string caminho = "C:\\Banco De Dados\\Cadastro Ordem Servico\\Cadastro Servicos.txt";
            System.Diagnostics.Process.Start("NOTEPAD", caminho);
        }
    }
}

