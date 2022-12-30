using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int numberOfBoids = 100;
    [SerializeField] private GameObject boidToInstantiate;

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

        InstantiateBoids(numberOfBoids);
    }

    private void InstantiateBoids(int nbBoids)
    {
        for(int i = 0; i<nbBoids; i++)
        {
            float xPos = Random.Range(leftBound, rightBound);
            float yPos = Random.Range(lowerBound, upperBound);
            float rotation = Random.Range(0, 360);

            Instantiate(boidToInstantiate, new Vector2(xPos, yPos), Quaternion.Euler(0, 0, rotation));
        }
    }
}
