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
        var mynums=numbers.Split(',');
        var myint=Parse(mynums);
        var mysum=myint.Aggregate((sum,x)=>sum+=x);
        return mysum;
     }

        private List<int> Parse(string[] mynums)
        {
            List<int> myints;
            myints=mynums.Select(x=>Int32.Parse(x)).ToList();
            return myints;
        }
    }   
}