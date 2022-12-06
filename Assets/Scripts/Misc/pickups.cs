using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour
{
    
    public enum PickupType
    {
        Powerup = 0,
        Life = 1,
        Score = 2
    }

    public PickupType currentPickup;
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currentPickup)
            {
                case PickupType.Life:
                    GameManager.instance.lives++;
                    break;
                case PickupType.Powerup:
                    collision.gameObject.GetComponent<PlayerController>().StartJumpForceChange();
                    break;
                case PickupType.Score:
                    Debug.Log("Score was picked up");
                    break;

            }
            
            if (pickupSound)
                collision.gameObject.GetComponent<AudioSourceManager>().PlayOneShot(pickupSound, false);

            Destroy(gameObject);
        } 
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
