using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;


    public static GameManager instance
    {
        get => _instance;
        set 
        { 
            _instance = value; 
        }
    }

    public int maxLives = 3;
    private int _lives = 3;

    public PlayerController playerPrefab;
    [HideInInspector] public PlayerController playerInstance = null;
    [HideInInspector] public Level currentLevel = null;
    [HideInInspector] public Transform currentSpawnPoint;

    public int lives
    { 
        get { return _lives; }
        set
        {
            if (_lives > value)
                Respawn();
             
            _lives = value;

            if (_lives > maxLives)
                _lives = maxLives;

            if (_lives < 0)
                Gameover();

            onLifeValueChanged?.Invoke(_lives);
            Debug.Log("Lives have been set to: " + _lives.ToString());
        }
    }

    [HideInInspector] public UnityEvent<int> onLifeValueChanged;

    void Awake()
    { 
        if (_instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            lives--;
    }

    public void SpawnPlayer(Transform spawnPoint)
    {
        playerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        currentSpawnPoint = spawnPoint;
    }

    void Respawn()
    { 
        if (playerInstance)
            playerInstance.transform.position = currentSpawnPoint.position;
    }

    void Gameover()
    {
        //go to gameover
    }
}
