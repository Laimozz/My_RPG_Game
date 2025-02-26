using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Vector2[] points;

    public Vector2[] Points => points;

    public Vector2 EntityPosition { get; set; }

    private bool gameStarted = true;
    void Start()
    {
        EntityPosition = transform.position;
    }

    private void OnDrawGizmos()
    {
        if(gameStarted == false && transform.hasChanged)
        {
            EntityPosition = transform.position;
        }
    }

}
