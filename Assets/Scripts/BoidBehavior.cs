using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoidBehavior : ScriptableObject
{
    public abstract Vector3 CalculateMove(Boids boid, List<Transform> context, Flock flock);
}
