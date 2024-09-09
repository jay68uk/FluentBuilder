using Ardalis.GuardClauses;

namespace FluentBuilder.Console;

public class CategorySalesCalculatorBuilder()
{
  private CategorySalesCalculator _categorySalesCalculator = new();

  public CategorySalesCalculatorBuilder(string category) : this()
  {
    _categorySalesCalculator.Category = category;
  }
  
  public CategorySalesCalculator Calculate() => _categorySalesCalculator;

  public CategorySalesCalculatorBuilder WithBooks(IEnumerable<Book> books)
  {
    _categorySalesCalculator.Books = _categorySalesCalculator.Books.Concat(books);
    return this;
  }

  public CategorySalesCalculatorBuilder WithBook(Book book)
  {
    _categorySalesCalculator.Books = _categorySalesCalculator.Books.Append(book);
    return this;
  }

  public CategorySalesCalculatorBuilder WithBookParameters(string author, string title)
  {
    _categorySalesCalculator.Books = _categorySalesCalculator.Books.Append(new Book( author,  title));
    return this;
  }
}