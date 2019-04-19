using System;
using System.Text;

namespace NumberlessNumber
{
    public class Number
    {

        public static Number operator ++(Number numberToIncrement)
        {
            return numberToIncrement.Next();
        }

        public static Number operator --(Number numberToDecrement)
        {
            return numberToDecrement.Previous();
        }

        public static bool operator >(Number leftOperand, Number rightOperand)
        {            
            bool result;

            //If they're equal
            if (leftOperand == rightOperand)
            {
                result = false;
            }

            //If they're different
            else
            {

                //Simultaneously search predecessors and successors of leftOperand until rightOperand is found
                Number successorOfLeftOperand = leftOperand;
                Number predecessorOfLeftOperand = leftOperand;
                do
                {
                    successorOfLeftOperand++;
                    predecessorOfLeftOperand--;
                } while (successorOfLeftOperand != rightOperand && predecessorOfLeftOperand != rightOperand);

                //If number2 was predecessor --> number1 was greater
                result = predecessorOfLeftOperand == rightOperand;
            }            
            return result;
        }

        public static bool operator <(Number leftOperand, Number rightOperand)
        {     
            return leftOperand != rightOperand && !(leftOperand > rightOperand);
        }

        public static bool operator >=(Number leftOperand, Number rightOperand)
        {            
            return leftOperand == rightOperand || leftOperand > rightOperand;
        }

        public static bool operator <=(Number leftOperand, Number rightOperand)
        {            
            return leftOperand == rightOperand || leftOperand < rightOperand;
        }

        private bool IsPositive()
        {
            return this > Origin();
        }

        private bool IsNegative()
        {
            return this < Origin();
        }

        public static Number operator -(Number numberToNegate)
        {
            Number result = Origin();

            //If positive --> decrement for each
            if (numberToNegate.IsPositive())
                for (Number i = numberToNegate; i != Origin(); i--)
                    result--;

            //If negative --> increment for each
            else if (numberToNegate.IsNegative())
                for (Number i = numberToNegate; i != Origin(); i++)
                    result++;
            return result;
        }

        private Number AbsoluteValue()
        {
            return IsPositive()
                ? this
                : -this;
        }

        public static Number operator +(Number leftOperand, Number rightOperand)
        {
            Number result = leftOperand;
            for (Number i = rightOperand.AbsoluteValue(); i != Origin(); i--)
            {
                if (rightOperand.IsPositive())
                    result++;
                else
                    result--;
            }
            return result;
        }

        public static Number operator -(Number leftOperand, Number rightOperand)
        {
            return leftOperand + -rightOperand;
        }

        public static Number operator *(Number leftOperand, Number rightOperand)
        {
            Number result = Origin();
            for(Number i = rightOperand.AbsoluteValue(); i != Origin(); i--)
            {                
                if (rightOperand.IsPositive())
                    result += leftOperand;
                else
                    result -= leftOperand;
            }
            return result;
        }

        public static Number operator /(Number dividend, Number divisor)
        {
            //Validate
            if (divisor == Origin())
                throw new ArgumentOutOfRangeException();

            //Initialize counters
            Number absoluteQuotient = Origin();
            Number absoluteRemainder = dividend.AbsoluteValue();
            Number absoluteDivisor = divisor.AbsoluteValue();

            //Subtract divisor as many times as possible
            while(absoluteRemainder >= absoluteDivisor)
            {
                absoluteQuotient++;
                absoluteRemainder -= absoluteDivisor;
            }

            //Return with correct sign
            if ((dividend.IsPositive() && divisor.IsPositive())
                    || (dividend.IsNegative() && divisor.IsNegative()))
                return absoluteQuotient;
            else
                return -absoluteQuotient;
        }

        public static Number operator %(Number dividend, Number divisor)
        {
            //Get absolute remainder
            Number quotient = dividend / divisor;
            Number product = divisor * quotient;
            Number absoluteRemainder = dividend.AbsoluteValue() - product.AbsoluteValue();

            //Return with correct sign
            if ((dividend.IsPositive() && divisor.IsPositive())
                    || (dividend.IsNegative() && divisor.IsNegative()))
                return absoluteRemainder;
            else
                return -absoluteRemainder;
        }

        public static Number Parse(string numberString)
        {
            //Start at origin
            Number result = Origin();
            
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
            if (this >= Origin())
                for(Number currentNumber = this; currentNumber != Origin(); currentNumber--)
                    sb.Append("O");
            else
                for(Number currentNumber = this; currentNumber != Origin(); currentNumber++)
                    sb.Append("X");
            return sb.ToString();
        }

        public static Number FromDigits(Number digitBase, params Number[] digits)
        {
            //Validate
            if (digitBase <= Parse("O"))
                throw new ArgumentOutOfRangeException();

            //Calculate
            Number result = Origin();
            foreach(Number digit in digits)
            {
                result += digit;
                result *= digitBase;
            }
            result /= digitBase;
            return result;
        }

        private Number() { }    

        private Number Next()
        {
            //Ensure next exists    
            lock(typeof(Number))
            {       
                if (_Next == null)
                {             
                    _Next = new Number();  
                    _Next._Previous = this;     
                }
            }

            //Return next
            return _Next; 
        }  
        private Number _Next;   

        private Number Previous()
        {
            //Ensure previous exists    
            lock(typeof(Number))
            {       
                if (_Previous == null)
                {             
                    _Previous = new Number();  
                    _Previous._Next = this;     
                }
            }

            //Return previous
            return _Previous; 
        }  
        private Number _Previous;

        private static Number Origin() 
        {
            //Ensure origin exists    
            lock(typeof(Number))
            {       
                if (_Origin == null)
                {             
                    _Origin = new Number();       
                }
            }

            //Return origin
            return _Origin; 
        }
        private static Number _Origin;
    }
}