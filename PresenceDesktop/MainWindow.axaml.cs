using Avalonia.Controls;
using domain.Service;

namespace PresenceDesktop
{
    public partial class MainWindow : Window
    {
        private readonly IGroupUseCase _groupService;
        public MainWindow(IGroupUseCase groupUseCase)
        {
            InitializeComponent();
            _groupService = groupUseCase;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}