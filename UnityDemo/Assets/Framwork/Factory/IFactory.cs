using System.Collections;
using System.Collections.Generic;
public interface IFactory
{
    void Rigister(int p_Key, System.Type p_Type);
    object Create(int p_Key);
}
public interface IFactory<T> :IFactory {
    new T Create(int p_Key);
}
