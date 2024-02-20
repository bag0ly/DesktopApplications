using System.Collections.ObjectModel;

namespace login;

public partial class Page : ContentPage
{
    private string _username;
    private string _password;
    private bool _isLoggedin;
    private ObservableCollection<string> dataList;
    public Page(string username, string password, bool isLoggedin)
	{
		InitializeComponent();

        dataList = new ObservableCollection<string>();
        Datalist.ItemsSource = dataList;

        _username = username;
        _password = password;
        _isLoggedin = isLoggedin;
        WelcomeMessage.Text = isLoggedin? $"Üdvözöljük {username}": $"Üdvözöljük Vendég";
        Save.IsEnabled = isLoggedin ? true : false;
        Load.IsEnabled = isLoggedin ? true : false;
    }

    private void OnListAddClicked(object sender, EventArgs e)
    {
        if (textbox.Text!="")
        {
            dataList.Add(textbox.Text);
        }
    }

    private void OnInsertClicked(object sender, EventArgs e)
    {
        if (Datalist.SelectedItem != null)
        {
            int selectedIndex = dataList.IndexOf(Datalist.SelectedItem.ToString());

            if (selectedIndex >= 0 && selectedIndex < dataList.Count)
            {
                dataList.Insert(selectedIndex, textbox.Text);

                Datalist.ItemsSource = null;
                Datalist.ItemsSource = dataList;
            }
        }
    }


    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (dataList.Count>0)
        {
            dataList.Clear();
        }
    }

    private void OnDeleteByIdClicked(object sender, EventArgs e)
    {
        try
        {
            if (Datalist.SelectedItem != null)
            {
                string selectedItem = Datalist.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(selectedItem))
                {
                    int selectedIndex = dataList.IndexOf(selectedItem);

                    if (selectedIndex >= 0 && selectedIndex < dataList.Count)
                    {
                        dataList.RemoveAt(selectedIndex);

                        DisplayAlert("Success", "Item deleted successfully", "OK");
                    }
                    else
                    {
                        DisplayAlert("Error", "Invalid selected index", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Selected item is null or empty", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "No item selected", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }


    private void OnSaveClicked(object sender, EventArgs e)
    {
        try
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "things.txt");

            string[] dataArray = dataList.ToArray();

            File.WriteAllLines(path, dataArray);

            DisplayAlert("Success", "Data saved successfully", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    private void OnLoadClicked(object sender, EventArgs e)
    {
        try
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "things.txt");

            if (File.Exists(path))
            {
                string[] loadedData = File.ReadAllLines(path);

                dataList.Clear();

                foreach (string line in loadedData)
                {
                    dataList.Add(line);
                }

                DisplayAlert("Success", "Data loaded successfully", "OK");
            }
            else
            {
                DisplayAlert("File Not Found", "The data file does not exist.", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

}