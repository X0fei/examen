using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using domain.Service;

namespace PresenceDesktop;

public partial class PresenceWindow : Window
{
    private readonly IPresenceUseCase _presenceService;
    public PresenceWindow()
    {
        InitializeComponent();
    }
    public PresenceWindow(IPresenceUseCase presenceUseCase)
    {
        InitializeComponent();
        _presenceService = presenceUseCase;
        PresenceDataGrid.ItemsSource = _presenceService.GetPresences();
    }

    private void ToGroupsButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}