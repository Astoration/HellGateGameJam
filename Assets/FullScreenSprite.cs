using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FullScreenSprite : MonoBehaviour
{
    private void Reset()
    {
        FitToScreen();
    }

    // Use this for initialization
    void Start()
    {
        FitToScreen();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FitToScreen()
    {
        var camera = Camera.main;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;
        float spriteWidth = spriteRenderer.sprite.bounds.size.x;
        float distance = transform.position.z - camera.transform.position.z;
        float screenHeight = 2 * Mathf.Tan(camera.fieldOfView * Mathf.Deg2Rad / 2) * distance;
        float screenWidth = screenHeight * camera.aspect;
        var widthRatio = (screenWidth / spriteWidth);
        var heightRaito = screenHeight / spriteHeight;
        var ratio = widthRatio<heightRaito ? heightRaito : widthRatio;
        transform.localScale = new Vector3(ratio,ratio, 1f);
    }
}