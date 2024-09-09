using FluentAssertions;
using FluentBuilder.Console;

namespace FluentBuilder.UnitTests;

public class BookBuilderTests
{
  private static Book _book = new Book("Peter F. Hamilton",  "Dreaming Void" );

  private static IEnumerable<SalesPeriod> _salePeriods = new List<SalesPeriod>()
  {
    new SalesPeriod("02", 200, 880m),
    new SalesPeriod("03", 200, 900m)
  };
  
  private const string SaleId = "01";
  private const int TotalQuantity = 100;
  private const decimal SaleValue = 440.00m;
  
  [Fact]
  public void Should_CreateBook_WhenInputIsValid()
  {
    var book = new BookBuilder(_book.Author, _book.Title)
      .Build();
    
    book.Author.Should().Be(_book.Author);
    book.Title.Should().Be(_book.Title);
  }
  
  [Fact]
  public void Should_AddSingleSalesPeriod_WhenInputIsValid()
  {
    var bookBuilder = new BookBuilder(_book.Author, _book.Title)
      .AddSalesPeriod(SaleId, TotalQuantity, SaleValue);
      
    var book = bookBuilder.Build();

    book.SalesPeriod.Should().HaveCount(1);
    book.SalesPeriod.Should().ContainSingle(period => 
      period.SaleId == SaleId &&
      period.TotalQuantity == TotalQuantity &&
      period.SaleValue == SaleValue);
  }
  
  [Fact]
  public void Should_AddSalesPeriods_WhenInputIsValid()
  {
    var bookBuilder = new BookBuilder(_book.Author, _book.Title)
      .AddSalesPeriods(_salePeriods);
      
    var book = bookBuilder.Build();

    book.SalesPeriod.Should().HaveCount(2);
    book.SalesPeriod.Should().Contain(_salePeriods);
  }
  
  [Fact]
  public void Should_AddSalesPeriods_ToExistingSalesPeriods_WhenInputIsValid()
  {
    var bookBuilder = new BookBuilder(_book.Author, _book.Title)
      .AddSalesPeriods(_salePeriods)
      .AddSalesPeriod(SaleId, TotalQuantity, SaleValue);
      
    var book = bookBuilder.Build();

    book.SalesPeriod.Should().HaveCount(3);
    book.SalesPeriod.Should().Contain(_salePeriods);
    book.SalesPeriod.Should().ContainSingle(period => 
      period.SaleId == SaleId &&
      period.TotalQuantity == TotalQuantity &&
      period.SaleValue == SaleValue);
  }
  
  [Fact]
  public void Should_AddSingleSalesPeriod_ToExistingSalesPeriods_WhenInputIsValid()
  {
    var bookBuilder = new BookBuilder(_book.Author, _book.Title)
      .AddSalesPeriod(SaleId, TotalQuantity, SaleValue)
      .AddSalesPeriods(_salePeriods);
      
    var book = bookBuilder.Build();

    book.SalesPeriod.Should().HaveCount(3);
    book.SalesPeriod.Should().Contain(_salePeriods);
    book.SalesPeriod.Should().ContainSingle(period => 
      period.SaleId == SaleId &&
      period.TotalQuantity == TotalQuantity &&
      period.SaleValue == SaleValue);
  }
  
  [Theory]
  [InlineData(null, "Reality Dysfunction", "author")]
  [InlineData("Peter F. Hamilton", null, "title")]
  public void Should_ThrowException_CreatingBook_WhenInputIsNull(string author, string title, string nullParamName)
  {
    var exceptionInvoked = () => new BookBuilder(author, title).Build();
    
    exceptionInvoked.Should().ThrowExactly<ArgumentNullException>().And.ParamName.Should().Be(nullParamName);
  }
  
  [Theory]
  [InlineData("", "Reality Dysfunction", "author")]
  [InlineData("Peter F. Hamilton", "", "title")]
  public void Should_ThrowException_ForAddParameterisedBook_WhenInputIsEmptyString(string author, string title, string emptyParamName)
  {
    var exceptionInvoked = () => new BookBuilder(author, title).Build();

    exceptionInvoked.Should().ThrowExactly<ArgumentException>().And.ParamName.Should().Be(emptyParamName);
  }
}