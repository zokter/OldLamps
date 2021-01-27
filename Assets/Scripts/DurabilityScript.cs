using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DurabilityScript : MonoBehaviour
{
    public GameObject[] lamp;

    private string path = "input.txt";
    // Start is called before the first frame update
    void Start()
    {
        string inputsStr = File.ReadAllText(path);
        string[] inputs = inputsStr.Split(' ');
        for (int i = 0; i < lamp.Length; i++)
        {
            lamp[i].GetComponent<LightLogic>().maxIntensity = int.Parse(inputs[i]);
        }
    }
}

