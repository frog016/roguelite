using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class ObjectCopier
{
    public static T Clone<T>(object source)
    {
        if (!typeof(T).IsSerializable)
        {
            throw new ArgumentException("The type must be serializable.", "source");
        }

        if (ReferenceEquals(source, null))
        {
            return default;
        }

        var formatter = new BinaryFormatter();
        var stream = new MemoryStream();
        using (stream)
        {
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(stream);
        }
    }
}
