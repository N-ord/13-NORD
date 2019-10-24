using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ShotType {
    Normal,
    Charge
}

public class PlayerController : MonoBehaviour {

    public KeyCode MoveOp = KeyCode.W;
    public KeyCode MoveDown = KeyCode.S;
    public KeyCode MoveLeft = KeyCode.D;
    public KeyCode MoveRight = KeyCode.A;

    public KeyCode ShootKey = KeyCode.Space;
    public KeyCode ChangeShotType = KeyCode.Tab;


    ShotType shotType = ShotType.Normal;

    public Vector2 StartPos;

    [SerializeField]
    GameObject NormalShot, ChargeShot;

    [SerializeField]
    Transform ShootTransform;

    public float speed;

    private void Start() {

        transform.position = StartPos;
    }

    // Update is called once per frame
    void Update() {

        UpdatePos();
        if (Input.GetKey(ShootKey)) {
            Shoot();
        }
    }

    void Shoot() {

        switch (shotType) {
            case ShotType.Normal:
                Instantiate(NormalShot);
                break;
            case ShotType.Charge:
                Instantiate(ChargeShot);
                break;
            default:
                break;
        }

    }

    void UpdatePos() {

        Vector2 MoveDelta = Vector3.zero;

        if (Input.GetKey(MoveOp)) {

            MoveDelta += Vector2.up;
        }
        if (Input.GetKey(MoveDown)) {
            MoveDelta += Vector2.down;
        }
        if (Input.GetKey(MoveLeft)) {
            MoveDelta += Vector2.left;
        }
        if (Input.GetKey(MoveRight)) {
            MoveDelta += Vector2.right;
        }

        MoveDelta = MoveDelta.normalized;

        transform.position += new Vector3(MoveDelta.x, MoveDelta.y, 0) * speed * Time.deltaTime;
    }

    private void OnEnable() {

        ShootTransform = transform.GetChild(0);
    }

    private void OnDrawGizmosSelected() {
        if (ShootTransform == null) {
            ShootTransform = transform.GetChild(0);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawCube(ShootTransform.position, Vector3.one);
    }
}
