using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;

    public LayerMask targetLayers;
    public LayerMask obstacleLayers;

    public Collider detectedTarget;

    //Creates a list of colliders that overlap the enemy surroundings.
    private void Update()
    {
       Collider[] colliders = Physics.OverlapSphere(transform.position, distance, targetLayers);

        detectedTarget = null;
        //Tracks the direcction vector for  each these colliders.
        foreach (Collider collider in colliders)
        {
            Vector3 directionToCollider = collider.bounds.center - transform.position;  
            directionToCollider = Vector3.Normalize(directionToCollider);

            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);

            //If the collider is inside the viewing angle of the enemy it becomes a detected target
            if (angleToCollider < angle)
            {
                if (!Physics.Linecast(transform.position,collider.bounds.center,out RaycastHit hit,obstacleLayers))
                {
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.blue);
                    detectedTarget = collider;
                    break;
                }
                else 
                {
                  Debug.DrawLine(transform.position,hit.point,Color.grey);
                }
            }
        }
    }
    //Draws lines so the the viewing angle of the enemy is visible on the scene editor.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        Gizmos.color = Color.green;
        Vector3 rightDir = Quaternion.Euler(0,angle,0)*transform.forward;
        Gizmos.DrawRay(transform.position, rightDir * distance);

        Vector3 leftDir = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDir * distance);
    }
}
