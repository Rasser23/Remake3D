using UnityEngine;
using UnityEngine.AI;
public class EnemyNavMov : MonoBehaviour // this script controls the movement of the enemy spheres
{
   public Transform player; // reference to the player that the enemy will chase 
   public float chaseRange = 20f; // how far the enemy can detect the player from 
   public float stopDistance = 1.5f; // how close the enemy gets before stopping

   private NavMeshAgent agent; // navmesh component controlling movement 

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); // get the navmesh agent attacthed to this object 
        agent.stoppingDistance = stopDistance; // set how close the agent gets before stopping
    }

    void Update()
    {
        if (player == null) return; // safety check - if the player is not assigned, exit

        float distance = Vector3.Distance(transform.position, player.position); // calculate the distance between enemy and player 

        if (distance <= chaseRange) // if the player is within chase range, move towards them 
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.ResetPath(); // stop moving when player is far away 
        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red; // draw a visual red circle in the scene showing the chase range
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
