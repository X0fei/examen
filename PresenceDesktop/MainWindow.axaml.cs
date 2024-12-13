using Avalonia.Controls;
using domain.Service;

namespace PresenceDesktop
{
    public partial class MainWindow : Window
    {
        private readonly IGroupUseCase _groupService;
        public MainWindow(IGroupUseCase groupUseCase)
        {
            _groupService = groupUseCase;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}