using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificationPatternDemo
{
    public static class AnonymousMethodUtility
    {
        /*
        DEFINITION
        An anonymous method is inline unnamed method in the code. It is created using the delegate keyword and 
        doesn’t required name and return type. Hence we can say, an anonymous method has only body without name, 
        optional parameters and return type. An anonymous method behaves like a regular method and allows us to 
        write inline code in place of explicitly named methods.
        */

        //LD declaration of a delegate
        public delegate void del(int x, int y);

        public static void multiplyAndPrint(int x, int y)
        {
            int number = x * y;
            Console.WriteLine("total: " + number);
        }

        public delegate int delReturningInt(int x, int y);
    }
}
