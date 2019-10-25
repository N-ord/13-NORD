using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public float movespeed;
    float destroyTimer = 10f;
    public Rigidbody enemyRb;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        movespeed = Random.Range(8f, 13f);
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity = new Vector3(-movespeed, enemyRb.velocity.y, enemyRb.velocity.z);


        destroyTimer -= 1f * Time.deltaTime;
        if (destroyTimer <= 0f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag ==("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
