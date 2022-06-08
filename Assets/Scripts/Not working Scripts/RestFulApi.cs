using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;



//TFG by Gerard Opazo Porcar
public class RestFulApi : MonoBehaviour
{
    //public GameObject data;
    //public GameObject dataText3D; 
    //public Text
    public DeserializeJsonResp jsonDeserialized;
    public string id;
    public string pedestrian;
    public string bike;
    public string car;
    public string lorry;
    string m_Path;
    //public GameObject path;
    //public GameObject data;

    //[ContextMenu("Test APIGet")]
    public async void ApiGetJson()
    {


            var url = "https://telraam-api.net/v1/segments/active_minimal";

            var httpResponse = new HttpResponse(new JsonSerialzeOpt());
            jsonDeserialized = await httpResponse.Get<DeserializeJsonResp>(url);    //gets json deserialized
                                                                                    //Call parser
            foreach (var i in jsonDeserialized.features)
            {
                var temp = i.properties.id.ToString();
                if (temp.Equals("166098")) // 9000001301 = Calle Roger de Flor, Barcelona, Spain, calle concurrida:166098, 9000000197, 9000001214,421535, 351311, 279386
                {
                    Debug.Log("id: " + i.properties.id.ToString());
                    Debug.Log("pedestrian: " + i.properties.pedestrian_avg.ToString());
                    Debug.Log("bike: " + i.properties.bike_avg.ToString());
                    Debug.Log("Car" + i.properties.car_avg.ToString());
                    Debug.Log("Lorry: " + i.properties.lorry_avg.ToString());
                    id = i.properties.id.ToString();
                    pedestrian = i.properties.pedestrian_avg.ToString();
                    bike = i.properties.bike_avg.ToString();
                    car = i.properties.car_avg.ToString();
                    lorry = i.properties.lorry_avg.ToString();
                    GetComponent<TextMesh>().text = "HOLA MUNDO ID: " + id;
                    //myclass.id = i.properties.id.ToString();
                    //myclass.pedestrian_avg = i.properties.pedestrian_avg;
                    //myclass.bike_avg = i.properties.bike_avg;
                    //myclass.car_avg = i.properties.car_avg;
                    //myclass.lorry_avg = i.properties.lorry_avg;
                    //GetComponent<TextMesh>().text = "HOLA MUNDO"; //"id: " + i.properties.id.ToString() + "\npedestrian: " + i.properties.pedestrian_avg.ToString()
                    //+ "\nbike: " + i.properties.bike_avg.ToString() + "\ncar: " + i.properties.car_avg.ToString() + "\nlorry: " + i.properties.lorry_avg.ToString();
                    //Instantiate(data, transform.position, transform.rotation);
                    //data.text = "id: " + i.properties.id.ToString() + "\npedestrian: " + i.properties.pedestrian_avg.ToString()
                    //    + "\nbike: " + i.properties.bike_avg.ToString() + "\ncar: " + i.properties.car_avg.ToString() + "\nlorry: " + i.properties.lorry_avg.ToString();

            }

                //else
                //    Debug.Log("Not Found");
            }
    }


    // Start is called before the first frame update
    void Start()
    {
        ApiGetJson();
        
        /*var temp1 = id;
        var temp2 = pedestrian;
        var temp3 = bike;
        var temp4 = car;
        var temp5 = lorry;*/

        //Get the path of the Game data folder
        //m_Path = Application.dataPath;
        //GetComponent<TextMesh>().text = "HOLA MUNDO ID: " + m_Path;
        //TextMesh textComponent = path.GetComponent<TextMesh>();
        //textComponent.text = m_Path;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (id.Equals("166098"))
        {
            GetComponent<TextMesh>().text = "HOLA MUNDO ID: " + id;
        }*/
        Debug.Log(id);

    }
}




    /*var url = "https://telraam-api.net/v1/segments/active_minimal";
var ApiKey = "mvnWKjkhtO4XXbjeyPQsE9Z8Coa40dAD4lo8P7h6";
using (var www = UnityWebRequest.Get(url))
    {
    www.SetRequestHeader("X-Api-Key", ApiKey);
    www.SetRequestHeader("Accept", "application/json");
    www.SetRequestHeader("Content-Type", "application/json ");
    var operation = www.SendWebRequest();
    Debug.Log(ApiKey);

    while (!operation.isDone)
    {
        await Task.Yield();
    }
    var jsonResp = www.downloadHandler.text;
    if (www.result != UnityWebRequest.Result.Success)
        Debug.Log($"Failed:{www.error}");
    try
    {
        Debug.Log($"Okey:{www.downloadHandler.text}");
    }
    catch(Exception exception)
    {
        Debug.LogError($"Could not parse the response of the json {jsonResp}.{exception.Message}");
    }


    //JSONNode jsonobject = JSON.Parse(www.downloadHandler.text);

    //string info = jsonobject["sanitized"];

    //print("The data extracted is: " + info);


    //https://docs.microsoft.com/es-es/dotnet/csharp/whats-new/csharp-8
     */
