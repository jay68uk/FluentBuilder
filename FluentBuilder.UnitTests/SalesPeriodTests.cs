using FluentAssertions;
using FluentBuilder.Console;

namespace FluentBuilder.UnitTests;

public class SalesPeriodTests
{
  private const decimal SaleValue = 500m;
  private const int TotalQuantity = 100;
  private const string SalesId = "01";
  
  [Fact]
  public void Should_CreateSalesPeriod_WhenInputIsValid()
  {
    var salesPeriod = new SalesPeriod(SalesId, TotalQuantity, SaleValue);
    
    salesPeriod.SaleId.Should().Be(salesPeriod.SaleId);
    salesPeriod.TotalQuantity.Should().Be(TotalQuantity);
    salesPeriod.SaleValue.Should().Be(SaleValue);
  }

  [Theory]
  [InlineData("", "saleId")]
  [InlineData("001", "maxLength")]
  [InlineData("1", "minLength")]
  public void Should_ThrowArgumentException_WhenSalesIdIsEmpty_Or_InvalidLength(string salesId, string salesPeriodId)
  {
    var exceptionInvoked = () => new SalesPeriod(salesId, TotalQuantity, SaleValue);
    
    exceptionInvoked.Should().ThrowExactly<ArgumentException>().And.ParamName.Should().Be(salesPeriodId);
  }
  
  [Theory]
  [InlineData(null, "saleId")]
  public void Should_ThrowArgumentNullException_WhenSalesIdIsNull(string salesId, string salesPeriodId)
  {
    var exceptionInvoked = () => new SalesPeriod(salesId, TotalQuantity, SaleValue);
    
    exceptionInvoked.Should().ThrowExactly<ArgumentNullException>().And.ParamName.Should().Be(salesPeriodId);
  }
  
  [Theory]
  [InlineData(-1, "totalQuantity")]
  [InlineData(0, "totalQuantity")]
  public void Should_ThrowArgumentException_WhenTotalQuantityIsNegative_Or_Zero(int totalQuantity, string totalQuantityParam)
  {
    var exceptionInvoked = () => new SalesPeriod(SalesId, totalQuantity, SaleValue);
    
    exceptionInvoked.Should().ThrowExactly<ArgumentException>().And.ParamName.Should().Be(totalQuantityParam);
  }
  
  [Theory]
  [InlineData(-1, "saleValue")]
  [InlineData(0, "saleValue")]
  public void Should_ThrowArgumentException_WhenSaleValueIsNegative_Or_Zero(int saleValue, string saleValueParam)
  {
    var exceptionInvoked = () => new SalesPeriod(SalesId, TotalQuantity, saleValue);
    
    exceptionInvoked.Should().ThrowExactly<ArgumentException>().And.ParamName.Should().Be(saleValueParam);
  }

}