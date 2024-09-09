

using FluentBuilder.Console;

Console.WriteLine("Fluent Builder Demo");

var builderWithIndividualSalesPeriods = new CategorySalesCalculatorBuilder("Science Fiction")
  .WithBook(book => book.AddSalesPeriod("01", 100, 200.00m)
      .AddSalesPeriod("02", 100, 200.00m)
      .AddSalesPeriod("03", 100, 200.00m),
    "Peter F. Hamilton",
    "Reality Dysfunction")
  .Calculate();

foreach (var authorSales in builderWithIndividualSalesPeriods.Sales())
{
  Console.WriteLine($"builderWithIndividualSalesPeriods = Author: {authorSales.Key} - Sales: {authorSales.Value}");
}

Console.WriteLine();

var salesPeriods = new List<SalesPeriod>()
{
  new SalesPeriod("01", 100, 200.00m),
  new SalesPeriod("02", 100, 200.00m)
};

var builderWithListSalesPeriod = new CategorySalesCalculatorBuilder("Science Fiction")
  .WithBook(book => book.AddSalesPeriods(salesPeriods),
    "Peter F. Hamilton",
    "Reality Dysfunction")
  .Calculate();

foreach (var authorSales in builderWithListSalesPeriod.Sales())
{
  Console.WriteLine($"builderWithListSalesPeriod = Author: {authorSales.Key} - Sales: {authorSales.Value}");
}
  
var builderNoSalesPeriods = new CategorySalesCalculatorBuilder("Science Fiction")
  .WithBookParameters(
    "Peter F. Hamilton",
    "Reality Dysfunction")
  .Calculate();
  
foreach (var authorSales in builderNoSalesPeriods.Sales())
{
  Console.WriteLine($"builderWithListSalesPeriod = Author: {authorSales.Key} - Sales: {authorSales.Value}");
}

Console.WriteLine();

var salesPeriodsMultiUse = new List<SalesPeriod>()
{
  new SalesPeriod("01", 100, 200.00m),
  new SalesPeriod("02", 100, 200.00m)
};

var additionalBooks=  new List<Book>()
{
  new BookBuilder("J.R.R. Tolkien", "The Hobbit")
    .AddSalesPeriods(salesPeriodsMultiUse)
    .Build(),
  new BookBuilder("Craig Alanson", "Columbus Day")
    .AddSalesPeriods(salesPeriodsMultiUse)
    .Build()
};
var builderWithMultiListSalesPeriod = new CategorySalesCalculatorBuilder("Science Fiction")
  .WithBook(book => book.AddSalesPeriods(salesPeriodsMultiUse),
    "Peter F. Hamilton",
    "Reality Dysfunction")
  .WithBooks(additionalBooks)
  .Calculate();
  
foreach (var authorSales in builderWithMultiListSalesPeriod.Sales())
{
  Console.WriteLine($"builderWithMultiListSalesPeriod = Author: {authorSales.Key} - Sales: {authorSales.Value}");
}

var x= new SalesPeriod("001", 100, 200.00m);