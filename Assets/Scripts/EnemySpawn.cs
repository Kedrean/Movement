using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnTime;
    public GameObject mobSpawn;
    private float baseTime;

    // Start is called before the first frame update
    void Start()
    {
        baseTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0 )
        {
            Instantiate(mobSpawn, transform.position, Quaternion.identity);
            spawnTime = baseTime;
        }
    }
}
