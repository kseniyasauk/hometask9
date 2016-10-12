using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Assembly assembly;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();


            string targetDirectory = fbd.SelectedPath;

            if (!string.IsNullOrWhiteSpace(targetDirectory))
            {

                GetDllFiles(targetDirectory);

                System.Windows.Forms.MessageBox.Show($@"Path: {targetDirectory}");

            }
        }

        public void GetDllFiles(string targetDirectory)
        {

            var files = Directory.GetFiles(targetDirectory);
            foreach (var file in files)
            {
                Regex regex = new Regex(@"\.dll$");
                Match match = regex.Match(file.ToLower());
                if (!string.IsNullOrEmpty(match.ToString()))
                {
                    listBox.Items.Add(file);
                }

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (listBox.SelectedIndex > -1)
                {
                    Assembly assembly = Assembly.ReflectionOnlyLoadFrom(listBox.SelectedItem.ToString());
                    var types = assembly.GetTypes();
                    listBox.Items.Clear();

                    foreach (var type in types)
                    {
                        listBox.Items.Add(type.ToString());
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(@"Choose .dll - file!");
                }

            }
            catch (BadImageFormatException ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            catch (ReflectionTypeLoadException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                Assembly assembly = Assembly.ReflectionOnlyLoadFrom(listBox.SelectedItem.ToString());
                string temp = listBox.SelectedItem.ToString();
                var types = assembly.GetTypes();
                listBox.Items.Clear();

                foreach (var type in types)
                {

                    if (type.ToString().Equals(temp))
                    {
                        var b = type.GetProperties();
                        foreach (var t in b)
                        {
                            listBox.Items.Add(t.ToString());
                        }
                    }
                }
                    
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(@"Choose types!");
            }
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                Assembly assembly = Assembly.ReflectionOnlyLoadFrom(listBox.SelectedItem.ToString());
                string temp = listBox.SelectedItem.ToString();
                var types = assembly.GetTypes();
                listBox.Items.Clear();

                foreach (var type in types)
                {

                    if (type.ToString().Equals(temp))
                    {
                        var b = type.GetMethods();
                        foreach (var t in b)
                        {
                            listBox.Items.Add(t.ToString());
                        }
                    }
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show(@"Choose types!");
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                Assembly assembly = Assembly.ReflectionOnlyLoadFrom(listBox.SelectedItem.ToString());
                string temp = listBox.SelectedItem.ToString();
                var types = assembly.GetTypes();
                listBox.Items.Clear();

                foreach (var type in types)
                {

                    if (type.ToString().Equals(temp))
                    {
                        var b = type.GetFields();
                        foreach (var t in b)
                        {
                            listBox.Items.Add(t.ToString());
                        }
                    }
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show(@"Choose types!");
            }
        }
    }
}
