using System;

namespace ConsoleApplication1
{
    class expression
    {
        private String expr;
        private double expected;
        public void add(String exp)
        {
            expr = exp;
        }

        public void result(double result)
        {
            expected = result;
        }

        public bool Equals(double given)
        {
            return given.Equals(expected);
        }
    
    }
}
