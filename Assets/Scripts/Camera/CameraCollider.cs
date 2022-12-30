using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;

    private void Awake()
    {
        if (!TryGetComponent(out edgeCollider))
            Debug.Log("Edge Collider could not be found");
        if (Camera.main == null)
            Debug.Log("Main Camera could not be found");
    }

    private void Start()
    {
        Camera camera = Camera.main;

        Vector2[] edgesList =
        {
            camera.ScreenToWorldPoint(new Vector2(0,0)),
            camera.ScreenToWorldPoint(new Vector2(0,camera.pixelHeight)),
            camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth,camera.pixelHeight)),
            camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth,0)),
            camera.ScreenToWorldPoint(new Vector2(0,0))
        };
        edgeCollider.points = edgesList;
    }
}
