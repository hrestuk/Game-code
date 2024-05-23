using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Inputs
    private Controller inputs;
    private InputAction move;
    
    [SerializeField] private LayerMask ground;
    private Rigidbody rb;
    
    private Vector3 forceDirection;
    [SerializeField] private float speed = 4.5f;
    [SerializeField] private float maxForce = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    
    //Status 
    public static bool isGrounded = true;

    private void OnEnable() 
    {
        inputs.Enable();
        move = inputs.Movement.Move;
    }

    private void OnDisable() 
    {
        inputs.Disable();
    }

    private void Awake() 
    {
        inputs = new Controller();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        Movement(); 
    }  
   

    private void Movement()
    {
        if(IsGrounded())
        {
            forceDirection += new Vector3(move.ReadValue<Vector2>().x * maxForce, 0, move.ReadValue<Vector2>().y * maxForce);
        }

        rb.AddForce(forceDirection, ForceMode.VelocityChange);

        forceDirection = Vector3.zero;
        
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;

        if (horizontalVelocity.sqrMagnitude > speed*speed)
        {
            rb.velocity = horizontalVelocity.normalized * speed + Vector3.up * rb.velocity.y;
        }
        Rotation();
    } 
    
    private bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        float rayLength = 1.0f;

        if (Physics.Raycast(ray, rayLength,ground))
        {
            rb.drag = 3.5f;
            isGrounded = true;
            return isGrounded;
        }
        else
        {
            rb.drag = -2f;
            isGrounded = false;
            return isGrounded;
        }
    }

    private void Rotation()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0;

        if(move.ReadValue<Vector2>().magnitude > 0.1f && direction.magnitude > 0.1f)
        {
            rb.rotation = Quaternion.Lerp(rb.rotation, Quaternion.LookRotation(direction, Vector3.up), rotationSpeed*Time.fixedDeltaTime);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }
}
