using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ArabizationExample
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            string ArabizedLine, LineToProcess;
            MessagesLbl.Text = "";
            char[] CProcessedLine;// Temp char array to store the characters of the arabized string.
            byte[] BProcessedLine;// Temp byte array used for conversion from chars to bytes.
            Arabization ArabicText = new Arabization();// Creating an object of the class Arabization that will allow the handling and conversion of Arabic texts into something that can be used by systems that does not have Arabic support.
            FileStream ArabicInputTextFile = new FileStream(InputFileName.Text, FileMode.Open, FileAccess.Read);// Arabic input text file.
            FileStream ArabicOutputTextFile = new FileStream(OutputFileName.Text, FileMode.Create, FileAccess.ReadWrite);// Output file.
            TextReader ArabicInputTextStream = new StreamReader(ArabicInputTextFile, Encoding.GetEncoding(1256));// 1256 encoding is the Arabic code page (https://en.wikipedia.org/wiki/Windows-1256) and you are using this statement to facilitate reading from the Arabic input file.

            try
            {
                while ((LineToProcess = ArabicInputTextStream.ReadLine()) != null)// Iterate over lines within the input file.
                {
                    ArabizedLine = ArabicText.Arabize(LineToProcess);// This method is used for the conversion. You only provide it with the line to process and it handles everything. No extra work on your behalf.
                    CProcessedLine = ArabizedLine.ToCharArray();

                    BProcessedLine = new byte[CProcessedLine.Length];

                    for (int i = 0; i < CProcessedLine.Length; i++)
                        BProcessedLine[i] = (byte)CProcessedLine[i];
                    ArabicOutputTextFile.Write(BProcessedLine, 0, BProcessedLine.Length);
                    ArabicOutputTextFile.WriteByte((byte)'\r');// New line after each line we write.
                    ArabicOutputTextFile.WriteByte((byte)'\n');//
                }
                MessagesLbl.Text = "File has been successfully converted.";
            }
            catch
            {
                MessagesLbl.Text = "Corrupted file. Please replace it.";
            }

            ArabicInputTextFile.Close();
            ArabicOutputTextFile.Close();
        }

        private void InputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = "";
            OpenFileDialog.Filter = "All Files (*.*)|*.*";
            OpenFileDialog.ShowDialog();
            if (OpenFileDialog.FileName != "")
                InputFileName.Text = OpenFileDialog.FileName;
        }

        private void OutputFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog.FileName = "";
            SaveFileDialog.Filter = "All Files (*.*)|*.*";
            SaveFileDialog.ShowDialog();
            if (SaveFileDialog.FileName != "")
                OutputFileName.Text = SaveFileDialog.FileName;
        }

    }


}