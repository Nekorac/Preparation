using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelLogic : MonoBehaviour
{
    public GameObject car;
    Rigidbody2D rb;
    DragBack db;
    float yRot;
    int direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = car.GetComponent<Rigidbody2D>();
        db = car.GetComponent<DragBack>();
    }

    // Update is called once per frame
    void Update()
    {
        yRot = car.transform.rotation.eulerAngles.y;
        if (yRot == 180 || yRot == -180)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        Debug.Log(yRot);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (db.GetLaunchedBool())
        {
            //rb.AddForceAtPosition(Vector2.right * 10, collision.transform.position);
            //Debug.Log("hi");
            rb.AddForce(Vector2.right * direction * 10, ForceMode2D.Force);
        }
    }
}
