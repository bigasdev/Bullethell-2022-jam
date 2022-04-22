using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    
    private bool shoot;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void Destroy()
    {     
        PoolsManager.Instance.GetPool("EnemyBullets").AddToPool(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            Destroy();
        }
        var e = collider.GetComponent<Player>();
        if(e != null)
        {
            Destroy(collider.gameObject);
        }
        var m = collider.GetComponent<Player>();
        if(m != null)
        {
            Destroy();
        }
    }
}
