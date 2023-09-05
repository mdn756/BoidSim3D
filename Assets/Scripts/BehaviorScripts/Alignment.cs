using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class Alignment : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(Boids boid, List<Transform> context, Flock flock)
    {
        // if no neighbors, maintain heading
        if (context.Count == 0)
            return boid.transform.right;

        // add all points together and average
        Vector3 alignmentMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(boid, context);
        foreach (Transform item in filteredContext)
        {
            alignmentMove += (Vector3)item.transform.right;
        }
        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
