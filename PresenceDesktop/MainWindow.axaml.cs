using Avalonia.Controls;
using domain.Service;
using System;
using System.Linq;

namespace PresenceDesktop
{
    public partial class MainWindow : Window
    {
        private readonly IGroupUseCase _groupService;
        private int studentCount = 0;
        private int groupSelectedIndex = 0;
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
            StudentsListBox.ItemsSource = _groupService.GetStudentsByGroupId(comboBox.SelectedIndex + 1);
            count.Text = $"Всего: {_groupService.GetStudentsByGroupId(comboBox.SelectedIndex + 1).Count()}";
        }

        private void MenuItem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            Guid id = Guid.Parse(menuItem.Tag.ToString());
            _groupService.RemoveStudentById(id);
        }

        private void SortComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            //var comboBox = sender as ComboBox;
            //switch(comboBox.SelectedIndex)
            //{
            //    case 0:
            //        GroupsComboBox.ItemsSource = GroupsComboBox.ItemsSource;
            //        break;
            //    case 1:
            //        GroupsComboBox.ItemsSource = GroupsComboBox.ItemsSource.Order
            //        break;
            //}
        }
    }
}