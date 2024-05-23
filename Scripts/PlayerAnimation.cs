using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody rb;
    [SerializeField] private float animationSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();    
    }

    private void Update() 
    {
        if(Player.isGrounded)
        {
            playerAnimator.SetFloat("speed",rb.velocity.magnitude / animationSpeed);
        }
        else
        {
            playerAnimator.SetFloat("speed",0f);
        }
       
    }

}
