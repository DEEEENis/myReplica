using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;
    public int Life = 1;
    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    public TMP_Text LifeText;
    private Vector3 offset;

    private void Awake()
    {
        positions.Add(SnakeHead.position);
        offset = SnakeHead.transform.position - LifeText.rectTransform.position;
    }

    private void Update()
    {
        float distance = ((Vector3)SnakeHead.position - positions[0]).magnitude;
        LifeText.text = Life.ToString();
        LifeText.rectTransform.position = SnakeHead.position - offset;

        if (distance > CircleDiameter)
        {
            // Ќаправление от старого положени€ головы, к новому
            Vector3 direction = ((Vector3)SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        circle.tag = "Tail";        
        snakeCircles.Add(circle);
        positions.Add(circle.position);
        Life++;
    }

    public void RemoveCircle()
    {
        Destroy(snakeCircles[snakeCircles.Count - 1].gameObject);
        snakeCircles.RemoveAt(snakeCircles.Count - 1);
        positions.RemoveAt(positions.Count - 1);
        Life--;
    }
}
