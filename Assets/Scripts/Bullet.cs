using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.up; //Vector3(0,1,0)
        transform.position += dir * speed * Time.deltaTime;
    }
}
