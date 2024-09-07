using System.Net.Mime;
using System.Linq.Expressions;
using System.Dynamic;
using System.Timers;
using System.Threading;
using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skeleton : MonoBehaviour
{
    public Rigidbody2D skeletonrb;
    public GameObject player;
    public float x;
    public float y;
    public Rigidbody2D playerrb;

    // Start is called before the first frame update
    void Start()
    {
        skeletonrb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        skeletonrb.constraints = RigidbodyConstraints2D.None;
        skeletonrb.constraints = RigidbodyConstraints2D.FreezeRotation;
        


    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(5,5,5);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-5,5,5);
        }
        
        x = (player.transform.position.x - transform.position.x)/2;
        y = (player.transform.position.y - transform.position.y)/2;

        skeletonrb.velocity = new Vector2(x,y);
    }




}
