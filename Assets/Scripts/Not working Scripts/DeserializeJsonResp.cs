using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TFG by Gerard Opazo Porcar
public class DeserializeJsonResp 
{

        //RootElement myDeserializedClass = JsonConvert.DeserializeObject<RootElement>(jsonResp);
        public int status_code { get; set; }
        public string message { get; set; }
        public string type { get; set; }
        public List<Features> features { get; set; }


    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class TypicalData
    {
        public string hour { get; set; }
        public double pedestrian { get; set; }
        public double bike { get; set; }
        public double car { get; set; }
        public double lorry { get; set; }
    }

    public class Properties
    {
        public object id { get; set; }
        public double pedestrian { get; set; }
        public double bike { get; set; }
        public double car { get; set; }
        public double lorry { get; set; }
        public object last_data_package { get; set; }
        public int pedestrian_avg { get; set; }
        public int bike_avg { get; set; }
        public int car_avg { get; set; }
        public int lorry_avg { get; set; }
        public List<TypicalData> typical_data { get; set; }
    }

    public class Features
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

}
