namespace Calculator.Tests;
public class UnitTest1
{
    [Fact]
    public void TestForEmptyString()
    {
        //Arrange
        var calculator = new Kata.calculator();
        //Act
        var actual = calculator.add("");
        //Assert
        Assert.Equal(0, actual);

    }
    [Fact]
    public void TestForOneNumber()
    {
        //Arrange
        var calculator = new Kata.calculator();
        //Act
        var actual = calculator.add("1");
        //Assert
        Assert.Equal(1, actual);
    }
    [Fact]
    public void TestForTwoPositiveNumbers()
    {
        //Arrange
        var calculator = new Kata.calculator();
        //Act
        var actual = calculator.add("1,2");
        //Assert
        Assert.Equal(3, actual);
    }
    [Fact]
    public void TestForThreePositiveNumbers()
    {
        //Arrange
        var calculator = new Kata.calculator();
        //Act
        var actual = calculator.add("1,2,3");
        //Assert
        Assert.Equal(6, actual);
    }
    [Fact]
    public void TestForThreePositiveNumbersWithNewLine()
    {
        //Arrange
        var calculator = new Kata.calculator();
        //Act
        var actual = calculator.add("1\n2,3");
        //Assert
        Assert.Equal(6, actual);
    }
[Fact]
    public void TestForThreePositiveNumbersWithDelimiterPercent()
    {
        //Arrange
        var calculator = new Kata.calculator();
        //Act
        var actual = calculator.add("\\%1%2%3");
        //Assert
        Assert.Equal(6, actual);
    }
    [Fact]
    public void TestForThreePositiveNumbersWithDelimiterPercentAndNewLine()
    {
        //Arrange
        var calculator = new Kata.calculator();
        //Act
        var actual = calculator.add("\\%1\n2%3");
        //Assert
        Assert.Equal(6, actual);
    }
}