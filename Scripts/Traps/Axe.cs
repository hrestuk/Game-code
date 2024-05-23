using Unity.Mathematics;
using UnityEngine;

public class Axe : MonoBehaviour, IRotateble
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float range = 5f;
    private float zAngle = 0f;
    [SerializeField] private float yAngle =0;

    public void StartTrap()
    {
        Rotation();
    }

    private void Rotation()
    {
        zAngle = Mathf.Sin(rotationSpeed * Time.time);
        transform.rotation = Quaternion.Euler(0,yAngle,zAngle * range+180);
    }    
}
