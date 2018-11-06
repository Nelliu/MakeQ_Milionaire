using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace makeQuestions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Data> Dae = new List<Data>();
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int numb;
            bool parsing = int.TryParse(diff.Text,out numb);

            Data newQ = new Data();

            newQ.Question = Question.Text;
            newQ.Diff = numb;
            newQ.RightAnswer = RAnswer1.Text;
            newQ.Answer2 = Answer2.Text;
            newQ.Answer3 = Answer3.Text;
            newQ.Answer4 = Answer4.Text;

            Dae.Add(newQ);

            bool exist = File.Exists("questions.json");

            if (exist != true)
            {
                using (StreamWriter file = File.CreateText("questions.json")) 
                {
                    JsonSerializer serializer = new JsonSerializer();
                    
                    serializer.Serialize(file, Dae);
                }
            
                
            }
            else
            {
                var jsonData = File.ReadAllText("questions.json");
                
                List<Data> data1 = JsonSerialization.ReadFromJsonFile<List<Data>>("questions.json");
                data1.Add(newQ);

                jsonData = JsonConvert.SerializeObject(data1);
                
                File.WriteAllText("questions.json", jsonData);
                Save.Content = data1[1].RightAnswer;
            }

            Question.Text = "";
            RAnswer1.Text = "";
            Answer2.Text = "";
            Answer3.Text = "";
            Answer4.Text = "";

            

        }


        
       
    }
}
