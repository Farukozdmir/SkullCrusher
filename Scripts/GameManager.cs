using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator skeletonAnimator;
    public Rigidbody2D skelet;
    public GameObject go;
    public int score = 0;
    public Text scoreText;
    public Text gameoverScore;
    public BoxCollider2D sword;
    
    // Start is called before the first frame update
    void Start()
    {

        
        Vector2 pos = new Vector2 (Random.Range(11,14),Random.Range(2,-3));
        sword = GetComponent<BoxCollider2D>();
        sword.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    



    private void OnTriggerStay2D(Collider2D other) 
    {
        
        if (other.tag == "Enemy")
        {                          
            skeletonAnimator = other.gameObject.GetComponent<Animator>();
            skeletonAnimator.SetTrigger("kill");
            skelet = other.gameObject.GetComponent<Rigidbody2D>();
            skelet.constraints = RigidbodyConstraints2D.FreezePosition;
            Vector2 pos = new Vector2 (Random.Range(11,14),Random.Range(2,-3));
            Instantiate (go,pos,go.transform.rotation);
            Destroy(other);
            score +=1;
            scoreText.text = "Score: "+ score;
            gameoverScore.text = ("Score: "+score);
            
            if (score == 15)
        {
            
            Instantiate (go,pos,go.transform.rotation);
            
        }          
        
        }
    }

    


}