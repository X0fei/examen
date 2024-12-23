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
        private int groupID = 0;
        private IEnumerable<Student> students;
        private List<Guid> selectedItemsGuids = new List<Guid>();
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
        private void Call()
        {
            students = _groupService.GetStudentsByGroupId(groupID);
            StudentsListBox.ItemsSource = students;
            count.Text = $"Всего: {students.Count()}";
            SortComboBox.IsVisible = true;
            SortComboBox.SelectedIndex = 0;
            DeleteByGroupButton.IsVisible = true;
        }

        private void GroupsComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            groupID = comboBox.SelectedIndex + 1;
            Call();
        }

        private void MenuItem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            foreach (Guid guid in selectedItemsGuids)
            {
                _groupService.RemoveStudentById(guid);
            }
            Call();
        }

        private void SortComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    StudentsListBox.ItemsSource = students;
                    break;
                case 1:
                    StudentsListBox.ItemsSource = students.OrderBy(s => s.Name);
                    break;
                case 2:
                    StudentsListBox.ItemsSource = students.OrderByDescending(s => s.Name);
                    break;
            }
        }

        private void DeleteByGroupButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _groupService.RemoveStudentsByGroupId(groupID);
            Call();
        }

        private void StudentsListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            foreach (var item in listBox.SelectedItems)
            {
                var student = item as Student;
                selectedItemsGuids.Add(student.Guid);
            }
        }
    }
}