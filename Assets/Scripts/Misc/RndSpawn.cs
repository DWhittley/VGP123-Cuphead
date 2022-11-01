using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RndSpawn : MonoBehaviour
{
    public GameObject prefab1, prefab2, prefab3, prefab4, prefab5;
    int spawnWhat;

    // Start is called before the first frame update
    void Start()
    {
        spawnWhat = Random.Range (1,6);

        switch (spawnWhat)
        {
            case 1:
                Instantiate (prefab1, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate (prefab2, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate (prefab3, transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate (prefab4, transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate (prefab5, transform.position, Quaternion.identity);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
