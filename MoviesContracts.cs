using System.Text.Json.Serialization;
namespace MovieData;

public class Response
{
    [JsonPropertyName("results")]
    public Movie[]? Movies;
}

public class Movie
{
    [JsonPropertyName("title")]
    public required string Title;

    [JsonPropertyName("overview")]
    public required string Description;

    [JsonPropertyName("release_date")]
    public required string ReleaseDate;

    [JsonPropertyName("vote_average")]
    public required string PublicRating;

    [JsonPropertyName("vote_count")]
    public required string RatingCount;
}