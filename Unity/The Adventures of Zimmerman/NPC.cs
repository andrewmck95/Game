using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DIALOGUE TRIGGER

// This script will sit on an object and will allow trigger to enter a dialogue
public class NPC : MonoBehaviour {

	public Dialogue dialogue;

	public void TriggerDialogue(){
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}
