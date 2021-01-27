using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLogic : MonoBehaviour
{
    public Light lamp;
    public int maxIntensity = 0;
    private bool enb = false;
    public bool Enabled => enb;

    // Start is called before the first frame update
    void Start()
    {
        lamp = GetComponent<Light>();
    }

    public void ignite()
    {
        if(maxIntensity > 0)
        {
            lamp.intensity = maxIntensity;
            enb = true;
        }
    }

    public void extinguish()
    {
        if (enb)
        {
            enb = false;
            lamp.intensity = 0;
            maxIntensity -= 1;
        }
    }
}
