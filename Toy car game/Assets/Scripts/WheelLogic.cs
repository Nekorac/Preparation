using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelLogic : MonoBehaviour
{
    public GameObject car;
    Rigidbody2D rb;
    DragBack db;
    // Start is called before the first frame update
    void Start()
    {
        rb = car.GetComponent<Rigidbody2D>();
        db = car.GetComponent<DragBack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (db.GetLaunchedBool())
        {
            Debug.Log("hi");
            //rb.AddForceAtPosition(Vector2.right * 10, collision.transform.position);
            rb.AddForce(Vector2.right * 10, ForceMode2D.Force);
        }
    }
}
