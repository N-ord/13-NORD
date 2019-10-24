using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour { 
   void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Projectile") {
            Destroy(gameObject);
        }
    }
}
