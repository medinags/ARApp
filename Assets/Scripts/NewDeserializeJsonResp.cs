using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TFG by Gerard Opazo Porcar

public class NewDeserializeJsonResp
{

    //RootElement myDeserializedClass = JsonConvert.DeserializeObject<RootElement>(jsonResp);
    public int status_code { get; set; }
    public string message { get; set; }
    public List<Report> report { get; set; }


    public class Report
    {
        public int instance_id { get; set; }
        public object segment_id { get; set; }
        public DateTime date { get; set; }
        public string interval { get; set; }
        public double uptime { get; set; }
        public double heavy { get; set; }
        public double car { get; set; }
        public double bike { get; set; }
        public double pedestrian { get; set; }
        public double heavy_lft { get; set; }
        public double heavy_rgt { get; set; }
        public double car_lft { get; set; }
        public double car_rgt { get; set; }
        public double bike_lft { get; set; }
        public double bike_rgt { get; set; }
        public double pedestrian_lft { get; set; }
        public double pedestrian_rgt { get; set; }
        public int direction { get; set; }
        public List<double> car_speed_hist_0to70plus { get; set; }
        public List<double> car_speed_hist_0to120plus { get; set; }
        public string timezone { get; set; }
        public double v85 { get; set; }
    }
}
