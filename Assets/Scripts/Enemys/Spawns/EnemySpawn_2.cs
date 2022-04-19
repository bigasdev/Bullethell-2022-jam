using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

public class EnemySpawn_2 : MonoBehaviour
{
    public Transform enemySpawn;

    private float enemyRespawn;
    private Timer timer;
     
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(2, true);
        timer.OnComplete += SpawnEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        timer.Update();
    }

    void SpawnEnemy()
    {
        PoolsManager.Instance.GetPool("EnemyPool2").GetFromPool(enemySpawn.position);
    }
}
