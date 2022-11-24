using System;
using System.Collections.Generic;
namespace Packt.Shared
{
    public class ThingOfDefaults
    {
        public int Population;
        public DateTime When;
        public string Name;
        public List<Person> People;

        public ThingOfDefaults()
        {
            Population = default; // C# 7.1 и более поздние версии
            When = default;
            Name = default;
            People = default;
        }
    }
}