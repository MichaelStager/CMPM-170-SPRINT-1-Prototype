using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    [SerializeField] int secondDelayMinimum;
    [SerializeField] int secondDelayMaximum;

    // Prefab to instantiate and create new ad windows from
    [SerializeField] GameObject adPrefab;
    [SerializeField] List<Sprite> adSprites;

    // Lifetime fields
    [SerializeField] GameObject canvas; // The parent object to add new ad popups to
    private List<GameObject> adWindows; // Runtime storage for active ad windows


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        startAdTimer();
        adWindows = new List<GameObject>();
    }

    public void startAdTimer()
    {
        UnityEngine.Debug.Log("AdManager.spawnAd");

        // TODO begin ad loop, that generates ads every 10 to 30 seconds (configurable)
        StartCoroutine("spawnAdCoroutine");
    }

    public IEnumerator spawnAdCoroutine()
    {
        UnityEngine.Debug.Log("AdManager.spawnAdCoroutine");

        yield return new WaitForSeconds(UnityEngine.Random.Range(secondDelayMinimum, secondDelayMaximum));

        GameObject newPopup = Instantiate(adPrefab, new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity);

        newPopup.transform.SetParent(canvas.transform);
        adWindows.Add(newPopup);
    }
}
