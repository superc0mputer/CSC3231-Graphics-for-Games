using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Waypoints : MonoBehaviour
{
   [SerializeField] private GameObject[] waypoints;
   [SerializeField] private float speed;
   private int current = 0;

   private void Update()
   {
      if (Vector3.Distance(waypoints[current].transform.position, transform.position) <= 0)
      {
         Random r = new Random();
         current = r.Next(0, waypoints.Length);
      }

      transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position,
         Time.deltaTime * speed);
   }
}
