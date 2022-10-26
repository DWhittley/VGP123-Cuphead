using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
