using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    Canvas currentMessage;


    void Start()
    {
        currentMessage.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Protagonist")
        {
            TurnOnMessage();
        }
    }

    private void TurnOnMessage()
    {
        currentMessage.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Protagonist")
        {
            TurnOffMessage();
        }
    }

    private void TurnOffMessage()
    {
        currentMessage.enabled = false;
    }
}