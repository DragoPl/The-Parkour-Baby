using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float Fall;





    private void OnCollisionEnter(Collision collision)
    {    
        if (collision.collider.CompareTag("Lawa"))
        {
            Die();
        }
    }
    void FixedUpdate()
    {
        if (transform.position.y < Fall)
        {


            Die();
        }
    }

    void Die()
    {


        Respawn();
    }
    
    void Respawn()
    {
        transform.position = new Vector3(0f, 2.32f, 0f);
    }
    
}
