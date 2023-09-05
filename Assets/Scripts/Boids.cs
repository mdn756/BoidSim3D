using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Boids : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }

    SphereCollider boidCollider;
    public SphereCollider BoidCollider { get { return boidCollider; } }
    // Start is called before the first frame update
    void Start()
    {
        boidCollider = GetComponent<SphereCollider>();
    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector3 velocity)
    {
        transform.right = velocity;
        transform.position -= (Vector3)velocity * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
