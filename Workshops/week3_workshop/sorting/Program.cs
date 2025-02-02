// CSE 381 Workshop 3

using System.Text.Json;

// Structure to represent the JSON data we will read
public class Book
{
    public required string title { get; set; }
    public required string author { get; set; }
    public required string language { get; set; }
    public required int year { get; set; }

    public override string ToString()
    {
		// Format the string with left alignment
        return $"{title,-50}{author,-28}{language,-18}{year,-5}";
    }

}

class Program
{
	// Read all the books from the API source
	// Needs to be async due to the network call.  We might get
	// a null list of books if there is a failure.
    static async Task<List<Book>?> Get_Books()
    {
        string url = "https://raw.githubusercontent.com/benoitvallon/100-best-books/master/books.json"; 
        using HttpClient client = new HttpClient();
        try
        {
			// Send request to the server
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
				// Read the response and deserialize the JSON string into a 
				// list of book objects.
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<List<Book>>(data);
            }
            Console.WriteLine($"Error reading from API: {response.StatusCode}");
            return null;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error connecting to the API: {e.Message}");
            return null;
        }
    }

	// Driver Code
    public static async Task Main(string[] args)
    {
		// Get the books from the API.  Wait for the response
        var books = await Get_Books();
        if (books == null)
        {
            return;
        }
		
		// Do your sorting here
        
		
		// Display the books
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}