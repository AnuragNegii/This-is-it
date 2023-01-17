using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider Healthslider;
    [SerializeField] Health PlayerHealth;


    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;


    
    

    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    }

    void Start()
    {
        Healthslider.maxValue = PlayerHealth.GetHealth();
    }


    void Update()
    { 
        Healthslider.value = PlayerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
