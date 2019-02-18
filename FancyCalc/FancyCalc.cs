using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalc
{
    public class FancyCalcEnguine
    {
        delegate double CalculateFunction(int a, int b);
        public double Add(int a, int b)
        {
            //throw new NotImplementedException();
            double c = 0;
            try
            {
                c = a + b;
            }
            catch(ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException("overflow");
            }
            return c;
        }


        public double Subtract(int a, int b)
        {
            double c = 0;
            try
            {
                c = a - b;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException("overflow");
            }
            return c;
        }


        public double Multiply(int a, int b)
        {
            double c = 0;
            try
            {
                c = a * b;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException("overflow");
            }
            return c;
        }

        public double Division(int a, int b)
        {
            double c = 0;
            try
            {
                c = a / b;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException("overflow");
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("Divide By Zero");
            }
            return c;
        }

        //generic calc method. usage: "10 + 20"  => result 30
        public double Culculate(string expression)
        {
            if(expression == null) 
                throw new ArgumentNullException("expression is null")
            int space = expression.IndexOf(" ");
            while(space>0){
                expression = expression.Remove(space,1);
                space = expression.IndexOf(" ");
            }
            int a = GetNumber(ref expression);
            char symbol = GetSymbol(ref expression);
            int b = GetNumber(ref expression);
            CalculateFunction calculateFunction = GetFunction(symbol);
            return calculateFunction(a, b);
            
        }

        private CalculateFunction GetFunction(char symbol)
        {
            switch (symbol)
            {
                case '+':
                    return Add;
                case '-':
                    return Subtract;
                case '*':
                    return Multiply;
                case '/':
                    return Division;
                default:
                    throw new ArgumentOutOfRangeException("not find symbol");
            }
        }

        private int GetNumber(ref string expression)
        {
            string s;
            do
            {
                s = expression.Substring(0,1);
                if(!IsNumber(s))
                    expression = expression.Substring(1);
                if(expression.Length < 1)
                    throw new ArgumentOutOfRangeException("not find number");
            } while (!IsNumber(s) || expression.Length < 1);
            int i = 2;
            while (IsNumber(s) && (i < expression.Length))
            {
                s = expression.Substring(0,i);
                i++;
            }
            if(i <= expression.Length)
                s = s.Substring(0,s.Length - 1);
            expression = expression.Substring(s.Length);
            return Convert.ToInt32(s);
        }

        private char GetSymbol(ref string expression)
        {

            string s;
            do
            {
                s = expression.Substring(0,1);
                if (!IsMathSymbol(s))
                    expression = expression.Substring(1);
                if (expression.Length < 1)
                    throw new ArgumentOutOfRangeException("not find symbol");
            } while (!IsMathSymbol(s) || expression.Length < 1);
            expression.Substring(1);
            return s[0];
        }

        private bool IsNumber(string s)
        {
            bool result = true;
            try
            {
                int number = Convert.ToInt32(s);
                number++;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        private bool IsMathSymbol(string s)
        {
            if (s[0] == '+' || s[0] == '-' || s[0] == '*' || s[0] == '/')
                return true;
            return false;
        }
    }
}
