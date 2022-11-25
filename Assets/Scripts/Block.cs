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
    private int MinBlock=1;
    private int MaxBlock=100;
    public TMP_Text Blocks;
    private float time = 0f;
    public GAME Game;
    private new Renderer renderer;
    private AudioSource audioSource;

    public GameObject AnimeBlock;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void Start()
    {
        blockCount = random.Next(MinBlock, MaxBlock);
        renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        Blocks.text = blockCount.ToString();
        renderer.material.SetFloat("_Gradient", blockCount * 0.01f);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Head")
        {
            return;
        }

        time -= Time.deltaTime;
      
        if (time <= 0 && !Game.die)
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
                Instantiate(AnimeBlock, transform.position, transform.rotation);
                Destroy(gameObject);
                Game.CrashBlock();
            }
            if (blockCount >= 1 && SnakeTail.Life <= 1)
            {
                blockCount--;
                SnakeTail.Life = 0;
                Game.GameOver();                
                //Destroy(gameObject);
            }
            else if (blockCount == 0)
            {
                Instantiate(AnimeBlock, transform.position, transform.rotation);
                Destroy(gameObject);
                Game.CrashBlock();
            }
            time = 0.12f;
        }            
        
    }
}
