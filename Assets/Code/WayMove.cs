using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayMove : MonoBehaviour
{
    public Transform[] waypoints; // Tablica przechowuj¹ca punkty docelowe (Waypointy)
    public float speed = 3f; // Prêdkoœæ poruszania siê platformy

    private int currentWaypointIndex = 0; // Indeks aktualnego Waypointu

    private void Update()
    {
        // Jeœli platforma dotar³a do aktualnego Waypointu, przejdŸ do nastêpnego
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        // Poruszaj platformê w kierunku aktualnego Waypointu z okreœlon¹ prêdkoœci¹
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
    }
   
}
