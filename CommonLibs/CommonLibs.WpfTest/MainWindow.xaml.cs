using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using PropertyChanged;

namespace CommonLibs.WpfTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public partial class MainWindow : Window
    {
        private static string fileName = "Config.data";

        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SysData");

        private static string fileFullName = Path.Combine(filePath, fileName);

        public Grade Grade { get; set; } = new Grade();

        public Student Student { get; set; }= new Student();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            if (!File.Exists(fileFullName))
            {
                using (var fs = File.Create(fileFullName))
                {
                    
                }
            }

            LoadData();
        }

        private void SaveGrade_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Grade.Id))
            {
                Grade.Id = Guid.NewGuid().ToString("N");
            }

            if (FileIOHelper.WriteFileFromObject(Grade, fileFullName))
                ;
        }

        private void SaveStudent_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Grade.Id))
            {
                MessageBox.Show("先创建班级");
                return;
            }

            if (string.IsNullOrEmpty(Student.Id))
            {
                Student.Id = Guid.NewGuid().ToString("N");
                Student.Grade = Grade;
                Student.GradeId = Grade.Id;
            }

            //Grade.Ids.Add(Student.Id);
            Grade.Students.Add(Student);

            if (FileIOHelper.WriteFileFromObject(Grade, fileFullName))
            {
                Student = new Student();
            }
        }

        private void LoadData()
        {
            var data = FileIOHelper.ReadFileToObject<Grade>(fileFullName);

            if (data != null)
            {
                Grade = data;
            }
        }
    }

    /// <summary>
    /// 学生班级实体
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class Grade
    {
        public string Id { get; set; }
        public string Name { get; set; }

        //public List<string> Ids { get; set; }=new List<string>();

        [JsonIgnore]
        public ObservableCollection<Student> Students { get; private set; }=new ObservableCollection<Student>();

    }

    /// <summary>
    /// 学生信息实体
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string GradeId { get; set; }

        [JsonIgnore]
        public Grade Grade { get; set; }
    }
}
