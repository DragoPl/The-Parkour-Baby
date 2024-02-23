using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("END"))
        {
            End();
        }
    }
    private void End()
    {
        
        
     transform.position = new Vector3(818f, 2f, 22859f);
        
    }
}
