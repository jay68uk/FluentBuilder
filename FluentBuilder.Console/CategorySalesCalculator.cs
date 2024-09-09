namespace FluentBuilder.Console;

public class CategorySalesCalculator
{
  public string Category { get; internal set; }
  public IEnumerable<Book> Books { get; internal set; } = new List<Book>();
}