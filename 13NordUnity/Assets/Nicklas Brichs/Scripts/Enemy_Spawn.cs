using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public Transform enemyPrefab;
    public float chooseRandomPos;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(3f, 5f);
        chooseRandomPos = Random.Range(-2f, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= 1f * Time.deltaTime;
        if (Timer <= 0f)
        {
            Timer = Random.Range(3f, 5f);
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        chooseRandomPos = Random.Range(-2f, 3.5f);
        Instantiate(enemyPrefab, new Vector3(9.5f, chooseRandomPos, 0f),Quaternion.identity);
    }


}
