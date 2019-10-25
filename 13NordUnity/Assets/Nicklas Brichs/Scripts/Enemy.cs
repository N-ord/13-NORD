using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public float movespeed;
    float destroyTimer = 10f;
    public Rigidbody2D enemyRb;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        movespeed = Random.Range(8f, 13f);
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity = new Vector2(-movespeed, enemyRb.velocity.y);


        destroyTimer -= 1f * Time.deltaTime;
        if (destroyTimer <= 0f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag ==("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(other.tag ==("Projectile"))
        {
            Destroy(gameObject);
        }

    }

}
