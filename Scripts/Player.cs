using System.Net.Mime;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float velocity;
    private int a;
    Animator playerAnimator;
    Animator skeletonAnim;
    public Rigidbody2D skeletonrb;
    public Text scoreText;
    public GameObject gameoverCanvas;
    public Button btn;
    public Scene SampleScene;
    public Button btnexit;
    private float health;
    public Slider healthbar;
    public Text healthtext;
    private int healthtexticin = 100;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();  
        btn.onClick.AddListener(TaskOnClick);
        rb2d = GetComponent<Rigidbody2D>();
        btnexit.onClick.AddListener(oyundancik);
        healthbar = GameObject.Find("healthbar").GetComponent<Slider>();
        health = 1;

    }

    // Update is called once per frame
    void Update()
    {

            if(Input.GetKey("w"))
        {
            if(transform.position.y > 2.55)
            {
                rb2d.velocity = new Vector2(0,0);
            }
            else
            {
                playerAnimator.SetBool("Run",true);
                rb2d.velocity = new Vector2(0,velocity);
            }
            
        }
            
        else if(Input.GetKey("a"))
        {          
            if(transform.position.x < -7.5)
            {
                rb2d.velocity = new Vector2(0,0);
            }
            else
            {
                rb2d.velocity = new Vector2(-velocity,0);
                cevir(-5);
                playerAnimator.SetBool("Run",true);
            }
            
        }
        
        else if(Input.GetKey("d"))
        {          
            if(transform.position.x > 7.5)
            {
                rb2d.velocity = new Vector2(0,0);
            }
            else
            {
                cevir(5);
                playerAnimator.SetBool("Run",true);
                rb2d.velocity = new Vector2(velocity,0);
            }
        }
        
        else if(Input.GetKey("s"))
        {
            if(transform.position.y < -2.2)
            {
                rb2d.velocity = new Vector2(0,0);
            }
            else
            {
                playerAnimator.SetBool("Run",true);
                rb2d.velocity = new Vector2(0,-velocity);
            }
            
        }

        else
        {
            rb2d.velocity = new Vector2(0,0);
            playerAnimator.SetBool("Run",false);
        }
        

        if(Input.GetKeyDown("space"))
        {
        
            playerAnimator.SetTrigger("Atack");
            rb2d.velocity = new Vector2(0,0);
        }



      
    }

    void cevir(int a)
    {

        gameObject.transform.localScale = new Vector3(a,5,5);
    }

        private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Enemy")
        {   
            //skeletonrb = other.gameObject.GetComponent<Rigidbody2D>();
            skeletonAnim = other.gameObject.GetComponent<Animator>();
            skeletonAnim.SetTrigger("skeletonAttack");
            rb2d = GetComponent<Rigidbody2D>();
            //rb2d.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
            //skeletonrb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation; 
            health = health - 0.1f;
            healthbar.value = health;
            

            if(health <= 0)
            {
                playerAnimator.SetTrigger("death");
                Invoke("gameOver", 1.5f);
                Destroy(other.gameObject,2);
            }
            if (healthtexticin > 0)
            {
                healthtexticin = healthtexticin - 10;
                healthtext.text = ""+ healthtexticin;
            }
                   
        }
        
    }

        public void gameOver()
    {
        
        Time.timeScale = 0;
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject i in gos) 
        {
            Destroy(i);
        }

        gameoverCanvas.SetActive(true);
        scoreText.enabled = false;

        
    }

    void TaskOnClick()
    {
		SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
	}

    void oyundancik()
    {
        Application.Quit();
    }





}