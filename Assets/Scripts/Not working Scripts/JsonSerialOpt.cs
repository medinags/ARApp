using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//TFG by Gerard Opazo Porcar
public class JsonSerialzeOpt : ISerialize
{
    public string appJson => "application/json";    
    public string apiKey => "mvnWKjkhtO4XXbjeyPQsE9Z8Coa40dAD4lo8P7h6";
    public T Deserialize <T> (string varchar)  // we are using varchar will be equal to jsonResp and www.downloadHandler.text 
    {
        try
        {
            File.WriteAllText( "request.json" , varchar);
            var res = JsonConvert.DeserializeObject<T>(varchar);   //jsonResp
            Debug.Log($"Retrieved Okey: {varchar}");      //www.downloadHandler.text 
            return res;

        }
        catch(Exception exception)
        {
            Debug.LogError($"[{this}]No se ha podido parsear la json response{varchar}.{exception.Message}");   //jsonResp
            return default;
        }
    }


}
