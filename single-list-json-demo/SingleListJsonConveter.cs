using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace single_list_json_demo;
public class JsonConverterFactoryForSingleListOfT : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert.IsGenericType
        && typeToConvert.GetGenericTypeDefinition() == typeof(SingleList<>);

    public override JsonConverter CreateConverter(
        Type typeToConvert, JsonSerializerOptions options)
    {
        Type elementType = typeToConvert.GetGenericArguments()[0];

        JsonConverter converter = (JsonConverter)Activator.CreateInstance(
            typeof(SingleListJsonConveter<>)
                .MakeGenericType(new Type[] { elementType }),
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: null,
            culture: null)!;

        return converter;
    }
}
public class SingleListJsonConveter<T> : JsonConverter<SingleList<T>>
{
    private readonly JsonConverter<T> _valueConverter;
    private readonly Type _valueType;

    public SingleListJsonConveter(JsonSerializerOptions options)
    {
        _valueConverter = (JsonConverter<T>)options.GetConverter(typeof(T));
        _valueType = typeof(T);
    }

    public override SingleList<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new FormatException();
        }

        var dictionary = new SingleList<T>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return dictionary;
            }

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new FormatException();
            }

            reader.Read();
            if (reader.GetString() != "key")
            {
                throw new FormatException();
            }

            reader.Read();

            T value = _valueConverter.Read(ref reader, _valueType, options)!;

            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new FormatException();
            }

            dictionary.Add(value);
        }

        throw new FormatException();
    }

    public override void Write(Utf8JsonWriter writer, SingleList<T> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        value.Validate();

        foreach (var item in value)
        {
            writer.WriteStartObject();
            _valueConverter.Write(writer, item, options);
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
    }
}

