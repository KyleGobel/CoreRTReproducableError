using System;
using YamlDotNet.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting process");
            var yamlText = System.IO.File.ReadAllText("TestFile.yaml");
            Console.WriteLine($"Read text:  {yamlText}");
            var result = DeserializeModel(yamlText);
            Console.WriteLine("Got the result");
        }

        static SimpleModel DeserializeModel(string yaml)
        {
            var deserializer = new DeserializerBuilder()
                .IgnoreUnmatchedProperties()
                .Build();

            return deserializer.Deserialize<SimpleModel>(yaml);
        }
    }

    public class SimpleModel
    {
        public SimpleModel()
        {
        }

        [YamlMember(Alias = "kind", ApplyNamingConventions = false)]
        public string Kind { get; set; }

        [YamlMember(Alias = "apiVersion", ApplyNamingConventions = false)]
        public string ApiVersion { get; set; }

        [YamlMember(Alias = "currentContext", ApplyNamingConventions = false)]
        public string CurrentContext { get; set; }
    }
}