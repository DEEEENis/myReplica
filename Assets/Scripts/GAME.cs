using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject Restart;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
    }
    public void GameOver()
    {
        Restart.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Over Game");
    }

    public void Win()
    {
        WinScreen.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Win");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
            audioSource.Play();
            Debug.Log("sdafsaf");
        }
    }
}
