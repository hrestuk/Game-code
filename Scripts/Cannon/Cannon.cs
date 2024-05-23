using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Cannon : MonoBehaviour
{
  
    [SerializeField] private float timeToSpawn = 1f;
    private float time = 0;
    private BallSpawner ballSpawner;
    private CannonAnimation cannonAnimation;
    
    private void Awake() 
    {
        ballSpawner = GetComponent<BallSpawner>();
        cannonAnimation = GetComponent<CannonAnimation>();
    }
    private void Start() {
        InvokeRepeating("Shoot",0f,timeToSpawn);
    }

    private void Shoot()
    {
        cannonAnimation.PlayAnimation();
        ballSpawner.SpawnElement();
        time = timeToSpawn;
    }
    
    
}
