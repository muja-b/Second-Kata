namespace Calculator.Tests;
public class UnitTest1
{
    [Fact]
    public void TestForEmptyString()
    {
        //Arrange
        var calculator=new Kata.calculator();
        //Act
        var actual=calculator.add("");
        //Assert
        Assert.Equal(0,actual);

    }
    [Fact]
    public void TestForOneNumber()
    {
        //Arrange
        var calculator=new Kata.calculator();
        //Act
        var actual=calculator.add("1");
        //Assert
        Assert.Equal(1,actual);
    }

}