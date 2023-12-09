using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Suazo,Angel & Johnson,Ethan]
 * Last Updated: [12/08/2023]
 * [This script handles the boss movement]
 */

public class Boss : MonoBehaviour
{
    public int lives = 20;
    private bool waiting = false;
    private bool goingDown;
    private bool goingRight = false;
    public float speed;
    private int count;
    private int bounceTimes;

    private float dist;
    private float distMin = -8;
    private float distMax = 8;
    private Vector3 temp;

    public GameObject bossPrefab;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
