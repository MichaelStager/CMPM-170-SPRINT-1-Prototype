using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    [SerializeField] int secondDelayMinimum;
    [SerializeField] int secondDelayMaximum;

    // Prefab to instantiate and create new ad windows from
    [SerializeField] GameObject adPrefab;
    [SerializeField] List<Sprite> adSprites;

    // Lifetime fields
    [SerializeField] GameObject canvas; // The parent object to add new ad popups to
    private readonly List<GameObject> adWindows; // Runtime storage for active ad windows

    public AdManager()
    {
        adWindows = new List<GameObject>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        startAdTimer();
    }

    public void startAdTimer()
    {
        Debug.Log("AdManager.spawnAd");

        // TODO begin ad loop, that generates ads every 10 to 30 seconds (configurable)
        StartCoroutine("spawnAdCoroutine");
    }

    public IEnumerator spawnAdCoroutine()
    {
        Debug.Log("AdManager.spawnAdCoroutine");

        yield return new WaitForSeconds(Random.Range(secondDelayMinimum, secondDelayMaximum));

        adWindows.Add(createPopup());
    }

    private GameObject createPopup()
    {
        GameObject newAdLayer = Instantiate(adPrefab, new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity);
        newAdLayer.transform.SetParent(canvas.transform);

        Button adCloseButton = newAdLayer.transform.GetChild(0).GetChild(0).GetComponent<Button>();
        adCloseButton.onClick.AddListener(() => silenceBrand(newAdLayer));

        return newAdLayer;
    }

    private void silenceBrand(GameObject adLayerObject)
    {
        Destroy(adLayerObject);
        startAdTimer();
    }

}
