using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string tmp = "";
        string selectedState = "*.txt";
        //string[] files;
        public Form1()
        {
            
            InitializeComponent();
            //tableLayoutPanel1.ColumnCount = 5;
            //tableLayoutPanel1.RowCount = 5;
            textBox1.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            LoadFiles(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "*.txt");
           
        }
        void LoadFiles(string dir, string ext)
        {
            //tableLayoutPanel1.RowCount = Int32.Parse(rows.Text);
            //tableLayoutPanel1.ColumnCount = Int32.Parse(columns.Text);

            //foreach (RowStyle i in tableLayoutPanel1.RowStyles)
            //{
            //    i.SizeType = SizeType.Percent;
            //    i.Height =  Int32.Parse(size.Text);
            //}
            //    foreach (ColumnStyle i in tableLayoutPanel1.ColumnStyles)
            //    {
            //        i.SizeType = SizeType.Percent;
            //        i.Width  = Int32.Parse(size.Text);
            //    }



            //tableLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Clear();
            string[] files = Directory.GetFiles(dir, ext);
            //int x = 0;
            //int y = 0;
            foreach (string file in files)
            {
                //if (x > tableLayoutPanel1.ColumnCount)
                //{
                //    x = 0;
                //    y++;
                //}
                //tmp = file;
                Button saveButton = new Button();
                saveButton.Height = Int32.Parse(rows.Text);
                saveButton.Width = Int32.Parse(columns.Text);
                //if (file.Split(new char[] { '.' })[1]=="txt")
                //{

                if (ext == "*.png" || ext == "*.jpg")
                    saveButton.Image = Image.FromFile(file);
                    

                else
                {
                    string readText = File.ReadAllText(file);
                    saveButton.Text = readText;
                    saveButton.Image = TileManager.Properties.Resources.leaf_3;
                }
                // добавляем кнопку в следующую свободную ячейку
                saveButton.Click += (s, e) =>
                {
                    System.Diagnostics.Process.Start(file);
                };
                
                saveButton.Enter += (s, e) =>
                {
                    this.Text = $"Tile Manager - {Path.GetFileName(file)}";
                    file_path.Text = file;
                };
                //saveButton.MouseEnter += (s, e) =>
                //{
                //    this.Text = $"Form1 - {Path.GetFileName(file)}";
                //    file_path.Text = file;
                //};
                //C:\Users\Пользователь\Desktop
                //tableLayoutPanel1.Controls.Add(saveButton, x, y);
                flowLayoutPanel1.Controls.Add(saveButton);
                //x++;
                //tableLayoutPanel1.SetRowSpan(saveButton, 1);

                // Open the file to read from.
                // }

            }
        }
        public bool HasBinaryContent(string content)
        {
            return content.Any(ch => char.IsControl(ch) && ch != '\r' && ch != '\n');
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            //files = Directory.GetFiles(textBox1.Text, "*.txt");
            LoadFiles(textBox1.Text,selectedState);
        }

    

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.IO.File.Move(file_path.Text, new_filepath.Text);
            LoadFiles(textBox1.Text,selectedState);
        }

   
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(file_path.Text);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(file_path.Text);
            LoadFiles(textBox1.Text,selectedState);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
               
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState = comboBox1.SelectedItem.ToString();
            //MessageBox.Show(selectedState);
        }

        private void получитьИнформциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo(file_path.Text);
            MessageBox.Show($"Имя: {info.Name}\nРазмер: {info.Length} байт\n Время создания: {info.CreationTime}");
        }

    
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
