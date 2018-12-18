using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour
{
    [Header("Set in inspector")]

    //prefab for instantiating apples
    public GameObject applePrefab_r;
    public GameObject applePrefab_g;
    public GameObject applePrefab_y;


    //speed of Apples
    public float speed = 1f;
    //public float greenSpeed = 3f;
    //public float yellowSpeed = 5f;

    //Distance where AppleTree turns
    public float leftAndRight = 10f;

    //ApplTree change in direction
    public float changeDirect = 0.2f;

    //rate that apples drop
    public float appleDropTime = 1.2f;
    public float appleDropTimeG = 0.8f;
    public float appleDropTimeY = 0.5f;

    public int score;

    public bool dropR = true;
    public bool dropG;
    public bool dropY;

    public Text scoreGT;

    // Use this for initialization
    void Start()
    {
        Invoke("DropAppleRed", 2f);
        Invoke("DropAppleGreen", 10f);
        Invoke("DropAppleYellow", 10f);
    }

    void DropAppleRed()
    {
        if (dropR)
        {
            GameObject Apple = Instantiate<GameObject>(applePrefab_r);
            Apple.transform.position = transform.position;
            Invoke("DropAppleRed", appleDropTime);
        }
    }

    void DropAppleGreen()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        score = int.Parse(scoreGT.text);

        if (score >= 1000 & score < 2000)
        {
            dropG = true;
            dropR = false;
            dropY = false;
        }

        if (dropG)
        {
            GameObject GreenApple = Instantiate<GameObject>(applePrefab_g);
            GreenApple.transform.position = transform.position;
        }
        Invoke("DropAppleGreen", appleDropTimeG);
    }

    void DropAppleYellow()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        score = int.Parse(scoreGT.text);

        if (score >= 2000)
        {
            dropY = true;
            dropR = false;
            dropG = false;
        }

        if (dropY)
        {
            GameObject YellowApple = Instantiate<GameObject>(applePrefab_y);
            YellowApple.transform.position = transform.position;
        }
        Invoke("DropAppleYellow", appleDropTimeY);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //change direction
        if (pos.x < -leftAndRight)
        {
            speed = Mathf.Abs(speed); // change diection
        }
        else if (pos.x > leftAndRight)
        {
            speed = -Mathf.Abs(speed); //change direction
        }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirect)
        {
            speed *= -1;
        }
    }

}

