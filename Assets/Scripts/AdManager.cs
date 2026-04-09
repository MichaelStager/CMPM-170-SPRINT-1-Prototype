using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    [SerializeField] int secondDelayMinimum;
    [SerializeField] int secondDelayMaximum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        UnityEngine.Debug.Log("AdManager.Start");

        // TODO begin ad loop, that generates ads every 10 to 30 seconds (configurable)
        StartCoroutine("spawnAdCoroutine");
    }

    public void spawnAd()
    {
        UnityEngine.Debug.Log("AdManager.spawnAd");

        // TODO begin ad loop, that generates ads every 10 to 30 seconds (configurable)
        StartCoroutine("spawnAdCoroutine");
    }

    public IEnumerator spawnAdCoroutine()
    {
        UnityEngine.Debug.Log("AdManager.spawnAdCoroutine");

        yield return new WaitForSeconds(UnityEngine.Random.Range(secondDelayMinimum, secondDelayMaximum));
    }
}
