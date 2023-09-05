using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/SteeredCohesion")]

public class SteeredCohesion : FilteredFlockBehavior
{
    Vector3 currentVel;
    public float agentSmoothTime = 0.5f;

    public override Vector3 CalculateMove(Boids boid, List<Transform> context, Flock flock)
    {
        // if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        // add all points together and average
        Vector3 avg_pos = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(boid, context);
        foreach (Transform item in filteredContext)
        {
            avg_pos += (Vector3)item.position;
        }
        avg_pos /= context.Count;

        // create offset from agent positon
        avg_pos += (Vector3)boid.transform.position;
        avg_pos = Vector3.SmoothDamp(boid.transform.right, avg_pos, ref currentVel, agentSmoothTime);
        return avg_pos;
    }
}