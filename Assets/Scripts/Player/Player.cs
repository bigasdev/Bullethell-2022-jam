using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

public class Player : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;

    public Transform shootSpawn;
    public GameObject bullet;
    public float fireRate;

    public int speed;

    public int chain = 4;

    private float nextFire; 
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      Move();

      if(Input.GetButton("Fire1") && Time.time > nextFire)
      {
          nextFire = Time.time + fireRate;
          PoolsManager.Instance.GetPool("PlayerBullets").GetFromPool(shootSpawn.position);
      }  
    }

    void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

       if(h == -1 && transform.position.x <= xMin)
       {
            h = 0;
       }
       if(h == 1 && transform.position.x >= xMax)
       {
           h = 0;
       }
       if(y == -1 && transform.position.y <= yMin)
       {
           y = 0;
       }
       if(y == 1 && transform.position.y >= yMax)
       {
           y = 0;
       }


       Vector3 movement = new Vector3(h, y, 0f);
       transform.position += movement * Time.deltaTime * speed;
       
       if(chain == 4)
       {
          GameController.instance.totalSpeed = 3;
       }else if(chain == 3)
       {
           GameController.instance.totalSpeed = 4;
       }else if(chain == 2)
       {
           GameController.instance.totalSpeed = 5;
       }else if(chain == 1)
       {
           GameController.instance.totalSpeed = 6;
       }else if(chain == 0)
       {
           GameController.instance.totalSpeed = 7;
       }

       speed = GameController.instance.totalSpeed;

    }
    
}