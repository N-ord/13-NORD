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

    float ShootDelayCurrent = 1;
    public float ShootDelay = 1;

    public float speed;

    private void Start() {

        transform.position = StartPos;
    }

    // Update is called once per frame
    void Update() {

        UpdatePos();
        if (Input.GetKey(ShootKey) && ShootDelayCurrent < 0) {
            Shoot();
        }
        if (ShootDelayCurrent > 0) {
            ShootDelayCurrent -= Time.deltaTime;
        }
    }

    void Shoot() {

        switch (shotType) {
            case ShotType.Normal:
                Instantiate(NormalShot, ShootTransform.position, Quaternion.identity);
                ShootDelayCurrent = ShootDelay;
                break;
            case ShotType.Charge:
                Instantiate(ChargeShot);
                ShootDelayCurrent = ShootDelay;
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

        transform.position = Vector3.Lerp(transform.position, new Vector3(MoveDelta.x, MoveDelta.y, 0) * speed + transform.position, Time.deltaTime);

//        transform.position += new Vector3(MoveDelta.x, MoveDelta.y, 0) * speed * Time.deltaTime;
    }

    private void OnEnable() {

        ShootTransform = transform.GetChild(0);
    }
}