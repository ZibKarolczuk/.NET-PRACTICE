namespace GradeBook
{
    public class BookSummary
    {
        IBook Book { get; set; }
        public BookSummary(IBook book)
        {
            Book = book;
        }

        public void GetBookSummary()
        {
            var statistics = Book.GetStatistics();
            System.Console.WriteLine($"The book \"{Book.Name}\" has average grade {statistics.Average:N1}");
            System.Console.WriteLine($"ISBN is {InMemoryBook.ISBN}");
            System.Console.WriteLine($"The highest grade is {statistics.High}");
            System.Console.WriteLine($"The lowest value is {statistics.Low}");
            System.Console.WriteLine($"The letter grade is {statistics.Letter}");
        }
    }
}