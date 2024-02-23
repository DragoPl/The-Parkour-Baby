using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayMove : MonoBehaviour
{
    public Transform[] waypoints; // Tablica przechowuj�ca punkty docelowe (Waypointy)
    public float speed = 3f; // Pr�dko�� poruszania si� platformy

    private int currentWaypointIndex = 0; // Indeks aktualnego Waypointu

    private void Update()
    {
        // Je�li platforma dotar�a do aktualnego Waypointu, przejd� do nast�pnego
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        // Poruszaj platform� w kierunku aktualnego Waypointu z okre�lon� pr�dko�ci�
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
    }
   
}
