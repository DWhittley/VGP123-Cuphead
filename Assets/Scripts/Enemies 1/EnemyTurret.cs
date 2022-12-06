using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyTurret : Enemy
{
    public float projectileFireRate;
    float timeSinceLastFire;
    Shoot shootScript;
    public float distThreshold = 5;

    public override void Start()
    {
        base.Start();  

        shootScript = GetComponent<Shoot>();
        shootScript.OnProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
    }

    private void OnDisable()
    {
        shootScript.OnProjectileSpawned.RemoveListener(UpdateTimeSinceLastFire);
    }

    public void Squish()
    {
        anim.SetTrigger("Squish");
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] currentClips = anim.GetCurrentAnimatorClipInfo(0);
        float distance = Vector2.Distance(GameManager.instance.playerInstance.transform.position, transform.position);
        float playerX = GameManager.instance.playerInstance.transform.position.x;

        if (playerX < transform.position.x && sr.flipX)
            sr.flipX = false;
        if (playerX > transform.position.x && !sr.flipX)
            sr.flipX = true;

        if (currentClips[0].clip.name != "Fire")
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate && distance < distThreshold)
            {
                anim.SetTrigger("Fire");
                timeSinceLastFire = Time.time;
            }
        }
    }

    void UpdateTimeSinceLastFire()
    {
        timeSinceLastFire = Time.time;
    }

    public void DestroyMyself()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
