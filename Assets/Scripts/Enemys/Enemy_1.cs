using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

public class Enemy_1 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Destroy()
    {
        PoolsManager.Instance.GetPool("EnemyPool").AddToPool(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Bullet")
      {
          Destroy();
      }  
    }
}
