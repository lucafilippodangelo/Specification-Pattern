using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificationPatternDemo
{
    public static class DelegateUtility
    {

        #region Basic Delegate Example - "Delegate Calls"

        /// <summary>
        /// //LD SPEP001
        /// A delegate object is normally constructed by providing the name of the method the delegate will wrap, 
        /// or with an anonymous Method. Once a delegate is instantiated, a method call made to the delegate will 
        /// be passed by the delegate to that method.
        /// </summary>
        public delegate void aDelegate(string message);

        /// <summary>
        /// //LD SPEP002
        /// The parameters passed to the delegate by the caller are passed to the method, and the return value, if any, 
        /// from the method is returned to the caller by the delegate. This is known as invoking the delegate. 
        /// An instantiated delegate can be invoked as if it were the wrapped method itself.
        /// </summary>
        public static void aMethodForDelegateThatPrint(string message)
        {
            System.Console.WriteLine(message);
        }

        /// <summary>
        /// //LD STEP007
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="callback"></param>
        public static void MethodWithCallback(int param1, int param2, aDelegate inputHandlerAsCallback)
        {
            inputHandlerAsCallback("The number is: " + (param1 + param2).ToString());
        }

        #endregion

        #region Basic Delegate Example - "Event Delegate"
        //LD STEP008
        // declaration of a delegate
        public delegate void EventDelegate(string strX);

        //LD STEP009 
        // tie the delegate to an event, when the event will be fired the delegate
        public static event EventDelegate eventToNotifyWhenAStringChange; 

        //LD STEP010
        // the below method call the event with which the deledate is paired 
        public static void ThisMethodChangeAString(string strNew)
        {
            //inside the method I call the event
            eventToNotifyWhenAStringChange(strNew + " d'angelo");
        }
        #endregion

    }
}
