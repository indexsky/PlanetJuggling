﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    // UI text to keep track of
    public Text scoreKeep;
    public Text ballBounce;
    public Text gameOver;

    // camera settings
    public float maxCameraZoom;
    public float minCameraZoom;

    public bool zoomed = false;

    public bool start = true;

    // int to be parsed into strings
    public int score;
    public int bounceCount;

    private SphereCollider sphere;

    // Use this for initialization
    void Start ()
    {
        // initial settings
        minCameraZoom = 8;
        maxCameraZoom = 12;
        score = 0;
        bounceCount = 0;

        // keep the main camera as always orthographic
        Camera.main.orthographic = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
        // update scores
        ballBounce.text = "Bounce Count: " + bounceCount.ToString();
        scoreKeep.text = "Score: " + score.ToString();

        if (zoomed == true)
        {
            zoomOut();
        }

        if (zoomed == false && start == false)
        {
            zoomIn();
        }
    }


    // handles zoom sloppily. It's a placeholder until we refine it.
    public void OnTriggerExit(Collider c)
    {
        if(c.tag == "Ball" && zoomed == false)
        {
            zoomed = true;
            start = false;
        }
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Ball" && zoomed == true)
        {
            zoomed = false;
        }
    }

    // handle zooming out and zooming in
    public void zoomOut()
    {
        for (float i = minCameraZoom; i < maxCameraZoom; i++)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, maxCameraZoom, Time.deltaTime);
        }
    }

    public void zoomIn()
    {
        for (float i = maxCameraZoom; i > minCameraZoom; i--)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, minCameraZoom, Time.deltaTime);
        }
    }
}
