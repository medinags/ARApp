using System.Diagnostics;
using System.Reflection.Emit;
using System.Globalization;
using System.ComponentModel;
using System.CodeDom.Compiler;
using System;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphViewer : MonoBehaviour
{
    [System.Serializable]
    public struct DataObj
    {
        public Slider slider;
        public TextMeshProUGUI valor;
    };

    public TextMeshProUGUI idText;
    public DataObj pedestrian;
    public DataObj bike;
    public DataObj car;
    public DataObj lorry;

    int maxValue;
    int minValue;

    public void UpdateGraph(string id, int pedN, int bikeN, int carN, int lorryN)
    {
        maxValue = 0;
        minValue = 100000;
        maxValue = Math.Max(maxValue, pedN);
        maxValue = Math.Max(maxValue, bikeN);
        maxValue = Math.Max(maxValue, carN);
        maxValue = Math.Max(maxValue, lorryN);
        minValue = Math.Min(minValue, pedN);
        minValue = Math.Min(minValue, bikeN);
        minValue = Math.Min(minValue, carN);
        minValue = Math.Min(minValue, lorryN);

        idText.text = "ID: " + id;

        pedestrian.slider.minValue = minValue;
        pedestrian.slider.maxValue = maxValue;
        bike.slider.minValue = minValue;
        bike.slider.maxValue = maxValue;
        car.slider.minValue = minValue;
        car.slider.maxValue = maxValue;
        lorry.slider.minValue = minValue;
        lorry.slider.maxValue = maxValue;

        pedestrian.slider.value = pedN;
        bike.slider.value = bikeN;
        car.slider.value = carN;
        lorry.slider.value = lorryN;

        pedestrian.valor.text = pedN.ToString();
        bike.valor.text = bikeN.ToString();
        car.valor.text = carN.ToString();
        lorry.valor.text = lorryN.ToString();
    }
}
