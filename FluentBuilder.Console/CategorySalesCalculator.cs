namespace FluentBuilder.Console;

public sealed class CategorySalesCalculator
{
  public string Category { get; internal set; }
  public IEnumerable<Book> Books { get; internal set; } = new List<Book>();

  public Dictionary<string, decimal> Sales()
  {
    return Books
      .GroupBy(book => book.Author)
      .Select(authorGroup => new
      {
        Author = authorGroup.Key,
        TotalSalesValue = authorGroup
          .SelectMany(book => book.SalesPeriod)
          .Sum(salesPeriod => salesPeriod.SaleValue)
      }).ToDictionary(authorGroup => authorGroup.Author, authorGroup => authorGroup.TotalSalesValue);
  }
}