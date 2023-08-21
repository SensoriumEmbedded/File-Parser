using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Text_File_Parser
{
    public partial class frmMain : Form
    {
        const int MinWidth = 500;
        const int MinHeight = 400;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmMain_ResizeEnd(this, EventArgs.Empty);
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < MinWidth) this.Width = MinWidth;
            if (this.Height < MinHeight) this.Height = MinHeight;

            rtbOutput.Width = this.Width - rtbOutput.Location.X - 25;
            rtbOutput.Height = this.Height - rtbOutput.Location.Y - 50;
            rtbOutput.ScrollToCaret();
        }

//_______________________________general use:___________________________________________

        private void WriteToOutput(string strMsg, Color color, bool IncludeReturn = true)
        {
            rtbOutput.SelectionColor = color;
            rtbOutput.AppendText(strMsg);
            if (IncludeReturn) rtbOutput.AppendText("\r");
            rtbOutput.ScrollToCaret();
        }

//_______________________________buttons:___________________________________________
        private void btnClearDisp_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
        }

        private void btnThousandTrails_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = Application.StartupPath;
            //openFileDialog1.FileName = Path.GetFileName(tbMEIDFileName.Text);
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;                

            WriteToOutput("Thousand Trails File Parse", Color.DarkBlue);
            string sInLine = "";
            string sPrevLine = "";

            try
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);

                while(true)
                {
                    while(!sInLine.StartsWith("Reservation #"))
                    {
                        sPrevLine = sInLine;
                        if ((sInLine = sr.ReadLine()) == null) return;
                    }
                    //WriteToOutput(sPrevLine, Color.Red);

                    while (!sInLine.StartsWith("DATESCheck In:")) if ((sInLine = sr.ReadLine()) == null) return;
                
                    WriteToOutput(sPrevLine + "*" + sInLine, Color.BlueViolet);
            
                    //WriteToOutput(sInLine, Color.BlueViolet);
                }
                //sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "File Read Error");
            }

        }

        private void btnSpiralST3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "sit files (*.sit)|*.sit|st3 files (*.st3)|*.st3|All files (*.*)|*.*";
            //openFileDialog1.InitialDirectory = Application.StartupPath;
            //openFileDialog1.FileName = Path.GetFileName(tbMEIDFileName.Text);
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            WriteToOutput("Spiral SIT/ST3 Parse", Color.DarkBlue);
            WriteToOutput("Entry per line to CSV", Color.DarkBlue);

            foreach (String file in openFileDialog1.FileNames)
            {
                try
                {
                    StreamReader sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {
                        WriteToOutput(sr.ReadLine().Replace("\"","").PadLeft(5) + ",", Color.Blue, false);
                        //if ((sInLine = sr.ReadLine()) == null) return;
                    }
                    sr.Close();
                    WriteToOutput("   // " + Path.GetFileName(file), Color.BlueViolet);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "File Read Error");
                }

            }

        }

        private void btnC64CharSet_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "64c files (*.64c)|*.64c|All files (*.*)|*.*";
            //openFileDialog1.InitialDirectory = Application.StartupPath;
            //openFileDialog1.FileName = Path.GetFileName(tbMEIDFileName.Text);
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            WriteToOutput("C64 char set viewer", Color.DarkBlue);

            foreach (String file in openFileDialog1.FileNames)
            {
                WriteToOutput("\r// " + Path.GetFileName(file), Color.BlueViolet);
                try
                {
                    BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open));

                    byte[] byteIn = new byte[8];
                    UInt32 charNum = 0;
                    if (file.EndsWith(".64c"))
                    {
                        byteIn = br.ReadBytes(2);  //know it will end on 32 bit boundry
                        WriteToOutput("First two bytes: " + byteIn[0] + " and " + byteIn[1], Color.DarkRed);
                    }

                    while (br.BaseStream.Position != br.BaseStream.Length && charNum < Convert.ToUInt32(tbMaxChars.Text))
                    {
                        byteIn = br.ReadBytes(8);  //know it will end on an 8 byte boundry?
                        WriteToOutput("Character number " + charNum++ ,Color.DarkGray);
                        rtbOutput.SelectionColor = Color.Black;
                        for (byte byteNum=0; byteNum < 8; byteNum++)
                        {
                            for (int bitNum = 7; bitNum >= 0; bitNum--)
                            {
                                if ((byteIn[byteNum] & (1<<bitNum)) == 0)
                                    rtbOutput.AppendText(" ");
                                else
                                    rtbOutput.AppendText("*");
                            }
                            rtbOutput.AppendText("\r");
                        }
                        WriteToOutput("----------------------------", Color.DarkBlue);
                    }
                    br.Close();

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "File Read Error");
                }

            }
        }

        private void btnC64CRTfile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "CRT files (*.crt)|*.crt|All files (*.*)|*.*";
            //openFileDialog1.InitialDirectory = Application.StartupPath;
            //openFileDialog1.FileName = Path.GetFileName(tbMEIDFileName.Text);
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            WriteToOutput("C64 CRT file parser", Color.DarkBlue);

            foreach (String file in openFileDialog1.FileNames)
            {
                WriteToOutput("\r// " + Path.GetFileName(file), Color.BlueViolet);
                try
                {
                    BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open));

                    byte[] byteIn = new byte[br.BaseStream.Length];
                    byteIn = br.ReadBytes(byteIn.Length);

                    WriteToOutput("File Size: " + byteIn.Length + " (" + byteIn.Length / 1024 + "k)", Color.DarkRed);

                    byteIn[14] = 0;
                    WriteToOutput("Title: " + byteIn.ToString(), Color.DarkBlue);
                    //UInt32 charNum = 0;
                    //if (file.EndsWith(".64c"))
                    //{
                    //    byteIn = br.ReadBytes(2);  //know it will end on 32 bit boundry
                    //    WriteToOutput("First two bytes: " + byteIn[0] + " and " + byteIn[1], Color.DarkRed);
                    //}
                    //
                    //while (br.BaseStream.Position != br.BaseStream.Length && charNum < Convert.ToUInt32(tbMaxChars.Text))
                    //{
                    //    byteIn = br.ReadBytes(8);  //know it will end on an 8 byte boundry?
                    //    WriteToOutput("Character number " + charNum++, Color.DarkGray);
                    //    rtbOutput.SelectionColor = Color.Black;
                    //    for (byte byteNum = 0; byteNum < 8; byteNum++)
                    //    {
                    //        for (int bitNum = 7; bitNum >= 0; bitNum--)
                    //        {
                    //            if ((byteIn[byteNum] & (1 << bitNum)) == 0)
                    //                rtbOutput.AppendText(" ");
                    //            else
                    //                rtbOutput.AppendText("*");
                    //        }
                    //        rtbOutput.AppendText("\r");
                    //    }
                    //    WriteToOutput("----------------------------", Color.DarkBlue);
                    //}
                    //br.Close();

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "File Read Error");
                }

            }

        }
    }
}
