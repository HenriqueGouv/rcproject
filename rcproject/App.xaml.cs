using rcproject.ViewModel;

namespace rcproject
{
    public partial class App : Application
    {

        public static CreateCompetitions ViewModel { get; } = new CreateCompetitions();
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
            return window;
        }
    }
}