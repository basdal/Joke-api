using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui_api
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

       
        private async void OnGetJokesClicked(object sender, EventArgs e)
        {
            // Get the selected category from the CategoryPicker
            string selectedCategory = CategoryPicker.SelectedItem as string;

            // Check if a category is selected
            if (string.IsNullOrEmpty(selectedCategory))
            {
                await DisplayAlert("Error", "Please select a category.", "OK");
                return;
            }

            // Get the selected option from the NumberOfJokesEntry Picker
            string selectedOption = NumberOfJokesEntry.SelectedItem as string;

            // Build the API URL based on the selected category and option
            string apiUrl;

            if (selectedOption == "Een")
            {
                apiUrl = $"https://official-joke-api.appspot.com/jokes/{selectedCategory.ToLower()}/random";
            }
            else if (selectedOption == "Tien")
            {
                apiUrl = $"https://official-joke-api.appspot.com/jokes/{selectedCategory.ToLower()}/ten";
            }
            else
            {
                // Handle an unknown option
                await DisplayAlert("Error", "Unknown option selected.", "OK");
                return;
            }

            // TODO: Perform API call with the constructed apiUrl
            // Replace the following line with your actual API call logic
            string result = await ApiService.MakeApiCall(apiUrl);

            if (selectedCategory.ToLower() == "knock-knock" && selectedOption == "Tien")
            {
                // Handle the case where there are only 5 knock-knock jokes
                await DisplayAlert("Info", "There are only 5 knock-knock jokes available.", "OK");
            }
            // Navigate to the ResultPage and pass the result as a parameter
            await Navigation.PushAsync(new resultpage(result));
        }
        public class ApiService
        {
            public static async Task<string> MakeApiCall(string apiUrl)
            {
                // Implement your actual API call logic here
                // You might want to use HttpClient or another library to make the request
                // Replace the following line with your actual API call logic

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        // Handle the case when the API call is not successful
                        return null;
                    }
                }
            }
        }

        
        public class Joke
        {
            public string Type { get; set; }
            public string Setup { get; set; }
            public string Punchline { get; set; }
        }
    }
}
