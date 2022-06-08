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




public class NewRestFulApi : MonoBehaviour
{

    public NewDeserializeJsonResp jsonDeserialized;
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

    public async void ApiGetJson()
    {

        var url = "https://telraam-api.net/v1/reports/traffic";
        var tomorrow = today;
        tomorrow = tomorrow.AddDays(1);
        string data =
            "{level: segments, format: per-hour, id: 9000001301, time_start: " + today.Date.ToString("yyyy-MM-dd HH:mm:ss") + "Z, time_end: "+ tomorrow.Date.ToString("yyyy-MM-dd HH:mm:ss") +"Z}";
        var httpResponse = new NewHttpResponse(new JsonSerialzeOpt());
        jsonDeserialized = await httpResponse.Post<NewDeserializeJsonResp>(url, data);    //gets json deserialized
                                                                                //Call parser
        foreach (var i in jsonDeserialized.report)
        {
            var temp = i.segment_id.ToString();
            var temp_date = i.date.Day;
            Debug.Log("Date extracted: " + temp_date.ToString());
            Debug.Log( "Date now: " + today.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            Debug.Log("Date now: " + tomorrow.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            if (temp.Equals("9000001301")) // 9000001301 = Calle Roger de Flor, Barcelona, Spain, calle concurrida:166098, 9000000197, 9000001214,421535, 351311, 279386
            {
                Debug.Log("id: " + i.segment_id.ToString());
                Debug.Log("pedestrian: " + i.pedestrian.ToString());
                Debug.Log("bike: " + i.bike.ToString());
                Debug.Log("Car: " + i.car.ToString());
                Debug.Log("Lorry: " + i.heavy.ToString());
                Debug.Log("Date: " + i.date.ToString());
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
                
                //car = Math.Round(Convert.ToDecimal(i.car.ToString()), MidpointRounding.AwayFromZero).ToString();
                //lorry = Math.Round(Convert.ToDecimal(i.heavy.ToString()), MidpointRounding.AwayFromZero).ToString();
                //GetComponent<TextMesh>().text = "HOLA MUNDO ID: " + id;
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

        
            percentage_pedestrians = (double)total_pedestrians / total_objects;
            percentage_bikes = (double)total_bikes  / total_objects;
            percentage_cars = (double)total_cars / total_objects;
            percentage_lorries = (double)total_lorries  / total_objects;
            //GetComponent<TextMesh>().text = "id: " + id + "\npedestrians: " + total_pedestrians
            //           + "\nbikes: " + total_bikes + "\ncars: " + total_cars + "\nlorries: " + total_lorries;

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
        graficas.UpdateGraph(id, total_pedestrians, total_bikes, total_cars, total_lorries);
        //Debug.Log(id);

    }
}





