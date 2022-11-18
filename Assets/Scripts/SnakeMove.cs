using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Vector3 Force;
    public Vector3 SideSpeed = new Vector3(10, 0, 0);

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {

    }

    private void Update()
    {
        Rigidbody.AddForce(Force, ForceMode.VelocityChange); //Объекту придаётся сила постоянная
        float inputX = Input.GetAxis("Horizontal");
        Rigidbody.velocity = new Vector3(SideSpeed.x * inputX, 0, 0);
    }
}
