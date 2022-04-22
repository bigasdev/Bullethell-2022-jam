using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

public class Enemy_2 : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform shootSpawn;

    public float fireRate;
    public float nextFire;

    public float speed; 

    // Update is called once per frame
    void Update()
    {
       Fire();
       transform.Translate(Vector2.down * speed * Time.deltaTime); 
    }

    private void Fire()
    {
        fireRate -= Time.deltaTime;

        if(fireRate <= 0)
        {
           fireRate =  nextFire;
           PoolsManager.Instance.GetPool("EnemyBullets").GetFromPool(shootSpawn.position);
        }
    }

    public void Destroy()
    {
        PoolsManager.Instance.GetPool("EnemyPool2").AddToPool(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Bullet")
      {
          Destroy();
      }  
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.gameObject.layer == 6)
       {
           Destroy();
       }
    }
}
