using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : MonoBehaviour
{

    // Get reference to the Animator so I can change animations
    private Animator animator;
    
    GameObject protagonistGO;
    Rigidbody2D rb;

    void Awake()
    {
        // Get reference to Link
        protagonistGO = GameObject.Find("Protagonist");

        // Get reference to rigid body
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    // Handles changing direction when we hit VillainStart and end
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Sword"){
            // play sound when enemy dies
            FindObjectOfType<AudioManager>().Play("villain_hit");
            // Destroy the villain object
            Object.Destroy(gameObject, 0.1f);
        }
    }
}
