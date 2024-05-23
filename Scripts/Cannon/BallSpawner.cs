using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private CannonBall ballPrefab;
    [SerializeField] private int defaultCapacity = 3;
    [SerializeField] private int maxSize = 3;
    [SerializeField] private Transform container;

    private IObjectPool<CannonBall> pool;
    private void Awake() 
    {
        pool = new ObjectPool<CannonBall>(CreateElement, OnGet, OnRelease, OnDestroyElement, true, defaultCapacity, maxSize);
    }

    private CannonBall CreateElement()
    {
        var element = Instantiate(ballPrefab, container);
        element.Pool = pool;

        return element;
    }

    private void OnGet(CannonBall cannonBall)
    {
        Vector3 spawnPos = gameObject.transform.position;
        spawnPos += new Vector3(0, 2.55f, 0f);
        cannonBall.transform.position = spawnPos;
        cannonBall.gameObject.SetActive(true);
        cannonBall.Pool = pool;
        
        cannonBall.rb.velocity = transform.forward * cannonBall.Power;
    }

    private void OnRelease(CannonBall cannonBall)
    {
        cannonBall.gameObject.SetActive(false);
    }

    private void OnDestroyElement(CannonBall cannonBall)
    {
        Debug.Log("Destroyed");
    }
    public void SpawnElement()
    {
        pool.Get();   
    }

}
