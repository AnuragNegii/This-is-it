using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WaveConfig", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject {
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;

    public float GetMoveSpeed(){
        return moveSpeed;
    }
    
}

