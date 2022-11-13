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

    float speed = 10f;
    float bulletSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigid2D = GetComponent<Rigidbody2D>();
        m_rigid2D.freezeRotation = true;
        /*Food = */generateFood();
        m_f_rigid2D = Food.GetComponent<Rigidbody2D>();
        m_f_rigid2D.freezeRotation = true;

        ShootSource = GetComponent<AudioSource>();
    }


    int cNum = 10;
    // Update is called once per frame
    void FixedUpdate()
    {
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
        
        Food.transform.position = transform.position + 1 * transform.up;
    }

    private void ResetGame()
    {
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
