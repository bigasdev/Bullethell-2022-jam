using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

public class EnemySpawn : MonoBehaviour
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
        PoolsManager.Instance.GetPool("EnemyPool").GetFromPool(enemySpawn.position);
    }
}
