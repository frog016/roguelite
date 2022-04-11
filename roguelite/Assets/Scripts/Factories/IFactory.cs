using System;

public interface IFactory<T>
{
    T CreateObject(Type objectType);
}
