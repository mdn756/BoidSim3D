using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
public class SameFlockFilter : ContextFilter
{
    public override List<Transform> Filter(Boids boid, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original)
        {
            Boids itemAgent = item.GetComponent<Boids>();
            if (itemAgent != null && itemAgent.AgentFlock == boid.AgentFlock) 
            { 
                filtered.Add(item);
            }
        }
        return filtered;    
    }
}
