namespace login
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Login", typeof(MainPage));
            Routing.RegisterRoute("Page", typeof(Page));
        }
    }
}
