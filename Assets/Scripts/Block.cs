using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class Block : MonoBehaviour
{
    public SnakeTail SnakeTail;
    Random random = new Random();
    private int blockCount;
    public int MinBlock;
    public int MaxBlock;
    public TMP_Text Blocks;
    private float time = 0f;
    public GAME Game;
    

    public void Start()
    {
        blockCount = random.Next(MinBlock, MaxBlock);
    }
    private void Update()
    {
        Blocks.text=blockCount.ToString();
    }
    private void OnCollisionStay(Collision collision)
    {
        time -= Time.deltaTime;
        
        if (time <= 0)
        {
            if (blockCount > 1 && SnakeTail.Life > 1)
            {
                SnakeTail.RemoveCircle();
                blockCount--;
                //Destroy(gameObject);
            }
            if (blockCount <= 1 && SnakeTail.Life > 1)
            {
                SnakeTail.RemoveCircle();
                blockCount--;
                Destroy(gameObject);
            }
            if (blockCount >= 1 && SnakeTail.Life <= 1)
            {
                Game.GameOver();
                blockCount--;
                //Destroy(gameObject);
            }
            else if (blockCount == 0)
            {
                               
                Destroy(gameObject);
            }
            time = 0.1f;
        }            
        
    }
}
