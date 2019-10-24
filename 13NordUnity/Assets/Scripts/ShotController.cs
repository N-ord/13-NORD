using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField]
    bool MoveLeft = false;

    [SerializeField]
    float Speed = 0;

    // Update is called once per frame
    void Update()
    {
        if (MoveLeft) {

        this.transform.position += Vector3.left * Speed * Time.deltaTime;
        }
        else {

        this.transform.position += Vector3.right * Speed * Time.deltaTime;
        }

    }
}
