using UnityEngine;

public class Spin : MonoBehaviour, IRotateble
{
    [SerializeField] private float rotationSpeed = 5f;
    
    public Vector3 Angle = new Vector3(0,1,0);
    
    public void StartTrap()
    {
        Rotation();
    }

    private void Rotation()
    {
        
        transform.Rotate(Angle*rotationSpeed*Time.deltaTime);
        
    }
}
