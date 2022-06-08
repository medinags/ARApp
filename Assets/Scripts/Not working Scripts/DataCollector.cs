using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollector:MonoBehaviour
{
    public string id { get; set; }      //no deberias tener el static ya que no seran propiedades de instancia sino que seran de clase
    public  int pedestrian_avg { get; set; }
    public int bike_avg { get; set; }
    public int car_avg { get; set; }
    public int lorry_avg { get; set; }



    // A constructor with no parameters
    //public DataCollector()
    //{}
    //A constructor to set json
    /*public async Task<T>
    {
        //List <DeserializeJsonResp> features = new DeserializeJsonResp();
        DeserializeJsonResp propierties = new DeserializeJsonResp();
        
    }*/
}
