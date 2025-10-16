
using System.Net.Http.Json;
using System.Text.Json;
using MovieData;

try
{
    // Get user input
    string? type = null;
    ArgumentNullException typeNull = new("The argument '--type' is required.");

    if (args.Length == 0)
        throw typeNull;

    for (int i = 0; i < args.Length; i++)
    {
        if (args[i] == "--type" && i + 1 < args.Length)
        {
            type = args[i + 1];
            break;
        }
    }

    if (string.IsNullOrWhiteSpace(type))
        throw typeNull;

    // Initialize http client    
    HttpClient httpClient = new()
    {
        BaseAddress = new Uri("https://api.themoviedb.org/3/discover/movie?include_adult=false&include_video=false&language=en-US&page=1"),
    };

    HttpResponseMessage response;
    string title = string.Empty;

    switch (type)
    {
        case "playing":
            response = await httpClient.GetAsync("&sort_by=primary_release_date.desc&with_release_type=2|3&release_date.gte={min_date}&release_date.lte={max_date}");
            title = "Now playing:";

            break;

        case "popular":
            response = await httpClient.GetAsync("&sort_by=popularity.desc");
            title = "Most popular:";

            break;

        case "top":
            response = await httpClient.GetAsync("&sort_by=vote_average.desc&without_genres=99,10755&vote_count.gte=200");
            title = "Top Rated:";

            break;

        case "upcoming":
            response = await httpClient.GetAsync("&sort_by=primary_release_date.asc&with_release_type=2|3&release_date.gte={min_date}&release_date.lte={max_date}");
            title = "Upcoming:";

            break;

        default:
            throw new ArgumentOutOfRangeException("Invalid type. Please select one of the following types: 'playing', 'popular', 'top', 'upcoming'.");
    }

    if (!response.IsSuccessStatusCode || response.Content == null)
        throw new HttpRequestException("Failed to fetch the requested movies.");

    Movie[]? movies = (await response.Content.ReadFromJsonAsync<Response>())?.Movies;

    if (movies == null)
        throw new NullReferenceException("No movies were found.");

    return 0;
}
catch (Exception ex)
{
    Console.WriteLine($"Something went wrong: {ex.Message}");
    return -1;
}