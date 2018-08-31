using System;

namespace TESTConsoleApp1mosh
{
    /// <summary>
    /// BUILDER DESIGN PATTERN - needs refining eg order of method calls - Q: is this builder of just fluent interface?
    ///
    /// from https://exceptionnotfound.net/tag/design-patterns/
    ///
    /// </summary>

    public class Client
    {
        private static void Main(string[] args)
        {
            Builder bx = new Builder();
            Person p = bx.AddColour("Green")
                        .AddName("nick")
                        .AddMood("happy");

            Console.WriteLine($"it is {p.Name}, {p.Colour} and {p.Mood}");

            Console.ReadLine();
        }
    }

    public class Person //can be inside Builder therefore u would delete the private fields in builder!
    {
        public Person(string name, string colour, string mood)
        {
            Name = name;
            Colour = colour;
            Mood = mood;
        }

        public string Name { get; set; }
        public string Colour { get; set; }
        public string Mood { get; set; }
    }

    public class Builder
    {
        private string _name;
        private string _colour;
        private string _mood;

        public Builder AddName(string name)
        {
            _name = name;
            return this;
        }

        public Builder AddColour(string colour)
        {
            _colour = colour;
            return this;
        }

        public Builder AddMood(string mood)
        {
            _mood = mood;
            return this;
        }

        // public static implicit operator is a CONVERSION OPERATOR - This allows you to create new teams in a more natural (fluent) way without casting
        //without this, and/or by just doing

        //public Person Build()
        //{
        //    return new Person(_name, _colour, _mood);
        //}

        //the caller will have to call build() at the end of the chain and you may get a casting error at the client

        public static implicit operator Person(Builder b)
        {
            return new Person(b._name, b._colour, b._mood);
        }
    }
}