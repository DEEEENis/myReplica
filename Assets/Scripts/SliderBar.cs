using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    public SnakeMove Snake;
    public Transform Finish;
    public Slider Slider;
    private float startZ;
    private float finishZ;
    private float maximumReachedZ;
    private float acceptableFinishPLayerDistance = 0.96f;
    public GAME GAME;
    public TMP_Text CurrentLevel;
    public TMP_Text NextLevel;

    private void Start()
    {
        startZ = Snake.transform.position.z;
        finishZ = Finish.position.z;
        //CurrentLevel.text = GAME.LevelIndex.ToString();
        //NextLevel.text = (GAME.LevelIndex +1).ToString();
        CurrentLevel.text = SceneManager.GetActiveScene().buildIndex.ToString();
        NextLevel.text = (SceneManager.GetActiveScene().buildIndex +1).ToString();
    }

    private void Update()
    {
        float currentZ = Snake.transform.position.z;
        maximumReachedZ = Mathf.Max(maximumReachedZ, currentZ);
        float t = Mathf.InverseLerp(startZ, finishZ - acceptableFinishPLayerDistance, maximumReachedZ);
        Slider.value = t;
    }
}
