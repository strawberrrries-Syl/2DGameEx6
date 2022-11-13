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
        Food = generateFood();
        m_f_rigid2D = Food.GetComponent<Rigidbody2D>();
        m_f_rigid2D.freezeRotation = true;
        ShootSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // control the hand
        var moveV = new Vector2(Input.GetAxis("Horizontal"), 0);
        moveV *= speed;
        m_rigid2D.AddForce(moveV);
        /*m_f_rigid2D.position = m_rigid2D.position;*/
        Food.transform.position = transform.position + 1 * transform.up;

        if (Input.GetAxis("Fire") == 1)
        {
            Fire();
            Food = generateFood();
            m_f_rigid2D = Food.GetComponent<Rigidbody2D>();
            m_f_rigid2D.freezeRotation = true;
        }
    }

    // generate meat or fish randomly
    private GameObject generateFood() {
        GameObject food;
        float flag = Random.Range(-1, 1);
        Debug.Log(flag);
        if (flag < 0)   // meat
        {
            food = Instantiate(MeatPrefab);
        }
        else {
            food = Instantiate(FishPrefab);
        }
        food.transform.position = transform.position + 1 * transform.up;
        return food;
    }

    // shoot the food
    private void Fire() {
        /*ShootSource.PlayOneShot(ShootSound, 1f);*/
        Food.GetComponent<Rigidbody2D>().velocity = bulletSpeed * transform.up;
    }
}
