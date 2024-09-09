using Ardalis.GuardClauses;

namespace FluentBuilder.Console;

public sealed class SalesPeriod
{
  public string SaleId { get; }
  public int TotalQuantity { get; }
  public decimal SaleValue { get; }

  public SalesPeriod(string saleId, int totalQuantity, decimal saleValue)
  {
    Guard.Against.NullOrEmpty(saleId, nameof(saleId));
    Guard.Against.LengthOutOfRange(saleId, 2, 2, nameof(saleId));
    Guard.Against.NegativeOrZero(totalQuantity, nameof(totalQuantity));
    Guard.Against.NegativeOrZero(saleValue, nameof(saleValue));
    
    SaleId = saleId;
    TotalQuantity = totalQuantity;
    SaleValue = saleValue;
  }
}