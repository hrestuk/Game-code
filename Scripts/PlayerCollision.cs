using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject loseUI;

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Trap")
        {
            loseUI.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
