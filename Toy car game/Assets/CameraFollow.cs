using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform car;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - car.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = car.position + offset;
    }
}
