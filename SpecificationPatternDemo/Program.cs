using System;
using System.Linq.Expressions;
using static SpecificationPatternDemo.AnonymousMethodUtility;
using static SpecificationPatternDemo.DelegateUtility;
using static SpecificationPatternDemo.LampdaExpressionsUtility;

namespace SpecificationPatternDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
        
        #region "Delegate Basics"

            //LD STEP003
            // Instantiate the delegate and set "aMethodForDelegateThatPrint" as a subscriber
            aDelegate handler = aMethodForDelegateThatPrint;

            //LD STEP004
            // Call the delegate.
            handler("output something");

            //LD STEP005
            //Because the instantiated delegate is an object, it can be passed as a parameter, or assigned to a 
            //property. This allows a method to accept a delegate as a parameter, and call the delegate at some 
            //later time. This is known as an asynchronous callback, and is a common method of notifying a caller 
            //when a long process has completed. When a delegate is used in this fashion, the code using the 
            //delegate does not need any knowledge of the implementation of the method being used. 
            //The functionality is similar to the encapsulation interfaces provide.

            //LD STEP006
            //Another common use of callbacks is defining a custom comparison method and passing that delegate 
            //to a sort method. It allows the caller's code to become part of the sort algorithm. 
            //The following example method uses the Del type as a parameter:
            MethodWithCallback(1, 2, handler);


            #endregion region

        #region "Event Delegate"

            //LD STEP011
            // tie "aMethodThatPrintAString" to the event, this method has to have the same signature of the 
            // delegate tied with the event
            eventToNotifyWhenAStringChange += aMethodThatPrintAStringInvokedByDelegateAfterEventFired;

            void aMethodThatPrintAStringInvokedByDelegateAfterEventFired(string aString)
            {
                Console.WriteLine("Event notification about the current string: " + aString);
            }

            //LD STEP012
            // at any time we will call the method "ThisMethodChangeAString"
            ThisMethodChangeAString("luca");
            //Console.ReadLine();
            #endregion

        #region "Delegate AND Lampda Expressions"
            //LD STEP014

            //LD Initialize delegate with lampda expression
            // public delegate int deleg(int i);
            deleg myDelegate = x => x * x; // instead to assign a named method, we use the anonymous function that is a lampda expression
            int j = myDelegate(5); //LD then just call the delagate as usual

            //LD Initialize delegate with lampda expression and function
            Func<int, int> myDelegate2 = x => x * x;
            int j2 = myDelegate2(5); //LD then just call the delagate as usual

            #endregion

        #region Anonymoys Methods

            //LD STANDARD APPROACH
            del d0 = multiplyAndPrint;
            d0(2, 3);

            //LD ANONYMOUS APPROACH - anonymous method using delegate keyword
            // her eis like to subscribe the method "multiplyAndPrint" buy by using an inline anonymous approach.
            del d1 = delegate (int x, int y) { int number = x + y; Console.WriteLine("total anonymous ld: " + number); };
            d1(2, 3);


            //LD ANONYMOUS APPROACH - anonymous method using delegate keyword with return
            delReturningInt d2 = delegate (int x, int y) { return x + y;}; //here I assign the subscriber
            int aNumber= d2(2, 3);

            #endregion

        #region Expression Trees

                #region Example "Creating Expression Trees from Lambda Expressions"

                /* //LD 
                When a lambda expression is assigned to a variable of type Expression<TDelegate>, 
                the compiler emits code to build an expression tree that represents the lambda expression. 
                */
                Expression<Func<int, int, int>> expression = (num1, num2) => num1 + num2;

                Func<int, int, int> compiledExpression = expression.Compile ();// Compile the expression

                int result = compiledExpression(3, 4); // Execute the expression. return 7

                #endregion internal

            #endregion

            Console.ReadLine();
        }
    }
}