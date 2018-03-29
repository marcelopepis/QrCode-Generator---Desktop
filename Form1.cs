//Programa gerador de Qrcode para a empresa Megabarre
//Feito por Marcelo de Paula Pepis
//29/03/2018

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCode_Generator
{
    public partial class Form1 : Form
    {
        Image File;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {//eventos do botão gerar.
            QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            var qrData = qrGenerator.CreateQrCode(textBox1QrText.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCoder.QRCode(qrData);
            var image = qrCode.GetGraphic(150); //imagem gerada.
            pictureBox1Qrc.Image = image; //colocando a imagem na caixa de imagens.
            button2SaveImage.Visible = true;//depois de gerada a imagem, definimos o botão salvar como visivel.
            File = pictureBox1Qrc.Image; //colocamos a imagem do qrcode em um arquivo do tipo Image.
        }

        private void button2_Click(object sender, EventArgs e)
        {//eventos do botao salvar.
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "JPEG(*.JPEG)|*.jpeg";//definimos um filtro de tipo de imagem, para salvarmos a imagem somente como JPEG.
            if (f.ShowDialog() == DialogResult.OK) //criando a caixa de dialogos para savar.
            {
                File.Save(f.FileName);
            }          
        }
    }
}
