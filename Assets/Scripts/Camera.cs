using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public SnakeMove target;
    private float offset;

    private void Awake()
    {
        offset = transform.position.z - target.transform.position.z;
    }

    void Update()
    {
        Vector3 curPos = transform.position;
        curPos.z = target.transform.position.z + offset;
        if (transform.position.z < curPos.z)
        {
            transform.position = curPos;
        }
        else return;
    }
}
