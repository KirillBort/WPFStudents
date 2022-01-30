using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WPFStudents.BaseModels;
namespace WPFStudents.ViewModels
{
    class StudentsGrid : INotifyPropertyChangedBase
    {
        private Student _currentStudent;
        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                _currentStudent = value;
                NotifyPropertyChanged(nameof(CurrentStudent));
            }
        }
        public ObservableCollection<Student> Students { get; set; }
        public StudentsGrid()
        {
            Students = new ObservableCollection<Student>();
        }
        readonly String[] StudentsFirstName = { "AAA", "BBB", "CCC" };
        readonly String[] StudentsLastName = { "DDD", "EEE", "FFF" };
        readonly String[] StudentsMiddleName = { "GGG", "HHH", "III" };
        int CuttentId = 0;
        public void GenerateStudent()
        {
            var random = new Random();
            Students.Add(new Student() { Id = ++CuttentId, FirstName = StudentsFirstName[random.Next(0, 3)], LastName = StudentsLastName[random.Next(0, 3)], MiddleName = StudentsMiddleName[random.Next(0, 3)], Payment = random.Next(2000, 3000) });
            NotifyPropertyChanged(nameof(Students));
        }
        public ICommand AddStudentCommand => new RelayCommand(
        x =>
        {
            GenerateStudent();
        },
        x => true);
        public ICommand DeleteStudentCommand => new RelayCommand(
        x =>
        {
            var item = x as Student;
            Students.Remove(item);
        },
        x => true);
    }
}