using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            DanielZajasStringOperations d1 = new DanielZajasStringOperations();
            Console.WriteLine("1. Siem");
            Console.WriteLine(d1.Subsstring("Siemasiemasiemasiema", 0, 4));
            Console.WriteLine("2. Daniel Zajas");
            Console.WriteLine(d1.GetName());
            Console.WriteLine("3a. Jaunsyt");
            Console.WriteLine(d1.GlueBeginingEnd("Justyna"));
            Console.WriteLine("3b. Dlaeni");
            Console.WriteLine(d1.GlueBeginingEnd("Daniel"));
            Console.WriteLine("4. 1, 5");
            Console.WriteLine(d1.LetterPositionInString("Janina", Convert.ToChar("a")));
            Console.WriteLine("5. Jcninc");
            Console.WriteLine(d1.LetterReplace("Janina", Convert.ToChar("a"), Convert.ToChar("c")));
            Console.WriteLine("Daniel, Filip, Weronika, Justyna");
            Console.WriteLine(d1.StringReplace("Daniel, Kamil, Weronika, Justyna", "Kamil", "Filip"));

            Console.ReadKey();

        }
    }
}

public interface StringOperations
{
    string Subsstring(string candidate, int start, int lenght);
    string GetName();
    string GlueBeginingEnd(string candidate);
    int CountOccurences(string candidate, char needle);
    string LetterPositionInString(string candidate, char needle);
    string LetterReplace(string candidate, char needle, char replace);
    string StringReplace(string candidate, string needle, string replace);
}

public class DanielZajasStringOperations : StringOperations
{
    public int CountOccurences(string candidate, char needle)
    {
        throw new NotImplementedException();
    }

    public string GetName()
    {
        return "Daniel Zajas";
    }

    public string GlueBeginingEnd(string candidate)
    {
        string result = "";
        for (int i = 0, j = candidate.Length-1; i < (candidate.Length+1)/2; i++, j--)
        {
            if (i == j) result = result + candidate[i];
            else result = result + candidate[i] + candidate[j];
        }
        return result;
    }

    public string LetterPositionInString(string candidate, char needle)
    {
        string resultString = "";
        for (int i = 0; i < candidate.Length; i++)
        {
            if (candidate[i] == needle)
            {
                resultString = resultString + $"{i} ";
            }
           
        }
        return resultString;
    }

    public string LetterReplace(string candidate, char needle, char replace)
    {
        string result = "";
        for (int i = 0; i<candidate.Length; i++)
        {
            if (candidate[i] == needle) result += replace;
            else result += candidate[i];
        }
        return result;
    }

    public string StringReplace(string candidate, string needle, string replace)
    {
        string result = "";
        int needleFirstLetter = 0;
        for (int i = 0; i < candidate.Length; i++)
        {
            if (candidate[i] == needle[0])
            {
                needleFirstLetter = i;
                for (int j = 0; j<needle.Length; j++) result += needle[j];
                if (result == needle)
                {
                    result = "";
                    for (int k = 0; k < candidate.Length; k++)
                    {
                        if (k != needleFirstLetter) result += candidate[k];
                        else
                        {
                            for (int j = 0; j < replace.Length; j++) { result += replace[j]; }
                            k = k + needle.Length-1;
                        }
                    }
                    return result;
                }
            }
            else { result = ""; needleFirstLetter = 0; }
        }
        return "Something went wrong";
    }
    public string Subsstring(string candidate, int start, int lenght)
    {
        string value = "";
        if(candidate.Length<start || candidate.Length < start+lenght)
        {
            return null;
        }
        else
        {
            for (int i = start; i <= start+lenght-1; i++)
            {
                value += candidate[i];
            }
            return value;
        }

    }

    public bool IsNeedleInsideCandidate(string candidate, string needle)
    {
        string result = "";
        for (int i = 0, j = 0 ; i<candidate.Length && j<needle.Length; i++)
        {
            if (candidate[i] == needle[j])
            {
                result += needle[j];
                j++;
            }
            else { j = 0; result = ""; }
        }
        if (result == needle) return true;
        else return false;
    }
}