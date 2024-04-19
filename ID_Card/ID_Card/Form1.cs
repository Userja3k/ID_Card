using System;
using QRCoder;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace ID_Card
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*void Informations()
        {
            String Roll, Class, Year, Name, Program;

            Roll = txtRoll.ToString();
            Class = txtClass.ToString();
            Year = txtYear.ToString();
            Name = txtName.ToString();
            Program = txtProgram.ToString();
        }*/
        //private Panel panelToPrint;
        //private PrintDocument printDocument;
        //private PrintPageEventHandler PrintPage;
        //private PointF PageBounds;

        //public void PanelPrinter(Panel panelCard)
        //{
        //    panelToPrint = panelCard;
        //    printDocument = new PrintDocument();
        //    printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

        //    Bitmap bmp = new Bitmap(panelCard.Width, panelCard.Height);
        //    panelCard.DrawToBitmap(bmp, new Rectangle(0, 0, panelCard.Width, panelCard.Height));

        //    //PointF PageBound = 0;
        //    //Graphics.DrawImage(bmp,PageBound);
        //}

        //public void Print()
        //{
        //    PrintDialog printDialog = new PrintDialog();
        //    printDialog.Document = printDocument;
            
        //    if(printDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        printDocument.Print();
        //    }
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGenQr_Click(object sender, EventArgs e)
        {
            //String Roll, Class, Year, Name, Program;

            /*txtRoll.Text = txtRoll.ToString();
            txtClass.Text = txtClass.ToString();
            txtYear.Text = txtYear.ToString();
            txtName.Text = txtName.ToString();
            txtProgram.Text = txtProgram.ToString();*/

            //txtInformation.Text = txtInformation.ToString(txtRoll.ToString(); txtClass.ToString(); txtYear.ToString(); txtName.ToString(); txtProgram.ToString(); );

            string text1 = txtRoll.Text;
            string text2 = txtClass.Text;
            string text3 = txtYear.Text;
            string text4 = txtName.Text;
            string text5 = txtProgram.Text;

            string message = "Roll = " + text1 + "\n" + " Class = " + text2 + "\n" + " Year = " + text3 + "\n" + " Name = " + text4 + "\n" + " Program = " + text5;

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(message.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            picQR.Image = code.GetGraphic(5);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "File(*.jpg, *.jpeg, *.png, *.gif, *.bmp)| *.jpg, *.jpeg, *.png, *.gif, *.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;
                picStudent.Image = Image.FromFile(imagePath);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += (s, ev) =>
            {
                Bitmap bmp = new Bitmap(panelCard.Width, panelCard.Height);
                panelCard.DrawToBitmap(bmp, new Rectangle(0, 0, panelCard.Width, panelCard.Height));

                ev.Graphics.DrawImage(bmp, 0, 0);
            };
            PrintDialog dialog = new PrintDialog();
            dialog.Document = document;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }

            //Graphics.DrawImage(bmp, PageBounds);
            try { 
            PanelPrinter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PanelPrinter()
        {
            throw new NotImplementedException();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtRoll.Text = "";
            txtClass.Text = "";
            txtYear.Text = "";
            txtName.Text = "";
            txtProgram.Text = "";
            ControlEventHandler PicStudent_ControlRemoved = null;
            picStudent.ControlRemoved -= PicStudent_ControlRemoved;
            ControlEventHandler PicQR_ControlRemoved = null;
            picQR.ControlRemoved -= PicQR_ControlRemoved;
        }
         private void panelCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
