using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    public float minXClamp;
    public float maxXClamp;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPosition;

        cameraPosition = transform.position;
        cameraPosition.x = Mathf.Clamp(player.transform.position.x, minXClamp, maxXClamp);

        transform.position = cameraPosition;
    }
}
