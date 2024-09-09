using Ardalis.GuardClauses;

namespace FluentBuilder.Console;

public sealed class Book
{
  public Book(string author, string title)
  {
    Guard.Against.NullOrEmpty(author, nameof(author));
    Guard.Against.NullOrEmpty(title, nameof(title));
    
    Title = title;
    Author = author;
  }
  
  public string Title { get; internal set; }
  
  public string Author { get; internal set; }
  public IEnumerable<SalesPeriod> SalesPeriod { get; internal set; } = new List<SalesPeriod>();
}