using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{   
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;
    

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 05f;
    [HideInInspector]public bool isFiring;
    
    Coroutine firingCouroutine;

    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }


    void Start()
    {
        if(useAI){
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire(){
        if(isFiring && firingCouroutine == null){
        firingCouroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCouroutine != null){
            StopCoroutine(firingCouroutine);
            firingCouroutine = null;
        }
    }

    IEnumerator FireContinuously(){
        while(true){
            GameObject instance = Instantiate(projectilePrefab, 
                                                transform.position, 
                                                    Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null){
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);
            

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance,
                                                    baseFiringRate + minimumFiringRate);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }

}
