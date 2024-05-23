using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

public class CannonBall : MonoBehaviour
{
    public IObjectPool<CannonBall> Pool { get; set; }
    [NonSerialized]public Rigidbody rb;
    private float power = 40f; 
    public float Power => power;
    
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() 
    {
        if (transform.position.y < -11)
        {
            rb.velocity = Vector3.zero;
            Pool?.Release(this);
        }
        
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
  
   
}
