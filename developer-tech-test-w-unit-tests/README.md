# WeBuyAnyCar Developer Test
For this test, you should Visual Studio (Express will be fine) and should be familiar with C# and the .NET Framework. The test has a Unit Test project (MSTest) which also uses Moq.

## Scenario
You're tasked with implementing a new valuation engine that can be included in other applications. Some of the initial groundwork has been done for it and you have:

 - Visual Studio solution with 2 projects (1 class library & 1 unit test project)
 - ValuationEngine with some initial functionality.
 - Some unit tests to check the functionality as it is.

You're strongly encouraged to write unit tests to prove your success in each exercise. Feel free to refactor anything you feel needs it.

## Exercises

1. In addition to reducing our valuation based on mileage, we also need to reduce it based on Age too. The price offered should reduce by 5% for each year (including age zero) before the deduction for the mileage is applied.
   Hint: a 3 year old car doesn't have it's value reduced by 15%. It's 5%, then 5% and then 5%.

2. We've lost money on a few cars sold in their first year. We need to tweak the formula and for the first year only (age of zero), reduce the value by 20%, then 5% every year after as before.

3. Now we're offering valuations too low! Change the PriceReductionForMileage() method to do the following:

   * For cars 3 years old or less, reduce by 0.5% per 1000 miles.
   * For cars 4 to 9 years old, reduce by 0.3% per 1000 miles.
   * For cars 10 years and over, reduce by 0.1% per 1000 miles.

4. Things are going better - we’re buying more cars! However, in some scenarios, we’re offering a minus valuation, meaning the customer has to pay us to buy their car! We need to make sure that there is a minimum valuation of £250 for every car!

5. It's come to light that we don't know about all cars in our VehicleFinder. We need to add a property for passing back (any number of) errors in our Valuation object. Once done, we need to send back an error for each of the following when appropriate:

   * If VehicleFinder.FindByRegPlate() method returns null, we can't identify the car.
   * If the base valuation for a car is null, we can't value a car!
