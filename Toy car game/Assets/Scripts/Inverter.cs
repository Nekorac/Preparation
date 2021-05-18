using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : MonoBehaviour
{
    public float rotationY = 180;
    public float rotationZ = 90;
    bool inverted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!inverted)
        {
            collision.GetComponent<Transform>().Rotate(new Vector3(0, rotationY, rotationZ));
            inverted = true;
        }
    }
}
