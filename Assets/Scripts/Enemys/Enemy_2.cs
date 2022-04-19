using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

public class Enemy_2 : MonoBehaviour
{
    public float speed; 

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.down * speed * Time.deltaTime); 
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
}
