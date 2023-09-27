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

        UInt16 toU16(byte[] data, UInt32 offset)
        {
            return (UInt16)((data[offset] << 8) | data[offset + 1]);
        }

        UInt32 toU32(byte[] data, UInt32 offset)
        {
            return (UInt32)((data[offset] << 24) | (data[offset + 1] << 16) | (data[offset + 2] << 8) | data[offset + 3]);
        }

        string[] CartHWTypeName = new string[]
        {
            "Generic            ",   //  0  //Supported
            "ActionReplay       ",   //  1
            "KCSPowerCartridge  ",   //  2
            "FinalCartridgeIII  ",   //  3
            "SimonsBASIC        ",   //  4
            "Oceantype1         ",   //  5  //Supported
            "ExpertCartridge    ",   //  6
            "FunPlayPowerPlay   ",   //  7  //Supported
            "SuperGames         ",   //  8  //Supported
            "AtomicPower        ",   //  9
            "EpyxFastload       ",   // 10  //Supported
            "WestermannLearning ",   // 11
            "RexUtility         ",   // 12
            "FinalCartridgeI    ",   // 13
            "MagicFormel        ",   // 14
            "C64GameSystem3     ",   // 15  //Supported
            "WarpSpeed          ",   // 16
            "Dinamic            ",   // 17  //Supported
            "ZaxxonSuperZaxxon  ",   // 18
            "MagicDesk          ",   // 19  //Supported
            "SuperSnapshotV5    ",   // 20
            "Comal80            ",   // 21
            "StructuredBASIC    ",   // 22
            "Ross               ",   // 23
            "DelaEP64           ",   // 24
            "DelaEP7x8          ",   // 25
            "DelaEP256          ",   // 26
            "RexEP256           ",   // 27
            "MikroAssembler     ",   // 28
            "FinalCartridgePlus ",   // 29
            "ActionReplay4      ",   // 30
            "Stardos            ",   // 31
            "EasyFlash          ",   // 32
            "EasyFlashXbank     ",   // 33
            "Capture            ",   // 34
            "ActionReplay3      ",   // 35
            "RetroReplay        ",   // 36
            "MMC64              ",   // 37
            "MMCReplay          ",   // 38
            "IDE64              ",   // 39
            "SuperSnapshotV4    ",   // 40
            "IEEE488            ",   // 41
            "GameKiller         ",   // 42
            "Prophet64          ",   // 43
            "EXOS               ",   // 44
            "FreezeFrame        ",   // 45
            "FreezeMachine      ",   // 46
            "Snapshot64         ",   // 47
            "SuperExplodeV50    ",   // 48
            "MagicVoice         ",   // 49
            "ActionReplay2      ",   // 50
            "MACH5              ",   // 51
            "DiashowMaker       ",   // 52
            "Pagefox            ",   // 53
            "Kingsoft           ",   // 54
            "Silverrock128K     ",   // 55
            "Formel64           ",   // 56
            "RGCD               ",   // 57
            "RRNetMK3           ",   // 58
            "EasyCalc           ",   // 59
            "GMod2              ",   // 60
            "MAXBasic           ",   // 61
            "GMod3              ",   // 62
            "ZIPPCODE48         ",   // 63
            "BlackboxV8         ",   // 64
            "BlackboxV3         ",   // 65
            "BlackboxV4         ",   // 66
            "REXRAMFloppy       ",   // 67
            "BISPlus            ",   // 68
            "SDBOX              ",   // 69
            "MultiMAX           ",   // 70
            "BlackboxV9         ",   // 71
            "LtKernalHostAdaptor",   // 72
            "RAMLink            ",   // 73
            "HERO               ",   // 74
            "IEEEFlash64        ",   // 75
            "TurtleGraphicsII   ",   // 76
            "FreezeFrameMK2     ",   // 77
            "Partner64          ",   // 78
        };


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

            WriteToOutput("C64 CRT file parser", Color.DarkGreen);
            WriteToOutput("Path: " + Path.GetDirectoryName(openFileDialog1.FileName) + "\r", Color.DarkGreen);

            foreach (String file in openFileDialog1.FileNames)
            {
                WriteToOutput("*** " + Path.GetFileName(file), Color.DarkRed);
                try
                {
                    BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open));

                    byte[] byteIn = new byte[br.BaseStream.Length];
                    byteIn = br.ReadBytes(byteIn.Length);
                    br.Close();

                    string HWTypeName, HWConfig;
                    UInt16 HWTypeNum = toU16(byteIn, 0x16);
                    if (HWTypeNum <= CartHWTypeName.GetUpperBound(0)) HWTypeName = CartHWTypeName[HWTypeNum];
                    else HWTypeName = "**Unknown**";

                    byte EXROM = byteIn[0x18];
                    byte GAME = byteIn[0x19];
                    if      (EXROM == 0 && GAME == 0) HWConfig = "16k";
                    else if (EXROM == 0 && GAME == 1) HWConfig = "8kLo";
                    else if (EXROM == 1 && GAME == 0) HWConfig = "8kHi/Ultimax";
                    else if (EXROM == 1 && GAME == 1) HWConfig = "*None*";
                    else HWConfig = "**Unknown**";

                    WriteToOutput("File Size: " + byteIn.Length + " (" + byteIn.Length / 1024 + "k)" +
                        " HW Type: " + HWTypeName.TrimEnd(' ') + " (" + HWTypeNum + ")", Color.DarkRed);
                    WriteToOutput("Sig: " + Encoding.UTF8.GetString(byteIn, 0, 14) +
                        "  Name: " + Encoding.UTF8.GetString(byteIn, 0x20, 32), Color.DarkBlue);
                    WriteToOutput("Header Len: $" + toU32(byteIn, 0x10).ToString("X8") +
                        "  V:" + byteIn[0x14] + "." + byteIn[0x15] + " EX:" + EXROM + " GA:" + GAME + " Config:" + HWConfig, Color.DarkBlue);

                    UInt32 ChipStart = toU32(byteIn, 0x10); //Start at end of Header
                    UInt32 NumChips = 0;

                    if (cbChipInfo.Checked) WriteToOutput(" Chp# chip Length    Type  Bank  Addr  Size", Color.Blue);
                    while (ChipStart < byteIn.Length)
                    {
                        if (cbChipInfo.Checked) WriteToOutput(" #" + NumChips.ToString("D3") +
                            " " + Encoding.UTF8.GetString(byteIn, (int)ChipStart, 4) +
                            " $" + toU32(byteIn, ChipStart + 0x04).ToString("X8") +
                            " $" + toU16(byteIn, ChipStart + 0x08).ToString("X4") +  //comment
                            " $" + toU16(byteIn, ChipStart + 0x0A).ToString("X4") +  // 
                            " $" + toU16(byteIn, ChipStart + 0x0C).ToString("X4") +
                            " $" + toU16(byteIn, ChipStart + 0x0E).ToString("X4") 
                            , Color.Blue);
                        NumChips++;
                        ChipStart += toU32(byteIn, ChipStart + 0x04); //add packet length
                    }
                    WriteToOutput(NumChips + " Chip(s) found\r", Color.Blue);

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "File Read Error");
                }

            }

        }

        private void btnC64SIDfile_Click(object sender, EventArgs e)
        {
            //https://hvsc.c64.org/
            //https://gist.github.com/cbmeeks/2b107f0a8d36fc461ebb056e94b2f4d6

            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "SID files (*.sid)|*.sid|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            UInt16[] BlockCount = new UInt16[32]; //defaults to 0s
            UInt16 NumFiles = 0;

            WriteToOutput("\rC64 SID file parser", Color.DarkGreen);
            WriteToOutput("Path: " + Path.GetDirectoryName(openFileDialog1.FileName), Color.DarkGreen);

            foreach (String file in openFileDialog1.FileNames)
            {
                try
                {
                    //Read the file to a byte array:
                    BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open));
                    byte[] byteIn = new byte[br.BaseStream.Length];
                    byteIn = br.ReadBytes(byteIn.Length);
                    br.Close();

                    UInt16 Version = toU16(byteIn, 0x04);
                    UInt16 LoadAddress = toU16(byteIn, 0x08);
                    UInt16 DataOffset = toU16(byteIn, 0x06);
                    if (Version >= 2)
                    {
                        LoadAddress = (UInt16)((byteIn[DataOffset + 1] << 8) | byteIn[DataOffset]);
                        DataOffset += 2;
                    }
                    UInt16 EndAddress = (UInt16)(LoadAddress + byteIn.Length - DataOffset -1);
                    for(UInt16 BlockNum = (UInt16)(LoadAddress >> 11); BlockNum <= (EndAddress >> 11); BlockNum++) BlockCount[BlockNum]++;
                    NumFiles++;

                    if (cbSIDSummary.Checked)
                    {
                        WriteToOutput("\r*** " + Path.GetFileName(file), Color.DarkRed);
                        WriteToOutput("    magicID: " + Encoding.UTF8.GetString(byteIn, 0, 4)
                            + "\t\t    version: " + Version.ToString("X4"), Color.DarkBlue);
                        WriteToOutput("Mem Loc " + LoadAddress.ToString("X4") + ":" + EndAddress.ToString("X4")
                            + "   (" + (EndAddress - LoadAddress) + " bytes, " + (EndAddress - LoadAddress) / 1024 + "k)", Color.DarkRed);

                        if (cbSIDDetails.Checked)
                        {
                            WriteToOutput("  File Size: " + byteIn.Length + " (" + byteIn.Length / 1024 + "k)", Color.DarkBlue);
                            WriteToOutput("       Name: " + Encoding.UTF8.GetString(byteIn, 0x16, 0x20), Color.DarkBlue);
                            WriteToOutput("     Author: " + Encoding.UTF8.GetString(byteIn, 0x36, 0x20), Color.DarkBlue);
                            WriteToOutput("   Released: " + Encoding.UTF8.GetString(byteIn, 0x56, 0x20), Color.DarkBlue);
                            WriteToOutput(" dataOffset: " + DataOffset.ToString("X4")
                                + "\t\tv1loadAddress: " + toU16(byteIn, 0x08).ToString("X4"), Color.DarkBlue);
                            WriteToOutput("initAddress: " + toU16(byteIn, 0x0A).ToString("X4")
                                + "\t\tplayAddress: " + toU16(byteIn, 0x0C).ToString("X4"), Color.DarkBlue);
                            WriteToOutput("      songs: " + toU16(byteIn, 0x0E).ToString("X4")
                                + "\t\t  startSong: " + toU16(byteIn, 0x10).ToString("X4"), Color.DarkBlue);
                            WriteToOutput("      speed: " + toU32(byteIn, 0x12).ToString("X8"), Color.DarkBlue);

                            if (Version >= 2)
                            {
                                WriteToOutput("V2+   flags: " + toU16(byteIn, 0x76).ToString("X4")
                                    + "\t\t  startPage: " + byteIn[0x78].ToString("X2"), Color.Blue);
                                WriteToOutput(" 2ndSIDAddr: " + byteIn[0x7A].ToString("X2")
                                    + "\t\t 3rdSIDAddr: " + byteIn[0x7B].ToString("X2"), Color.Blue);
                                WriteToOutput(" pageLength: " + byteIn[0x79].ToString("X2")
                                    + "\t\tloadAddress: " + LoadAddress.ToString("X4"), Color.Blue);
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "File Read Error");
                }
            }

            WriteToOutput("\r" + NumFiles + " Files Examined in " + Path.GetDirectoryName(openFileDialog1.FileName) 
                + "\rUsage in 2K blocks:", Color.Purple);
            for (UInt16 BlockNum = 0; BlockNum < 32; BlockNum++)
            {
                string BarGraph = "";
                UInt16 PctFiles = (UInt16)(100 * BlockCount[BlockNum] / NumFiles);

                for (UInt16 NumBlocks = 0; NumBlocks < PctFiles; NumBlocks++) BarGraph += "-";
                WriteToOutput("  " + (BlockNum<<11).ToString("X4") + ": " + BlockCount[BlockNum].ToString("D4") 
                    + " " + PctFiles.ToString("D2") + "% " + BarGraph, Color.Purple);
            }

        }

        private void cbSIDSummary_CheckedChanged(object sender, EventArgs e)
        {
            cbSIDDetails.Enabled = cbSIDSummary.Checked;
        }
    }
}
