using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public enemySpawner spawner;
    public GameObject obj_javelin;

    [SerializeField] float force = 5f;
    [SerializeField] TMP_Text tmp_Score;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemySpawner = GameObject.Find("obj_enemy_spawner");
        GameObject txt = GameObject.FindGameObjectWithTag("tmp_score");
        tmp_Score = txt.GetComponent<TMP_Text>();
        spawner = enemySpawner.GetComponent<enemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case SD.JAVELIN_TAG:
                kill();
                break;
            default:
                break;
        }
    }

    void kill()
    {
        SD.score += 1;
        tmp_Score.text = $"SCORE\t{SD.score}";
        Destroy(gameObject);
        spawner.spawnEnemy();
    }
}
