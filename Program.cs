using System;
using System.Diagnostics;

namespace NumberlessNumber
{
    class Program
    {            

        static void Main(string[] args)
        {
            //Test ==
            Debug.Assert(Number.Parse("OO") == Number.Parse("OO"));
            Debug.Assert(Number.Parse("") == Number.Parse(""));

            //Test !=
            Debug.Assert(Number.Parse("OO") != Number.Parse("O"));
            Debug.Assert(Number.Parse("") != Number.Parse("OO"));
            Debug.Assert(Number.Parse("OO") != Number.Parse(""));
            Debug.Assert(!(Number.Parse("") != Number.Parse("")));

            //Test >
            Debug.Assert(Number.Parse("O") > Number.Parse(""));
            Debug.Assert(Number.Parse("OO") > Number.Parse(""));
            Debug.Assert(Number.Parse("") > Number.Parse("X"));
            Debug.Assert(Number.Parse("") > Number.Parse("XX"));

            //Test <
            Debug.Assert(Number.Parse("") < Number.Parse("O"));
            Debug.Assert(Number.Parse("") < Number.Parse("OO"));
            Debug.Assert(Number.Parse("X") < Number.Parse(""));
            Debug.Assert(Number.Parse("XX") < Number.Parse(""));

            //Test >=
            Debug.Assert(Number.Parse("O") >= Number.Parse(""));
            Debug.Assert(Number.Parse("OO") >= Number.Parse(""));
            Debug.Assert(Number.Parse("") >= Number.Parse("X"));
            Debug.Assert(Number.Parse("") >= Number.Parse("XX"));
            Debug.Assert(Number.Parse("") >= Number.Parse(""));
            Debug.Assert(Number.Parse("X") >= Number.Parse("X"));
            Debug.Assert(Number.Parse("O") >= Number.Parse("O"));

            //Test <=
            Debug.Assert(Number.Parse("") <= Number.Parse("O"));
            Debug.Assert(Number.Parse("") <= Number.Parse("OO"));
            Debug.Assert(Number.Parse("X") <= Number.Parse(""));
            Debug.Assert(Number.Parse("XX") <= Number.Parse(""));
            Debug.Assert(Number.Parse("") <= Number.Parse(""));
            Debug.Assert(Number.Parse("X") <= Number.Parse("X"));
            Debug.Assert(Number.Parse("O") <= Number.Parse("O"));

            //Test ++
            var x = Number.Parse("");
            x++;
            Debug.Assert(x == Number.Parse("O"));
            x = Number.Parse("O");
            x++;
            Debug.Assert(x == Number.Parse("OO"));
            x = Number.Parse("X");
            x++;
            Debug.Assert(x == Number.Parse(""));

            //Test --
            x = Number.Parse("");
            x--;
            Debug.Assert(x == Number.Parse("X"));
            x = Number.Parse("X");
            x--;
            Debug.Assert(x == Number.Parse("XX"));
            x = Number.Parse("O");
            x--;
            Debug.Assert(x == Number.Parse(""));

            //Test - (Unary: negation)
            Debug.Assert(-Number.Parse("OO") == Number.Parse("XX"));
            Debug.Assert(-Number.Parse("XX") == Number.Parse("OO"));
            Debug.Assert(-Number.Parse("") == Number.Parse(""));

            //Test +
            Debug.Assert(Number.Parse("O") + Number.Parse("O") == Number.Parse("OO"));
            Debug.Assert(Number.Parse("O") + Number.Parse("") == Number.Parse("O"));
            Debug.Assert(Number.Parse("") + Number.Parse("O") == Number.Parse("O"));
            Debug.Assert(Number.Parse("X") + Number.Parse("O") == Number.Parse(""));
            Debug.Assert(Number.Parse("O") + Number.Parse("X") == Number.Parse(""));
            Debug.Assert(Number.Parse("") + Number.Parse("") == Number.Parse(""));

            //Test - (Binary: subtraction)
            Debug.Assert(Number.Parse("O") - Number.Parse("O") == Number.Parse(""));
            Debug.Assert(Number.Parse("O") - Number.Parse("") == Number.Parse("O"));
            Debug.Assert(Number.Parse("") - Number.Parse("O") == Number.Parse("X"));
            Debug.Assert(Number.Parse("X") - Number.Parse("O") == Number.Parse("XX"));
            Debug.Assert(Number.Parse("O") - Number.Parse("X") == Number.Parse("OO"));
            Debug.Assert(Number.Parse("") - Number.Parse("") == Number.Parse(""));

            //Test *
            Debug.Assert(Number.Parse("OO") * Number.Parse("OOO") == Number.Parse("OOOOOO"));
            Debug.Assert(Number.Parse("") * Number.Parse("O") == Number.Parse(""));
            Debug.Assert(Number.Parse("O") * Number.Parse("") == Number.Parse(""));
            Debug.Assert(Number.Parse("XX") * Number.Parse("OOO") == Number.Parse("XXXXXX"));
            Debug.Assert(Number.Parse("OO") * Number.Parse("XXX") == Number.Parse("XXXXXX"));
            Debug.Assert(Number.Parse("XX") * Number.Parse("XXX") == Number.Parse("OOOOOO"));

            //Test /
            Debug.Assert(Number.Parse("O") / Number.Parse("O") == Number.Parse("O"));
            Debug.Assert(Number.Parse("OOOOOO") / Number.Parse("OO") == Number.Parse("OOO"));
            Debug.Assert(Number.Parse("OOOOO") / Number.Parse("OO") == Number.Parse("OO"));
            Debug.Assert(Number.Parse("XXXXXX") / Number.Parse("OO") == Number.Parse("XXX"));
            Debug.Assert(Number.Parse("XXXXX") / Number.Parse("OO") == Number.Parse("XX"));
            Debug.Assert(Number.Parse("OOOOOO") / Number.Parse("XX") == Number.Parse("XXX"));
            Debug.Assert(Number.Parse("OOOOO") / Number.Parse("XX") == Number.Parse("XX"));
            Debug.Assert(Number.Parse("XXXXXX") / Number.Parse("XX") == Number.Parse("OOO"));
            Debug.Assert(Number.Parse("XXXXX") / Number.Parse("XX") == Number.Parse("OO"));
            Debug.Assert(Number.Parse("") / Number.Parse("O") == Number.Parse(""));
            bool argumentOutOfRangeExceptionThrown = false;
            try 
            { 
                var temp = Number.Parse("O") / Number.Parse("");
            } catch(ArgumentOutOfRangeException) 
            {
                argumentOutOfRangeExceptionThrown = true;
            }
            Debug.Assert(argumentOutOfRangeExceptionThrown);
            
            //Test %
            Debug.Assert(Number.Parse("O") % Number.Parse("O") == Number.Parse(""));
            Debug.Assert(Number.Parse("OOOOOO") % Number.Parse("OOO") == Number.Parse(""));
            Debug.Assert(Number.Parse("OOOOO") % Number.Parse("OOO") == Number.Parse("OO"));
            Debug.Assert(Number.Parse("XXXXXX") % Number.Parse("OOO") == Number.Parse(""));
            Debug.Assert(Number.Parse("XXXXX") % Number.Parse("OOO") == Number.Parse("XX"));
            Debug.Assert(Number.Parse("OOOOOO") % Number.Parse("XXX") == Number.Parse(""));
            Debug.Assert(Number.Parse("OOOOO") % Number.Parse("XXX") == Number.Parse("XX"));
            Debug.Assert(Number.Parse("XXXXXX") % Number.Parse("XXX") == Number.Parse(""));
            Debug.Assert(Number.Parse("XXXXX") % Number.Parse("XXX") == Number.Parse("OO"));
            Debug.Assert(Number.Parse("") % Number.Parse("O") == Number.Parse(""));
            argumentOutOfRangeExceptionThrown = false;
            try 
            { 
                var temp = Number.Parse("O") % Number.Parse("");
            } catch(ArgumentOutOfRangeException) 
            {
                argumentOutOfRangeExceptionThrown = true;
            }
            Debug.Assert(argumentOutOfRangeExceptionThrown);
        }
    }
}