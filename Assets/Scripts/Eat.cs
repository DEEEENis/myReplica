using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class Eat : MonoBehaviour
{
    public SnakeTail SnakeTail;
    Random random = new Random();
    private int foodCount;
    public int MinFood;
    public int MaxFood;
    public TMP_Text Avocado;
    public GAME GAME;

    public Vector3 Rotation;
    public void Start()
    {
        foodCount = random.Next(MinFood,MaxFood);
        Avocado.text = foodCount.ToString();
    }

    private void Update()
    {
        Quaternion deltaRotation = Quaternion.Euler(Rotation * Time.deltaTime);
        transform.rotation = deltaRotation * transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag != "Head")
        {
            return;
        }

        for (int i = 0; i < foodCount; i++)
        {
            SnakeTail.AddCircle();
        }
        Destroy(transform.parent.gameObject);
    }
    
}
