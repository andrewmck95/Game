

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Protagonist: MonoBehaviour
{

    // needed for next level variable
    [SerializeField] private string nextLevel;

    //delay time for next level
    public float waitTime = 5;

    // Protagonist's current health
    public int curHealth;

    // Protagonist's maximum health
    public int maxHealth = 5;

    // Shard count
    public int shardCount;

    // Count text
    public Text shardCountText;

    // Level complete text
    public Text lvlComplete;

    // Protagonist speed
    public float speed;

    // For moving protagonist
    private Rigidbody2D rb;

    // Used to change Link animations
    Animator animator;

    // References to weapon and sword game objects
    GameObject weaponGO;
    GameObject swordGO;

    public enum AttkDir
    {
        LEFT,RIGHT,UP,DOWN
    }

    public AttkDir atkDir;

    // Makes sure components have been created when the 
    // game starts
    void Awake()
    {
        // set current health to max health
        curHealth = maxHealth;

        // initialise shard count
        shardCount = 0;
        // initialise shard count text upon wake
        SetShardCountText();

        // initialise level complete text
        lvlComplete.text = "";

        // Get Links Rigidbody
        rb = GetComponent<Rigidbody2D>();

        weaponGO = GameObject.Find("Weapon");
        swordGO = GameObject.Find("Sword");

        swordGO.GetComponent<Renderer>().enabled = false;

        // Get SoundManager reference
        // soundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();

        // Get Animator reference
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        // Get keyboard input
        float horzMove = Input.GetAxisRaw("Horizontal");
        float vertMove = Input.GetAxisRaw("Vertical");

        // update the sword collider to false
        swordGO.GetComponent<Collider2D>().enabled = false;

        rb.velocity = new Vector2(horzMove * speed, vertMove * speed);

        // NEW STUFF 1
        if (Input.GetKey("w"))
        {
            atkDir = AttkDir.UP;
            if (Input.GetKey("w"))
            {

                animator.Play("protag_WALKUP");
                atkDir = AttkDir.UP;
            }
            // NEW STUFF 1
        }
        else
        {
            if (Input.GetKey("s"))
            {

                if (Input.GetKey("s"))
                {

                    animator.Play("protag_WALKDOWN");
                    atkDir = AttkDir.DOWN;

                }
            }
            else
            {
                // sets sword direction back to down after an attack
                atkDir = AttkDir.DOWN;

                if (Input.GetKey("d"))
                {

                    animator.Play("protag_WALKRIGHT");
                    atkDir = AttkDir.RIGHT;

                }

                else if (Input.GetKey("a"))
                {

                    animator.Play("protag_WALKLEFT");
                    atkDir = AttkDir.LEFT;
                }
                
            }

            // Switches back to the Idle position if a key is released
            if (Input.GetKeyUp("s"))
            {

                animator.Play("protag_IDLE");
                swordGO.GetComponent<Renderer>().enabled = false;

            }

        }

        if (Input.GetKey(KeyCode.Return))
        {
            ProtagAttack();
            swordGO.GetComponent<Collider2D>().enabled = true;
        }
        // checks conditions to end current level and move to next scene
        EndLevel();

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        
        if (curHealth <= 0)
        {
            Die();
        }
        
    }

    

    void ProtagAttack()
    {
        switch (atkDir)
        {
            case AttkDir.DOWN:
                {
                    StartCoroutine(AnimateSword(0f, 0f));
                    break;
                }
            case AttkDir.UP:
                {
                    StartCoroutine(AnimateSword(180f, 0f));
                    break;
                }
            case AttkDir.LEFT:
                {
                    StartCoroutine(AnimateSword(-90f, -1.6f));
                    break;
                }
            case AttkDir.RIGHT:
                {
                    StartCoroutine(AnimateSword(90f, 0f));
                    break;
                }
        }
    }

    IEnumerator AnimateSword(float rotation, float vertMove)
    {
        // play slash sound when sword animates
        FindObjectOfType<AudioManager>().Play("Slash 2");

        swordGO.GetComponent<Renderer>().enabled = true;

        weaponGO.transform.rotation = Quaternion.Euler(0, 0, rotation);

        weaponGO.transform.position = new Vector3(transform.position.x, transform.position.y + vertMove, transform.position.z);

        yield return new WaitForSeconds(0.3f);
        swordGO.GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shard")){
            // add to shard count
            shardCount = shardCount + 1;
            SetShardCountText();
        }
        
    }
    // waits a few seconds before loading next scene
    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("StartMenu");
    }

    void SetShardCountText()
    {
        // this function directly affects the counter UI displayed on screen
        shardCountText.text = "" + shardCount.ToString();
    }

    // text that shows that level has been completed
    void SetLevelCompleteText()
    {
        lvlComplete.text = "Level Completed!";
    }
    // checks conditions to end level. Starts a coroutine to implement next level delay
    void EndLevel()
    {
        if ((GameObject.FindWithTag("Shard") == null) && (GameObject.FindWithTag("Villain") == null))
        {
            SetLevelCompleteText();
            StartCoroutine(WaitAndLoadScene());
        }
    }

void Die()
    {
        // restart the scene if protagonist dies
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
