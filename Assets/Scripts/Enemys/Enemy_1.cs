using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

public class Enemy_1 : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform shootSpawn;

    public float fireRate;
    public float nextFire;


    
    // Start is called before the first frame update
    void Start()
    {
        
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
        PoolsManager.Instance.GetPool("EnemyPool").AddToPool(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Bullet")
      {
          Destroy();
      }  
    }
}
