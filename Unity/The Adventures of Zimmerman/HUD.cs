using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HealthBars;
    public Image HealthUI;
    private Protagonist protagonist;

    void Start()
    {
        protagonist = GameObject.FindGameObjectWithTag("Protagonist").GetComponent<Protagonist>();
    }

    void Update()
    {
        HealthUI.sprite = HealthBars[protagonist.curHealth];
    }
}
