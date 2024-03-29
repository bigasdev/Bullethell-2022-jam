using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

public class Bullet : MonoBehaviour
{
    public float speed;

    private bool shoot;

    void Update()
    {
       transform.Translate(Vector2.up * speed * Time.deltaTime);
        
    }
    public void Destroy()
    {
        PoolsManager.Instance.GetPool("PlayerBullets").AddToPool(this.gameObject);
    }

     void OnTriggerEnter2D(Collider2D collider)
     {
         if(collider.gameObject.layer == 6)
         {
             Destroy();
         }
         if(collider.gameObject.tag == "DestroyBullet")
         {
             Destroy();
         }
         var e = collider.GetComponent<Enemy_1>();
         if(e != null)
         {
             PoolsManager.Instance.GetPool("EnemyPool").AddToPool(e.gameObject);
         }       
         var c = collider.GetComponent<Enemy_2>();
         if(c != null)
         {
             PoolsManager.Instance.GetPool("EnemyPool2").AddToPool(c.gameObject);
         }   
     
     }

        
}
