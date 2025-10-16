using System.Text.Json.Serialization;
namespace MovieData;

public class MovieResponse
{
    [JsonPropertyName("results")]
    public Movie[]? Movies { get; set; }
}

public class Movie
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("overview")]
    public required string Description { get; set; }

    [JsonPropertyName("release_date")]
    public required string ReleaseDate { get; set; }

    [JsonPropertyName("vote_average")]
    public required double PublicRating { get; set; }

    [JsonPropertyName("vote_count")]
    public required int RatingCount { get; set; }
}