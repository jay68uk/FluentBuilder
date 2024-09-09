using FluentAssertions;
using FluentBuilder.Console;

namespace FluentBuilder.UnitTests;

public class CategorySalesBuilderTests
{
  private static List<Book> _books=  new List<Book>()
  {
    new Book("J.R.R. Tolkien", "The Hobbit" ),
    new Book("Craig Alanson", "Columbus Day")
  };

  private static Book _book = new Book( "Peter F. Hamilton", "Dreaming Void" );
  private const string Category = "ScienceFiction";

  [Fact]
  public void Should_CreateCategorySalesCalculator_WhenInputIsValid()
  {
    var builder = new CategorySalesCalculatorBuilder(Category)
      .WithBooks(_books);

    var salesCalculator = builder.Calculate();
    
    salesCalculator.Category.Should().Be(Category);
    salesCalculator.Books.Should().HaveCount(2);
  }
  
  [Fact]
  public void Should_AddBook_ToExistingBooksList_WhenInputIsValid()
  {
    var builder = new CategorySalesCalculatorBuilder(Category)
      .WithBooks(_books)
      .WithBook(_book);

    var salesCalculator = builder.Calculate();
    
    salesCalculator.Category.Should().Be(Category);
    salesCalculator.Books.Should().HaveCount(3);
  }
  
  [Fact]
  public void Should_AddListOfBooks_ToExistingBooksList_WhenInputIsValid()
  {
    var builder = new CategorySalesCalculatorBuilder(Category)
      .WithBook(_book)
      .WithBook(_book)
      .WithBooks(_books);

    var salesCalculator = builder.Calculate();
    
    salesCalculator.Category.Should().Be(Category);
    salesCalculator.Books.Should().HaveCount(4);
  }
  
  [Fact]
  public void Should_AddBook_ToBooksList_WhenInputIsValid()
  {
    var builder = new CategorySalesCalculatorBuilder(Category)
      .WithBook(_book);

    var salesCalculator = builder.Calculate();
    
    salesCalculator.Category.Should().Be(Category);
    salesCalculator.Books.Should().HaveCount(1);
  }
  
  [Fact]
  public void Should_AddParameterisedBook_ToBooksList_WhenInputIsValid()
  {
    const string author = "Peter F. Hamilton";
    const string title = "Reality Dysfunction";
    var builder = new CategorySalesCalculatorBuilder(Category)
      .WithBooks(_books)
      .WithBookParameters(author, title);

    var salesCalculator = builder.Calculate();
    
    salesCalculator.Category.Should().Be(Category);
    salesCalculator.Books.Should().HaveCount(3);
  }

  [Theory]
  [InlineData(null, "Reality Dysfunction", "author")]
  [InlineData("Peter F. Hamilton", null, "title")]
  public void Should_ThrowException_ForAddParameterisedBook_WhenInputIsNull(string author, string title, string nullParamName)
  {
    var exceptionInvoked = () => new CategorySalesCalculatorBuilder(Category)
      .WithBooks(_books)
      .WithBookParameters(author, title);
    
    exceptionInvoked.Should().ThrowExactly<ArgumentNullException>().And.ParamName.Should().Be(nullParamName);
  }
  
  [Theory]
  [InlineData("", "Reality Dysfunction", "author")]
  [InlineData("Peter F. Hamilton", "", "title")]
  public void Should_ThrowException_ForAddParameterisedBook_WhenInputIsEmptyString(string author, string title, string emptyParamName)
  {
    var exceptionInvoked = () => new CategorySalesCalculatorBuilder(Category)
      .WithBooks(_books)
      .WithBookParameters(author, title);

    exceptionInvoked.Should().ThrowExactly<ArgumentException>().And.ParamName.Should().Be(emptyParamName);
  }
}