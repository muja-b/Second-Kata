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
        if(numbers.Equals(""))return 0;
        char delimiter=',';
        if(numbers.StartsWith("\\")){
            delimiter=GetDelimiter(numbers);
            numbers=numbers.Remove(0,2);
        }
        var numbersWithoutNewLine=removeNewLine(numbers,delimiter);
        var mynums=numbersWithoutNewLine.Split(delimiter);
        var myint=Parse(mynums);
        var mysum=myint.Aggregate((sum,x)=>sum+=x);
        return mysum;
     }

        private string removeNewLine(string numbers,char delimiter)
        {
            var mynums=numbers.Replace("\n",delimiter.ToString());
            return mynums;
        }

        private char GetDelimiter(string numbers)
        {
            return numbers[1];
        }

        private List<int> Parse(string[] mynums)
        {
            List<int> myints;
            myints=mynums.Select(x=>Int32.Parse(x)).ToList();
            return myints;
        }
    }   
}