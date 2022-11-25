using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
      
    public float ForwardSpeed = 5;
    public float Sensitivity = 10;
    public GAME Game;
    

    private new Rigidbody rigidbody;

    private Vector3 touchLastPos;
    private float sidewaysSpeed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Game.die)
        {
            ForwardSpeed = 0;
            Sensitivity = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }

        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - touchLastPos;
            sidewaysSpeed += delta.x * Sensitivity;
            touchLastPos = Input.mousePosition;
        }


    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        rigidbody.velocity = new Vector3(sidewaysSpeed * 5, 0, ForwardSpeed);

        sidewaysSpeed = 0;
    }
}
