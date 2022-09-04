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
        string delimiter=",";
        if(numbers.StartsWith("\\"))
            {
                delimiter = GetDelimiter(numbers);
                numbers = removePrefix(numbers);
                numbers = numbers.Substring(delimiter.Length + 1);
            }
        var numbersWithoutNewLine=removeNewLine(numbers,delimiter);
        var mynums=numbersWithoutNewLine.Split(delimiter);
        var myints=Parse(mynums);
        var negitaveObj=checkNegitaveNumbers(myints);
        if(negitaveObj.negitaveExists){
            throw new NegitaveNotAllowedException(negitaveObj.negitaves);
        }
        var filteredNumbers=bigNumberFilter(myints);
        var mysum=filteredNumbers.Sum();
        return mysum;
     }

        private string removePrefix(string numbers)
        {
            var mynumbers= numbers=numbers.Replace("\\","");
            mynumbers = mynumbers.Replace("[", "");
            mynumbers = mynumbers.Replace("]", "");
            return mynumbers;
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

        private string removeNewLine(string numbers,string delimiter)
        {
            var mynums=numbers.Replace("\n",delimiter);
            return mynums;
        }

        private string GetDelimiter(string numbers)
        {
            var mynumbers=numbers.Substring(1,numbers.IndexOf('\n')-1);
            if(numbers.StartsWith("//[")){
                mynumbers=numbers.Substring(numbers.IndexOf('[')+1,numbers.IndexOf(']')-1);
            }
            return mynumbers;
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