using UnityEngine;

public class lightMananger : MonoBehaviour
{
   public GameObject[] lights;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");
        turnLightsOff();
    }

   public void turnLightsOff()
    {
        foreach (var light in lights)
        {
            light.GetComponent<Light>().enabled = false;
        }
    }

   public void turnLightsOn()
    {
        foreach (var light in lights)
        {
            light.GetComponent<Light>().enabled = true;
        }
    }
}
