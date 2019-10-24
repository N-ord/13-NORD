using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
    public string tagName; //this will show up as an input box for the component, which can be given a tag of your choice.  assign the 

    void OnCollisionEnter2D(Collision2D myCol) { //run the following whenever a collision happens to the object attached with this script
        Debug.Log("Collision with " + myCol.gameObject);
        if (myCol.gameObject.tag == tagName) { //does the object collided with have the tag in question?
            Destroy(gameObject); //if so, destroy that object!
        }

    }
}
