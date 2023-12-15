using System.Collections.ObjectModel;
using Newtonsoft.Json;
namespace Maui_api
{
    public partial class resultpage : ContentPage
    {
        int count = 0;

        public ObservableCollection<string> Jokes { get; set; }

        public resultpage(string result)
        {
            InitializeComponent();

            List<Joke> jokes = JsonConvert.DeserializeObject<List<Joke>>(result);

            jokes = jokes.OrderBy(j => j.setup).ToList();

            var formattedString = new FormattedString();

            foreach (var (joke, index) in jokes.Select((j, i) => (j, i)))
            {
                formattedString.Spans.Add(new Span
                {
                    Text = $"{index + 1}. {joke.setup}\n   {joke.punchline}",
                    FontAttributes = FontAttributes.Bold,
                });

                if (index < jokes.Count - 1)
                {
                    formattedString.Spans.Add(new Span { Text = "\n\n" });
                }
                
            }
            ResultCat.FormattedText = $"Categorie: " + jokes.FirstOrDefault()?.type;
            ResultLabel.FormattedText = formattedString;
        }


        public class Joke
        {
            public string type { get; set; }
            public string setup { get; set; }
            public string punchline { get; set; }
            public int id { get; set; }
        }

    }
}