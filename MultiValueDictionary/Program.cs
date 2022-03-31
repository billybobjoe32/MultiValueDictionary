// See https://aka.ms/new-console-template for more information
using MultiValueDictionaryApp;

MultiValueDictionary mvd = new MultiValueDictionary();
Console.WriteLine("Hello, World!");
string? input = Console.ReadLine();
while(input == null || !input.ToLower().StartsWith("quit"))
{
    string output = mvd.ProcessRequest(input);
    Console.WriteLine(output);
    Console.Write("> ");
    Console.ReadLine();
}