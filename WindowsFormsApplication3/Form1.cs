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
           
            var visionClient = new VisionServiceClient("<--Enter Code here from https://www.microsoft.com/cognitive-services/en-us/ -->");
            AnalysisResult analysisResult;var features = new VisualFeature[] { VisualFeature.Tags, VisualFeature.Description };
            var fs = new FileStream(@filename, FileMode.Open);
            analysisResult = await visionClient.AnalyzeImageAsync(fs, features); //THis is the main api call
            fs.Dispose();
            pictureBox1.ImageLocation = filename;
           string json = JsonConvert.SerializeObject(analysisResult);//The API Returns data here
            textBox1.Text = json; //Data is directly dumped into a textbox. You can do as your app requires.
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //THis is only for fileupload. 
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
