using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject obj_enemy;

    float xa, xb;
    // Start is called before the first frame update
    void Start()
    {
        float x = transform.position.x;
        float s = transform.localScale.x / 2f;
        (xa, xb) = (x - s, x + s);
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void spawnEnemy()
    {
        float x = Random.Range(xa, xb);
        GameObject enemy = Instantiate(obj_enemy, new Vector3(x, transform.position.y, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
    }
}
