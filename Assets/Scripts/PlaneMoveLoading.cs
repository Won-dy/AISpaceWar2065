using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveLoading : MonoBehaviour
{
    public Vector3 wantPos;
    public float time;
    // Start is called before the first frame update
        void Start()
        {
            // wantPos = new Vector3(2.73f, 3.6f, -1.15f);
        }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, wantPos, time);
    }
}
