using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    public float movespeed;
    float destroyTimer = 12f;
    public Rigidbody2D crateRB;


    // Start is called before the first frame update
    void Start() {
        crateRB = GetComponent<Rigidbody2D>();
        movespeed = Random.Range(4f, 10f);

    }

    // Update is called once per frame
    void Update() {
        crateRB.velocity = new Vector2(-movespeed, crateRB.velocity.y);


        destroyTimer -= 1f * Time.deltaTime;
        if (destroyTimer <= 0f) {
            Destroy(gameObject);
        }

    }

}
