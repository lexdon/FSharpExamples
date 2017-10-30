using System;

namespace WcfServiceLibraryExample
{
    public class HelloWorldService : IHelloWorldService
    {
        public string SayHelloWorld() => "Hello World!";

        public string SayHelloTo(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            return $"Hello {name}!";
        }

        public Greeting GetGreetingFor(string name)
        {
            return new Greeting
            {
                Content = $"Hello {name}!",
                TimeStamp = DateTime.Now
            };
        }

        public string FormatGreeting(Greeting greeting)
        {
            return $"{greeting.Content} ({greeting.TimeStamp})";
        }
    }
}
