using System;

namespace Automation.Wikipedia01
{
    class Assertions
    {
        public static void AssertIt(Action assert)
        {
            try
            {
                assert.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}