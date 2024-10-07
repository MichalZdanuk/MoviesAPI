namespace MoviesAPI.Entities
{
    public class Movie
    {
        private Movie() { }

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }

        public Movie(Guid id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
