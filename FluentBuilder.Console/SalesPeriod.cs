using Ardalis.GuardClauses;

namespace FluentBuilder.Console;

public sealed class SalesPeriod
{
  private const int minLength = 2;
  private const int maxLength = 2;
  
  public string SaleId { get; }
  public int TotalQuantity { get; }
  public decimal SaleValue { get; }

  public SalesPeriod(string saleId, int totalQuantity, decimal saleValue)
  {
    Guard.Against.NullOrEmpty(saleId, nameof(saleId));
    Guard.Against.LengthOutOfRange(saleId,
      minLength,
      maxLength,
      nameof(saleId),
      exceptionCreator: () => new
        ArgumentOutOfRangeException(
          nameof(saleId),
          saleId.Length,
          $"{nameof(saleId)} length must be between {minLength} and {maxLength} inclusive"));
    Guard.Against.NegativeOrZero(totalQuantity, nameof(totalQuantity));
    Guard.Against.NegativeOrZero(saleValue, nameof(saleValue));
    
    SaleId = saleId;
    TotalQuantity = totalQuantity;
    SaleValue = saleValue;
  }
}