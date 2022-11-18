using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME : MonoBehaviour
{
    public void GameOver()
    {
        Time.timeScale = 0f;
        Debug.Log("Over Game");
    }
}
