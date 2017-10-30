using System;
using InteropExample.FSharp;

namespace InteropExample.CSharp
{
    class Program
    {
        static void Main()
        {
            // Example 1: Classes and interfaces
            Console.WriteLine("Example 1: Classes and interfaces");
            Console.WriteLine("---------------------------------");
            
            Login login = new Login(42, "admin", "1234");

            PrintWelcomeMessage(login);

            Calculator calculator = new Calculator();
            Console.WriteLine("CurriedAdd, 2 + 3: " + calculator.CurriedAdd(2, 3));
            Console.WriteLine("TupleAdd, 2 + 3: " + calculator.TupleAdd(2, 3));

            // Example 2: Records
            Car car = new Car("Tesla", "S");

            // Example 3: Static properties in modules
            Console.WriteLine("\nExample 2: Static properties in modules");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine(ModuleExample.staticGetterPropertyExample);
            Console.WriteLine(ModuleExample.staticGetterSetterPropertyExample);

            ModuleExample.staticGetterSetterPropertyExample = "new value for property";

            Console.WriteLine(ModuleExample.staticGetterSetterPropertyExample);

            // Example 4: Functions in modules
            Console.WriteLine("\nExample 3: Functions in modules");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("4 times 2: " + ModuleExample.times2(4));
            Console.WriteLine("4 times 4: " + ModuleExample.times4(4));

            // Wait for input before closing command prompt
            Console.ReadLine();
        }

        private static void PrintWelcomeMessage(ILogin login)
        {
            if (login.IsValid)
                Console.WriteLine("Login successful");
            else
                Console.WriteLine("Failed to log in");
        }
    }
}
