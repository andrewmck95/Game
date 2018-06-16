using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	// Queue as mentioned in online tutorial
	private Queue<string> sentences;

	// references to UI elements
	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue){

		animator.SetBool("BoxOpen", true);
		
		nameText.text = dialogue.name;
		//clear sentences from previous conversation
		// .Clear() is used to clear from Queue
		sentences.Clear();

		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		// display the next sentence
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if(sentences.Count == 0){
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
		// stop animating before starting new sentence
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	// is used to print dialogue letter by letter
	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			// adding individual letters
			dialogueText.text += letter;
			// wait to write letters to screen
			yield return new WaitForSeconds(0.019f);
		}
	}

	void EndDialogue(){
		animator.SetBool("BoxOpen", false);
	}
	
}
