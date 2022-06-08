using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class RequestExample : MonoBehaviour
{
    public List<string> dates;
    public string unique_day;
    public string id;
    public List<int> pedestrian;
    public List<int> bike;
    public List<int> car;
    public List<int> lorry;

    public int total_pedestrians = 0;
    public int total_bikes = 0;
    public int total_cars = 0;
    public int total_lorries = 0;
    public int total_objects = 0;

    public double percentage_pedestrians = 0.00;
    public double percentage_bikes = 0.00;
    public double percentage_cars = 0.00;
    public double percentage_lorries = 0.00;
    DateTime today = DateTime.UtcNow;
    public GraphViewer graficas;
    void Start()
    {

    }
    public void Start_RestfulCall(string readed_id)
    {
        var tomorrow = today;
        tomorrow = tomorrow.AddDays(1);
        id = readed_id;
        string data =
            "{level: segments, format: per-hour, id: " + id + ", time_start: " + today.Date.ToString("yyyy-MM-dd HH:mm:ss") + "Z, time_end: " + tomorrow.Date.ToString("yyyy-MM-dd HH:mm:ss") + "Z}";
        StartCoroutine(AsyncRequest("https://telraam-api.net/v1/reports/traffic", "mvnWKjkhtO4XXbjeyPQsE9Z8Coa40dAD4lo8P7h6", data)); //this.
    }

    private void Update()
    {
        graficas.UpdateGraph(id, total_pedestrians, total_bikes, total_cars, total_lorries);
    }


    private IEnumerator AsyncRequest(string url, string ApiKey, string json)//Action<DeserializeJsonResp> callback)
    {

        using (var www = UnityWebRequest.Put(url, json))
        {
            www.method = "POST";
            www.SetRequestHeader("X-Api-Key", ApiKey);
            www.SetRequestHeader("Accept", "application/json");
            www.SetRequestHeader("Content-Type", "application/json ");
            yield return www.SendWebRequest();
            
            Debug.Log(ApiKey);

            var jsonResp = www.downloadHandler.text;
            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log($"Failed:{www.error}");
            try
            {
                Debug.Log($"Okey:{www.downloadHandler.text}");
            }
            catch (Exception exception)
            {
                Debug.LogError($"Could not parse the response of the json {jsonResp}.{exception.Message}");
            }
            var res = JsonConvert.DeserializeObject<NewDeserializeJsonResp>(www.downloadHandler.text);
            Debug.Log(res.status_code);
            if (res.status_code == 200)
            {
                foreach (var i in res.report)
                {
                    var temp = i.segment_id.ToString();
                    if (temp.Equals("9000001301"))
                    {

                        unique_day = i.date.ToString("dd/MM/yyyy");
                        dates.Add(i.date.TimeOfDay.ToString());
                        id = i.segment_id.ToString();
                        pedestrian.Add((int)Math.Round(Convert.ToDecimal(i.pedestrian.ToString()), MidpointRounding.AwayFromZero));//i.pedestrian.ToString();
                        bike.Add((int)Math.Round(Convert.ToDecimal(i.bike.ToString()), MidpointRounding.AwayFromZero));
                        car.Add((int)Math.Round(Convert.ToDecimal(i.car.ToString()), MidpointRounding.AwayFromZero));
                        lorry.Add((int)Math.Round(Convert.ToDecimal(i.heavy.ToString()), MidpointRounding.AwayFromZero));

                        total_pedestrians = (int)Math.Round(Convert.ToDecimal(i.pedestrian.ToString()), MidpointRounding.AwayFromZero) + total_pedestrians;
                        total_bikes = (int)Math.Round(Convert.ToDecimal(i.bike.ToString()), MidpointRounding.AwayFromZero) + total_bikes;
                        total_cars = (int)Math.Round(Convert.ToDecimal(i.car.ToString()), MidpointRounding.AwayFromZero) + total_cars;
                        total_lorries = (int)Math.Round(Convert.ToDecimal(i.heavy.ToString()), MidpointRounding.AwayFromZero) + total_lorries;

                        total_objects = total_pedestrians + total_bikes + total_cars + total_lorries;

                        //GetComponent<TextMesh>().text = "The id is: " + id;
                        Debug.Log("id: " + id);
                        Debug.Log("pedestrian: " + total_pedestrians);
                        Debug.Log("bike: " + total_bikes);
                        Debug.Log("Car: " + total_cars);
                        Debug.Log("Lorry: " + total_lorries);
                        //GetComponent<TextMesh>().text = "id: " + id + "\npedestrian: " + total_pedestrians
                        //    + "\nbike: " + total_bikes + "\ncar: " + total_cars + "\nlorry: " + total_lorries;

                    }
                }
                percentage_pedestrians = (double)total_pedestrians / total_objects;
                percentage_bikes = (double)total_bikes / total_objects;
                percentage_cars = (double)total_cars / total_objects;
                percentage_lorries = (double)total_lorries / total_objects;
            }
            else
            {
                id = "Error: please, put a valid ID";
            }
        }          
    }

}