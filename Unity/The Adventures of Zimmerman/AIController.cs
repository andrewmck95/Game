using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{

    public int speed;
    public Transform target;
    public GameObject player;
    public float chaseRange;


    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        // checks that protagonist is in range, then follows if so
        if (distanceToTarget < chaseRange) {
            Vector3 localPosition = player.transform.position - transform.position;
            localPosition = localPosition.normalized; 
            transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        }
    }
}