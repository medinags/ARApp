using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TFG by Gerard Opazo Porcar
public interface ISerialize
{   
    string appJson { get; }
    string apiKey { get; }
    T Deserialize<T>(string text);
}
