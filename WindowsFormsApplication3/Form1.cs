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
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Newtonsoft.Json;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        


        public Form1()
        {
            InitializeComponent();

        }


        private async void test(string filename)
        {
           
            var visionClient = new VisionServiceClient("b7428b0a2f14418697266156742ee67b");
            AnalysisResult analysisResult;var features = new VisualFeature[] { VisualFeature.Tags, VisualFeature.Description };
            var fs = new FileStream(@filename, FileMode.Open);
            analysisResult = await visionClient.AnalyzeImageAsync(fs, features);
            fs.Dispose();
            pictureBox1.ImageLocation = filename;
           string json = JsonConvert.SerializeObject(analysisResult);
            textBox1.Text = json;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    test(file);
                  
                }
                catch (IOException)
                {
                }
            }
           
        }
    }
}
