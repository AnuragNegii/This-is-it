using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageTaken;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;


    public void PlayShootingClip(){
      PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageTaken(){
        PlayClip(damageTaken, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume){
        if(clip != null){
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }

    }
}
