global using Xunit;
using Kata;
namespace Kata
{

    class mainClass
    {
    static void main (string[] Args){

    }
    
    }
    class calculator
    {
     public int add(string numbers){
        if(numbers.Length==0)return 0;
        var mynums=numbers.Split(',');
        if(mynums.Length==1)return Int32.Parse(mynums[0]);
        int number1=Int32.Parse(mynums[0]);
        int number2=Int32.Parse(mynums[1]);
        return number1+number2;
     }   
    }   
}