# MovieData CLI Tool

A command-line interface tool to fetch and display movie information from The Movie Database (TMDB).

## How It Works

This tool interacts with the TMDB API to retrieve movie lists based on different categories. It displays movie details including title, description, release date, and ratings in a user-friendly format.

### Key Features

-   Fetches movie data from TMDB API.
-   Supports multiple movie categories: now playing, popular, top rated, and upcoming.
-   Displays movie title, description, release date, and rating information.
-   Handles errors gracefully, providing feedback to the user.
-   Uses environment variables for secure API key management.

## Tech Used

-   **C#**: The primary programming language used for development.
-   **.NET 9.0**: The framework used to build and run the application.
-   **TMDB API**: The API used to fetch movie information.
-   **DotNetEnv**: For loading environment variables from `.env` file.
-   **System.Net.Http.Json**: For JSON serialization and deserialization.

## Prerequisites

-   A TMDB API key (you can get one by registering at [The Movie Database](https://www.themoviedb.org/))

## Setup

1. **Clone the Repository**:

    ```bash
    git clone https://github.com/yourusername/MovieData.git
    cd MovieData
    ```

2. **Configure API Key**:

    Copy the `.env.example` file to `.env`:

    ```bash
    cp .env.example .env
    ```

    Edit the `.env` file and add your TMDB API key:

    ```
    TMDB_API_KEY=your_api_key_here
    ```

3. **Build the Project**:
   Use the following command to build the project:

    ```bash
    dotnet build
    ```

## How to Run

1. **Run the Application**:

    - To fetch now playing movies:
        ```bash
        dotnet run --type playing
        ```
    - To fetch popular movies:
        ```bash
        dotnet run --type popular
        ```
    - To fetch top rated movies:
        ```bash
        dotnet run --type top
        ```
    - To fetch upcoming movies:
        ```bash
        dotnet run --type upcoming
        ```

2. **View Results**:
   The application will display the movie list with details including title, description, release date, rating, and vote count.

## Available Types

-   `playing`: Movies currently in theaters
-   `popular`: Most popular movies
-   `top`: Top rated movies of all time
-   `upcoming`: Movies coming soon to theaters

## Project URL

[Backend Roadmanp Projects](https://roadmap.sh/projects/tmdb-cli)
