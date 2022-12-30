using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInCameraBounds : MonoBehaviour
{

    private float upperBound;
    private float lowerBound;
    private float leftBound;
    private float rightBound; 

    private void Awake()
    {
        if (Camera.main == null)
            Debug.Log("Main Camera could not be found");
    }
    private void Start()
    {
        Camera camera = Camera.main;

        Vector2 lowerLeft = camera.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 upperRight = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth, camera.pixelHeight));

        lowerBound = lowerLeft.y;
        upperBound = upperRight.y;
        leftBound = lowerLeft.x;
        rightBound = upperRight.x;
    }

    private void Update()
    {
        KeepTransformInCameraBounds();
    }

    private void KeepTransformInCameraBounds()
    {
        float currX = transform.position.x;
        float currY = transform.position.y;

        float localLeft = currX - transform.localScale.x / 2;
        float localRight = currX + transform.localScale.x / 2;
        float localTop = currY - transform.localScale.y / 2;
        float localBottom = currY + transform.localScale.y / 2;

        if(localLeft < leftBound)
            currX = leftBound + transform.localScale.x / 2;
        else if (localRight > rightBound)
            currX = rightBound - transform.localScale.x / 2;

        if(localTop < lowerBound)
            currY = lowerBound + transform.localScale.y / 2; 
        else if(localBottom > upperBound)
            currY = upperBound - transform.localScale.y / 2;

        transform.position = new Vector2(currX, currY);
    }
}
