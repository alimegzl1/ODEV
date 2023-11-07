using System;

class Book
{
    public string Title { get; set; }
    public List<string> Authors { get; set; }
    public decimal Price { get; set; }
    public int PageCount { get; set; }
    public string Category { get; set; }

    public Book(string title, List<string> authors, decimal price, int pageCount, string category)
    {
        Title = title;
        Authors = authors;
        Price = price;
        PageCount = pageCount;
        Category = category;
    }

    public void ApplyDiscount(decimal discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 100)
        {
            throw new ArgumentException("Discount percentage should be between 0 and 100.");
        }

        Price -= Price * (discountPercentage / 100);
    }
}

class Program
{
    static void ApplyDiscountToBooks(List<Book> books, decimal discountPercentage)
    {
        foreach (Book book in books)
        {
            book.ApplyDiscount(discountPercentage);
        }
    }

    static void Main()
    {
        Book book1 = new Book("Simyacı", new List<string> { "Paulo Coelho" }, 20.0m, 180, "Fantastic");
        Book book2 = new Book("Gece Yarısı Kütüphanesi", new List<string> { "Matt Haig" }, 30.0m, 290, "Fantastic");
        Book book3 = new Book("Olasılıksız", new List<string> { "Adam Fawer" }, 40.0m, 475, "science fiction");

        List<Book> books = new List<Book> { book1, book2, book3 };

        Console.WriteLine("Before applying discount:");
        foreach (Book book in books)
        {
            Console.WriteLine($"Title: {book.Title} - Authors: {string.Join(", ", book.Authors)} - Price: ${book.Price} - Page Count: {book.PageCount} - Category: {book.Category}");
        }

        decimal discountPercentage = 10.0m;
        ApplyDiscountToBooks(books, discountPercentage);

        Console.WriteLine("\nAfter applying a {0}% discount:", discountPercentage);
        foreach (Book book in books)
        {
            Console.WriteLine($"Title: {book.Title} - Authors: {string.Join(", ", book.Authors)} - Price: ${book.Price} - Page Count: {book.PageCount} - Category: {book.Category}");
        }
    }
}
