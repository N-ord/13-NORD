using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
    public string tagName; /*Enter the tag in the Editor*/

    public void OnCollisionEnter2D(Collision2D myCol) { /*Detect collision with GameObject*/
        Debug.Log("Collision with " + myCol.gameObject);
        if (myCol.gameObject.tag == tagName) { /*Check if the collided GameObjects tag matches tag written in editor*/
            Destroy(gameObject); /*Destroy the Player, or whatever you put this stript on*/
        }
        Destroy(myCol.gameObject); /*Destroy the projectile*/
    }
}
