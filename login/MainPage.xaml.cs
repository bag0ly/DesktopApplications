namespace login
{
    public partial class MainPage : ContentPage
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool isLoggedin { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            username = Username.Text;
            password = Password.Text;
            isLoggedin = true;
            
            if (username == null || password == null) 
            {
                isLoggedin=false;
                DisplayAlert("Error", "An error occurred: Login failed", "OK");
            }
            else
            {
                DisplayAlert("Success", "Login successful", "OK");
            }
            await Navigation.PushAsync(new Page(username,password,isLoggedin));

        }
    }

}
