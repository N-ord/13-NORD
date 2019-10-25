﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    void Start() {
        Random.seed = System.Environment.TickCount;
    }

    public string tagName; /*Enter the tag in the Editor*/

    public GameObject powerup1;

    public GameObject powerup2;

    public void OnCollisionEnter2D(Collision2D myCol) { /*Detect collision with GameObject*/

        Debug.Log("Collision with " + myCol.gameObject);
        Debug.Log("GameObject tag " + gameObject.tag);
        Debug.Log("Projectile tag " + myCol.gameObject.tag);



        int inst = Random.Range(0, 3);

        if (myCol.gameObject.tag == tagName) { /*Check if the collided GameObjects tag matches choosen one in editor*/
            if (gameObject.tag == "Crate")
                if (inst == 1)
                    Instantiate(powerup1, myCol.gameObject.transform.position, Quaternion.identity);
                else
                    Instantiate(powerup2, myCol.gameObject.transform.position, Quaternion.identity);
                Destroy(myCol.gameObject);
            if (gameObject.tag == "Enemy") {
                DropChance(true, myCol);
                
               Destroy(gameObject); /*Destroy the enemy, or whatever you put this stript on*/
            }
           Destroy(myCol.gameObject); /*Destroy the projectile*/
        }
    }

    void DropChance(bool Chance, Collision2D MyCol) {
        int temp = Random.Range(0, 3); /* Rand 1-2*/
        int temp2 = Random.Range(0, 3);

        if(Chance == true) { /*If it's an enemy*/
            if (temp2 == 1) {
                Drop(temp, MyCol);
            }
        }
    }

    void Drop(int PowerUp, Collision2D MyCol) {
        if(PowerUp == 1) {
            Instantiate(powerup1, MyCol.gameObject.transform.position, Quaternion.identity);
        }
        else {
            Instantiate(powerup2, MyCol.gameObject.transform.position, Quaternion.identity);
        }
    }
}
