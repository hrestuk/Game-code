using UnityEngine;

public class Hammer : MonoBehaviour, IRotateble
{
    [SerializeField] private float rotationSpeed = 6f;
    [SerializeField] private float force = 0.17f;

    private bool isHit = false;

    private void Rotation()
    {
        if (!isHit)
        {
            HammerHit();
        }
        else
        {   
            HammerRollback();
        }
    }

    private void HammerHit()
    {
        float direction = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, 90f, rotationSpeed );
        transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.eulerAngles.y,direction);
        if(transform.rotation.eulerAngles.z == 90)
        {
            isHit = true;
        }
        
    }
    private void HammerRollback()
    {
        float direction = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, 0, rotationSpeed * force );
        transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.eulerAngles.y,direction);
        if(transform.rotation.z == 0)
        {
            isHit = false;
        }
    }

    public void StartTrap()
    {
        Rotation();
    }
}
