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
        List <string> delimiters=new();
        delimiters.Add(",");
        if(numbers.StartsWith("\\"))
            {
                delimiters = GetDelimiter(numbers);
                numbers = removePrefix(numbers);
                
            }
        var numbersWithoutNewLine=removeNewLine(numbers,delimiters[0]);
        var arr=delimiters.ToArray();
        var mynums=numbersWithoutNewLine.Split(arr,StringSplitOptions.RemoveEmptyEntries);
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
            var startingIndex=numbers.First(x=>Char.IsDigit(x));
            var mynumbers = numbers.Substring(numbers.IndexOf(startingIndex));
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

        private List <string> GetDelimiter(string numbers)
        {   
            List<string> myList=new();
            
            if(numbers.StartsWith("\\[")){
                for (int i = 0; i < numbers.Length; i++)
                {
                 if(numbers[i]=='[')myList.Add(numbers.Substring(i+1,numbers.Substring(i).IndexOf(']')-1));   
                }
                
            }else{
              myList.Add(numbers.Substring(1,numbers.IndexOf('\n')-1));
            }
            return myList;
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