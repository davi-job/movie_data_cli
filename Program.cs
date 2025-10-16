
using MovieData;
using DotNetEnv;
using System.Net.Http.Json;

Env.Load();

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

    // Initialize http client and fetch response   
    using HttpClient httpClient = new()
    {
        BaseAddress = new Uri("https://api.themoviedb.org/3/movie/"),
    };
    httpClient.DefaultRequestHeaders.Add("accept", "application/json");
    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("TMDB_API_KEY")}");

    string requestUrl = string.Empty;
    string searchTitle = string.Empty;

    switch (type)
    {
        case "playing":
            requestUrl = "now_playing?language=en-US&page=1";
            searchTitle = "Now playing:";

            break;

        case "popular":
            requestUrl = "popular?language=en-US&page=1";
            searchTitle = "Most popular:";

            break;

        case "top":
            requestUrl = "top_rated?language=en-US&page=1";
            searchTitle = "Top Rated:";

            break;

        case "upcoming":
            requestUrl = $"upcoming?language=en-US&page=1";
            searchTitle = "Upcoming:";

            break;

        default:
            throw new ArgumentOutOfRangeException("Invalid type. Please select one of the following types: 'playing', 'popular', 'top', 'upcoming'.");
    }

    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

    if (!response.IsSuccessStatusCode)
    {
        throw new HttpRequestException($"Failed to fetch the requested movies. (Error: {response.StatusCode})");
    }

    var responseJson = await response.Content.ReadFromJsonAsync<MovieResponse>();

    Movie[]? movies = responseJson?.Movies;

    if (movies == null || movies.Length == 0)
        throw new NullReferenceException("No movies were found.");

    // Process output
    Console.WriteLine(searchTitle + "\n");

    foreach (Movie movie in movies)
    {
        Console.WriteLine(movie.Title);
        Console.WriteLine(movie.Description);
        Console.WriteLine($"{movie.ReleaseDate}\t{movie.PublicRating:f2}/10 ({movie.RatingCount} votes)\n");
    }

    return 0;
}
catch (Exception ex)
{
    Console.WriteLine($"Something went wrong: {ex.Message}");
    return -1;
}