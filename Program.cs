using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Calculator
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

    class Number
    {

        public static Number operator ++(Number number)
        {
            return NumberLine.NumberAfter(number);
        }

        public static Number operator --(Number number)
        {
            return NumberLine.NumberBefore(number);
        }

        public static bool operator >(Number number1, Number number2)
        {            
            Number currentNumber = number2;    
            while (currentNumber != NumberLine.LastNumber())
            {
                currentNumber++; 
                if (currentNumber == number1)
                    return true;
            }
            return false;
        }

        public static bool operator <(Number number1, Number number2)
        {     
            return number1 != number2 && !(number1 > number2);
        }

        public static bool operator >=(Number number1, Number number2)
        {            
            return number1 == number2 || number1 > number2;
        }

        public static bool operator <=(Number number1, Number number2)
        {            
            return number1 == number2 || number1 < number2;
        }

        private bool IsPositive()
        {
            return this > NumberLine.Origin;
        }

        private bool IsNegative()
        {
            return this < NumberLine.Origin;
        }

        public static Number operator -(Number number)
        {
            Number result = NumberLine.Origin;

            //If positive --> subtract for each
            if (number.IsPositive())
                for (Number i = number; i != NumberLine.Origin; i--)
                    result--;

            //If negative --> add for each
            else if (number.IsNegative())
                for (Number i = number; i != NumberLine.Origin; i++)
                    result++;
            return result;
        }

        private Number AbsoluteValue()
        {
            return IsPositive()
                ? this
                : -this;
        }

        public static Number operator +(Number number1, Number number2)
        {
            Number result = number1;
            for (Number i = number2.AbsoluteValue(); i != NumberLine.Origin; i--)
            {
                if (number2.IsPositive())
                    result++;
                else
                    result--;
            }
            return result;
        }

        public static Number operator -(Number number1, Number number2)
        {
            return number1 + -number2;
        }

        public static Number operator *(Number number1, Number number2)
        {
            Number result = NumberLine.Origin;
            for(Number i = number2.AbsoluteValue(); i != NumberLine.Origin; i--)
            {                
                if (number2.IsPositive())
                    result += number1;
                else
                    result -= number1;
            }
            return result;
        }

        public static Number operator /(Number number1, Number number2)
        {
            //Validate
            if (number2 == NumberLine.Origin)
                throw new ArgumentOutOfRangeException();

            //Initialize counters
            Number result = NumberLine.Origin;
            Number remaining = number1.AbsoluteValue();
            Number eachSubtraction = number2.AbsoluteValue();

            //Subtract as many times as possible
            while(remaining >= eachSubtraction)
            {
                if ((number1.IsPositive() && number2.IsPositive())
                        || (number1.IsNegative() && number2.IsNegative()))
                    result++;
                else
                    result--;
                remaining -= eachSubtraction;
            }
            return result;
        }

        public static Number operator %(Number number1, Number number2)
        {
            //Get absolute remainder
            Number quotient = number1 / number2;
            Number absoluteRemainder = number1.AbsoluteValue() - (number2 * quotient).AbsoluteValue();

            //Get correct sign
            if ((number1.IsPositive() && number2.IsPositive())
                    || (number1.IsNegative() && number2.IsNegative()))
                return absoluteRemainder;
            else
                return -absoluteRemainder;
        }

        public static Number Parse(string numberString)
        {
            //Start at origin
            Number result = NumberLine.Origin;
            
            //Increment for each 'O', Decrement for each 'X'
            foreach(char c in numberString.ToCharArray())
            {
                if (c.ToString().ToUpper() == "O")
                    result++;
                else if (c.ToString().ToUpper() == "X")
                    result--;
                else
                    throw new ArgumentException();
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this >= NumberLine.Origin)
                for(Number currentNumber = this; currentNumber != NumberLine.Origin; currentNumber--)
                    sb.Append("O");
            else
                for(Number currentNumber = this; currentNumber != NumberLine.Origin; currentNumber++)
                    sb.Append("X");
            return sb.ToString();
        }

        public static Number FromDigits(Number digitBase, params Number[] digits)
        {
            //Validate
            if (digitBase <= Parse("O"))
                throw new ArgumentOutOfRangeException();

            //Calculate
            Number result = NumberLine.Origin;
            foreach(Number digit in digits)
            {
                result += digit;
                result *= digitBase;
            }
            result /= digitBase;
            return result;
        }

        private Number() { }

        private class NumberLine
        {                

            public static Number Origin { get 
            { 
                //Ensure origin exists
                EnsureOrigin();

                //Return origin
                return _Origin; 
            } }

            public static Number NumberAfter(Number original)
            {
                //Ensure next number exists       
                EnsureNext(original);

                //Return next number
                return NumberList.Find(original).Next.Value;
            }

            public static Number NumberBefore(Number original)
            {
                //Ensure previous number exists
                EnsurePrevious(original);

                //Return previous number
                return NumberList.Find(original).Previous.Value;
            }

            public static Number GetFirst()
            {
                return NumberList.First();
            }

            public static Number LastNumber()
            {
                return NumberList.Last();
            }

            private static void EnsureOrigin()
            {         
                lock(typeof(NumberLine))
                {       
                    if (!NumberList.Any())
                    {             
                        _Origin = new Number();       
                        NumberList.AddLast(_Origin);
                    }
                }
            }

            private static void EnsureNext(Number number)
            { 
                lock(typeof(NumberLine))
                {   
                    if (NumberList.Find(number).Next == null)
                        NumberList.AddLast(new Number());
                }
            }

            private static void EnsurePrevious(Number number)
            { 
                lock(typeof(NumberLine))
                {   
                    if (NumberList.Find(number).Previous == null)
                        NumberList.AddFirst(new Number());
                }
            }
            
            private static LinkedList<Number> NumberList { get; } = new LinkedList<Number>();
            private static Number _Origin;
        }
    }
}