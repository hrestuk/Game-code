using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void LateUpdate() 
    {
        Vector3 followPosition = new Vector3(player.transform.position.x, transform.position.y , player.transform.position.z - 20); 
        transform.position = followPosition;
    }
    
}
