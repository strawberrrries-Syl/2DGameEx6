using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    Rigidbody2D m_rigid2D;

    public GameObject FishPrefab;
    public GameObject MeatPrefab;

    public GameObject Food;
    Rigidbody2D m_f_rigid2D;

    public AudioClip ShootSound;
    AudioSource ShootSource;

    float speed = 8f;
    float bulletSpeed = 2f;

    public GameObject WinPrefab;
    private GameObject WinObj;

    // Start is called before the first frame update
    void Start()
    {
        m_rigid2D = GetComponent<Rigidbody2D>();
        m_rigid2D.freezeRotation = true;
        /*Food = */generateFood();
        m_f_rigid2D = Food.GetComponent<Rigidbody2D>();
        m_f_rigid2D.freezeRotation = true;

        ShootSource = GetComponent<AudioSource>();


        WinObj = Instantiate(WinPrefab);
        WinObj.transform.position = new Vector2(0, 0);
        var rbwin = WinObj.GetComponent<SpriteRenderer>();
        rbwin.enabled = false;
    }


    int cNum = 10;
    int breakNum = 100;   // the number all the babies heart break
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown("c"))
            ResetGame();
    }
    void FixedUpdate()
    {
        if (MissedTracker.GetMissedNum() > breakNum)
        {
            ResetGame();
        }


        // win
        if (ProcessKeeper.GetProcessNum() > 1)
        {
            Status.FreezeStatus();
            var rbwin = WinObj.GetComponent<SpriteRenderer>();
            rbwin.enabled = true;
        }
        // control the hand
        var moveV = new Vector2(Input.GetAxis("Horizontal"), 0);
        moveV *= speed;
        m_rigid2D.AddForce(moveV);

        if (Input.GetAxis("Fire") == 1)
        {
            if (cNum > 50)
            {
                Fire();
                cNum = 0;
            }
        }
        cNum++;

        if (Food != null)
        { 
            Food.transform.position = transform.position + 1 * transform.up;
        }
        
    }

    private void ResetGame()
    {
        Debug.Log("reset");
        Destroy(WinObj);
        Status.ResetStatus();
        ProcessKeeper.ResetProcess();
        MissedTracker.ResetPoint();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnBecameInvisible()
    {
        Invoke("ResetGame", 1f);
    }

    // generate meat or fish randomly
    private void generateFood()
    {
        float flag = UnityEngine.Random.Range(-1, 1);
        if (flag < 0)   // meat
        {
            Food = Instantiate(MeatPrefab);
        }
        else
        {
            Food = Instantiate(FishPrefab);
        }
        Food.transform.position = transform.position; /*+1 * transform.up;*/
    }

    // shoot the food
    private void Fire() {

        ShootSource.PlayOneShot(ShootSound, 1f);
        Food.GetComponent<Rigidbody2D>().velocity = bulletSpeed * transform.up;
        generateFood();
        /*Food = generateFood();*/
        m_f_rigid2D = Food.GetComponent<Rigidbody2D>();
        m_f_rigid2D.freezeRotation = true;
    }
}
