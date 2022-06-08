using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

//TFG by Gerard Opazo Porcar
public class HttpResponse 
{
    private readonly ISerialize _serialize; //readonly es inmutable evita que se reemplace por una instancia diferente al tipo de referencia.

    public HttpResponse(ISerialize serialize)
    {
        _serialize = serialize;
    }

    public async Task<T> Get<T>(string url) //We use generics instead of the RestFulApi
    {
        try
        {
            using (var www = UnityWebRequest.Get(url))
            {
                www.SetRequestHeader("X-Api-Key", _serialize.apiKey); // I will pass the api from the interface ISerializated
                www.SetRequestHeader("Accept", _serialize.appJson);
                www.SetRequestHeader("Content-Type", _serialize.appJson);
                var sendReq = www.SendWebRequest();
                Debug.Log(_serialize.apiKey);

                while (!sendReq.isDone)
                {
                    await Task.Yield();
                }
                var jsonResp = www.downloadHandler.text;
                if (www.result != UnityWebRequest.Result.Success)
                    Debug.Log($"Failed:{www.error}");



                var res = _serialize.Deserialize<T>(www.downloadHandler.text);

                return res;
            }
        }
        catch (Exception exception)
        {
            Debug.LogError($"{nameof(Get)} failed: {exception.Message}");
            return default;
        }
    }
}