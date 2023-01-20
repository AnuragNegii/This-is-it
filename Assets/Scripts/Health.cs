using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] int score = 10;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    ScoreKeeper scoreKeeper;
    AudioPlayer audioPlayer;

    LevelManager levelManager;

    private void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager  = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            int damageTaken = damageDealer.GetDamage();
            TakeDamage(damageTaken);
            PlayHitEffect();
            ShakeCamera();
            audioPlayer.PlayDamageTaken();
            damageDealer.Hit();
        }
    }

    public int GetHealth(){
        return health;
    }
    
   void TakeDamage(int damageTaken)
    {
        health = health - damageTaken;// health -= damageTaken;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die(){
            if(!isPlayer){
            scoreKeeper.ModifyScore(score);
            }
            else{
                levelManager.LoadGameOver();
            }
            Destroy(gameObject);

    }
    void PlayHitEffect(){
        if(hitEffect != null){
            ParticleSystem instance = Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera(){
       if(cameraShake!= null && applyCameraShake) {
            cameraShake.Play();
       }
    }

}

