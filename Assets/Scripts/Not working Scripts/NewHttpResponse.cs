using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;


public class NewHttpResponse
{
    private readonly ISerialize _serialize; //readonly es inmutable evita que se reemplace por una instancia diferente al tipo de referencia.

    public NewHttpResponse(ISerialize serialize)
    {
        _serialize = serialize;
    }

    public async Task<T> Post<T>(string url, string json) //We use generics instead of the RestFulApi
    {
        try
        {
            Debug.Log(json);
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            Debug.Log(jsonToSend);
            using (var www = UnityWebRequest.Put(url, json))
            {
                www.method = "POST";
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
                Debug.Log(jsonResp);
                if (www.result != UnityWebRequest.Result.Success)
                    Debug.Log($"Failed:{www.error}");



                var res = _serialize.Deserialize<T>(www.downloadHandler.text);

                return res;
            }
        }
        catch (Exception exception)
        {
            Debug.LogError($"{nameof(Post)} failed: {exception.Message}");
            return default;
        }
    }
}