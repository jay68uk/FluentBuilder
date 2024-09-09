using Ardalis.GuardClauses;

namespace FluentBuilder.Console;

public sealed class BookBuilder
{
  private Book _book;
  public BookBuilder(string author, string title)
  {
    _book = new Book(author, title);
  }

  public Book Build() => _book;

  public BookBuilder AddSalesPeriod(string saleId, int totalQuantity, decimal saleValue)
  {
    _book.SalesPeriod = _book.SalesPeriod.Append(new SalesPeriod(saleId, totalQuantity, saleValue));
    return this;
  }

  public BookBuilder AddSalesPeriods(IEnumerable<SalesPeriod> salePeriods)
  {
    _book.SalesPeriod = _book.SalesPeriod.Concat(salePeriods);
    return this;
  }
}