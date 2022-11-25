using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAME : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject Restart;
    private AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClipWin;
    public AudioClip audioClipGameOver;
    [Min(0)]
    public float volume;
    public Material Snake;
    public bool die = false;
    private float disTime = 0f;
    public GameObject LifeText;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
        Snake.SetFloat("_DISOV", 0);
    }

    private void Start()
    {
        LevelIndex= SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (die)
        {
            disTime += (Time.deltaTime * 0.2f);
            Snake.SetFloat("_DISOV", disTime);
        }
    }
    public void GameOver()
    {
        audioSource.PlayOneShot(audioClipGameOver, volume);
        Invoke("RestartDelay",4f);
        die=true;
        LifeText.SetActive(false);
    }
    private void RestartDelay()
    {
        Restart.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Win()
    {
        audioSource.PlayOneShot(audioClipWin, volume);
        Invoke("WinDelay", 4f);
        Debug.Log("Win");
    }
    private void WinDelay()
    {
        WinScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
            audioSource.Play();
        }
    }
    public void CrashBlock()
    {
        audioSource.PlayOneShot(audioClip, volume);
    }

    public static int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 1);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "Level Index";

}
