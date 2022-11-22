using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float minXClamp;
    public float maxXClamp;


    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.instance.playerInstance)
        {
            Vector3 cameraPosition;

            cameraPosition = transform.position;
            cameraPosition.x = Mathf.Clamp(GameManager.instance.playerInstance.transform.position.x, minXClamp, maxXClamp);

            transform.position = cameraPosition;
        }
       
    }
}
