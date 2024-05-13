// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using single_list_json_demo;

Console.WriteLine("Hello, World!");

string jsonText = File.ReadAllText("sample.json");

var options = new JsonSerializerOptions();

options.Converters.Add(new JsonConverterFactoryForSingleListOfT());

var obj = JsonSerializer.Deserialize<TxcResponse>(jsonText, options);

var result = JsonSerializer.Serialize(obj, options);

Console.WriteLine(result);
