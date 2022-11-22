using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int StartingLives;
    public Transform spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.lives = StartingLives;
        GameManager.instance.currentLevel = this;
        GameManager.instance.SpawnPlayer(spawnPoint);
    }

    public void UpdateCheckpoint(Transform spawnPoint)
    {
        GameManager.instance.currentSpawnPoint = spawnPoint;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
