using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float axisX = Random.Range(-9f, 8f);
        float axisY = 0f;
        float axisZ = Random.Range(-3f, 3f);
        Vector3 enemySpawnLocation = gameObject.transform.position + new Vector3(axisX, axisY, axisZ);

        Instantiate(enemy, enemySpawnLocation, Quaternion.identity);

        Debug.Log("Enemy Created");
    }
}
