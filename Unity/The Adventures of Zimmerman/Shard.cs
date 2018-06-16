using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shard : MonoBehaviour {


    // Handles changing direction when we hit VillainStart and end
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Protagonist")
        {
            // Play "ding" sound when shard picked up
            FindObjectOfType<AudioManager>().Play("shard_pickup");
            // Destroy the Shard object
            Object.Destroy(gameObject, 0f);
        }
    }
}
