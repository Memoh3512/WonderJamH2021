﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    private float timeBetweenCircles = 0.5f;
    private float timeLeft;
    private float numberOfCircles = 5;
    private float halfMaxHeight = 4;
    private float halfMaxWidth = 3;
    SpriteRenderer[] sr = new SpriteRenderer[2];

    // Update is called once per frame
    private void Start()
    {
        timeLeft = timeBetweenCircles;
        sr[0] = transform.parent.GetChild(0).GetComponent<SpriteRenderer>();
        sr[1] = transform.parent.GetChild(1).GetComponent<SpriteRenderer>();

    }
    void Update()
    {

        if(timeLeft <= 0)
        {
            if (numberOfCircles > 0)
            {
                SpawnCircle();
                numberOfCircles--;
                timeLeft = timeBetweenCircles;
            }
            else
            {
                if (sr[0].color.a > 0)
                {
                    sr[0].color -= new Color(0, 0, 0, Time.deltaTime);
                    sr[1].color -= new Color(0, 0, 0, Time.deltaTime);
                    for(int i = 0; i < transform.childCount; i++)
                    {
                        transform.GetChild(i).GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, Time.deltaTime);
                    }
                }
                else
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }        
    }


    void SpawnCircle()
    {
        Vector3 position = new Vector3(Random.Range(-halfMaxWidth, halfMaxWidth), Random.Range(-halfMaxHeight, halfMaxHeight));
        GameObject circle = Instantiate((GameObject)Resources.Load("Events/Circle"));
        circle.transform.parent = gameObject.transform;
        circle.transform.position = transform.position + position;
    }
}