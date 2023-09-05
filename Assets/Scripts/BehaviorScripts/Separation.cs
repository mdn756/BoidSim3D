using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/Separation")]
public class Separation : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(Boids boid, List<Transform> context, Flock flock)
    {
        // if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        // add all points together and average
        Vector3 SeparationMove = Vector3.zero;
        int num_avoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(boid, context);
        foreach (Transform item in filteredContext)
        {
            if (Vector3.SqrMagnitude(item.position - boid.transform.position) < flock.SquareAvoidanceRadius)
            {
                num_avoid++;
                SeparationMove -= (Vector3)(boid.transform.position - item.position);
            }
            
        }
        if (num_avoid > 0)
        {
            SeparationMove /= num_avoid;
        }

        return SeparationMove;
    }
}
