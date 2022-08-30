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
        var myints=Parse(mynums);
        var negitaveObj=checkNegitaveNumbers(myints);
        if(negitaveObj.negitaveExists){
            throw new NegitaveNotAllowedException(negitaveObj.negitaves);
        }
        var filteredNumbers=bigNumberFilter(myints);
        var mysum=filteredNumbers.Aggregate((sum,x)=>sum+=x);
        return mysum;
     }

        private List<int> bigNumberFilter(List<int> myints)
        {
            var myFilteredInts=myints.Where(x=>x<1000).ToList();
            return myFilteredInts;
        }

        private negitaveList checkNegitaveNumbers(List<int> myint)
        {
            negitaveList nList=new negitaveList();
            nList.negitaveExists=myint.Exists(x=> x<0);
            nList.negitaves=myint.Select(x=>x).Where(x=>x<0).ToList();
            return nList;
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
        class negitaveList{
            
             public bool negitaveExists{get;set; }
             public List<int> negitaves{get;set; }
        }
         public class NegitaveNotAllowedException : Exception
        {
            public NegitaveNotAllowedException(List<int> myints)

                : base("negatives not allowed:" +string.Join<int>(',', myints))
            {
            }
        }
    }   
}