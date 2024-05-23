using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAllTraps : MonoBehaviour 
{
    private List<IRotateble> rotations = new List<IRotateble>();
    [SerializeField] List<Hammer> hammers;
    [SerializeField] List<Axe> axes;
    [SerializeField] List<Spin> spins;
    private void Awake() 
    {
        InitializeTraps(hammers);
        InitializeTraps(axes);
        InitializeTraps(spins);

    }
    private void FixedUpdate()
    {
        foreach (var item in rotations)
        {
            item.StartTrap();
        }
    }

    private void InitializeTraps<T>(List<T> obj)where T : IRotateble
    {        
        for (int i = 0; i < obj.Count; i++)
        {
            rotations.Add(obj[i]);
        }
    }
}
