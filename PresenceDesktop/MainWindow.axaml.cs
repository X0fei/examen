using Avalonia.Controls;
using domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using domain.Entity;
using data.DAO;

namespace PresenceDesktop
{
    public partial class MainWindow : Window
    {
        private readonly IGroupUseCase _groupService;
        private int studentCount = 0;
        private int groupSelectedIndex = 0;
        private IEnumerable<Student> students;
        public MainWindow(IGroupUseCase groupUseCase)
        {
            InitializeComponent();
            _groupService = groupUseCase;
            GroupsComboBox.ItemsSource = _groupService.GetGroups();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GroupsComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            students = _groupService.GetStudentsByGroupId(comboBox.SelectedIndex + 1);
            StudentsListBox.ItemsSource = students;
            count.Text = $"Всего: {students.Count()}";
        }

        private void MenuItem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            //var menuItem = sender as MenuItem;
            //Guid id = Guid.Parse(menuItem.Tag.ToString());
            //_groupService.RemoveStudentById(id);
        }

        private void SortComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            //var comboBox = sender as ComboBox;
            //switch (comboBox.SelectedIndex)
            //{
            //    case 0:
            //        StudentsListBox.ItemsSource = students;
            //        break;
            //    case 1:
            //        StudentsListBox.ItemsSource = students.OrderBy(Student.Name);
            //        break;
            //    case 2:
            //        break;
            //}
        }
    }
}