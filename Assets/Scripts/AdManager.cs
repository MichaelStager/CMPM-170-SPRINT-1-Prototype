using System;
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
        StartAdTimer();
    }

    public void StartAdTimer()
    {
        StartCoroutine("DelayedPopupCoroutine");
    }

    public IEnumerator DelayedPopupCoroutine()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(secondDelayMinimum, secondDelayMaximum));

        adWindows.Add(CreatePopup());
    }

    private GameObject CreatePopup()
    {
        float screenHalfWidth = Screen.width * 0.5f;
        float screenHalfHeight = Screen.height * 0.5f;

        // Clone prefab to instantiate new popup-ad object
        GameObject newAdLayer = Instantiate(adPrefab, Vector3.zero, Quaternion.identity);
        newAdLayer.transform.SetParent(canvas.transform);

        // Pick random ad sprite and set it on the popup
        Transform adImage = newAdLayer.transform.GetChild(0);
        Sprite adSprite = GetRandomSprite();
        adImage.GetComponent<Image>().sprite = adSprite;

        // Get dimensions from texture and set it for the ad window
        RectTransform adImageRect = adImage.GetComponent<RectTransform>();
        Texture2D adTexture = adSprite.texture;
        adImageRect.sizeDelta = new Vector2(adTexture.width, adTexture.height);

        // Set random position for the ad popup
        float spriteHalfWidth = adTexture.width * 0.5f;
        float spriteHalfHeight = adTexture.height * 0.5f;
        float deltaWidth = Math.Max(0, screenHalfWidth - spriteHalfWidth);
        float deltaHeight = Math.Max(0, screenHalfHeight - spriteHalfHeight);
        float randomX = screenHalfWidth + UnityEngine.Random.Range(-deltaWidth, deltaWidth);
        float randomY = screenHalfHeight + UnityEngine.Random.Range(-deltaHeight, deltaHeight);
        //Debug.Log($"screenHalfWidth: {screenHalfWidth}, screenHalfHeight: {screenHalfHeight}, spriteHalfHeight: {spriteHalfHeight}, spriteHalfHeight: {spriteHalfHeight}");
        //Debug.Log($"deltaWidth: {deltaWidth}, deltaHeight: {deltaHeight}, randomX: {randomX}, randomY: {randomY}");
        newAdLayer.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(randomX, randomY, 0), Quaternion.identity);

        // Bind listener to button for closing window 
        Button adCloseButton = adImage.GetChild(0).GetComponent<Button>();
        adCloseButton.onClick.AddListener(() => SilenceBrand(newAdLayer));

        return newAdLayer;
    }

    private void SilenceBrand(GameObject adLayerObject)
    {
        Destroy(adLayerObject);
        StartAdTimer();
    }

    private Sprite GetRandomSprite()
    {
        return adSprites[UnityEngine.Random.Range(0, adSprites.Count)];
    }

}
