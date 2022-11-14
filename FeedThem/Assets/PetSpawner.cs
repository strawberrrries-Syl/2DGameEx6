using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    public GameObject CatPrefab;
    public GameObject DogPrefab;

    public GameObject StartPrefab;
    /*Rigidbody2D m_rigid2D;*/
    private GameObject StartPic;

    bool start = false;

    float moveSpeed = 1.5f;
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartPic = Instantiate(StartPrefab);
        StartPic.transform.position = new Vector3 (0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") && !start)
        {
            start = true;
            var rd = StartPic.GetComponent<SpriteRenderer>();
            rd.enabled = false;
        }

        if (start && Status.GetStatus())
        {
            if (Time.time > t)
            {
                geneNewPet(moveSpeed, 5.5f);
                t += Random.Range(3f, 5f);
                moveSpeed = Random.Range(0, 3);
            }
        }

    }

    void geneNewPet(float s, float y) {
        float pick = Random.Range(-1, 1);
        GameObject g;
        if (pick < 0)
        {
            g = Instantiate(CatPrefab);
        }
        else {
            g = Instantiate(DogPrefab);
        }

        var p = g.GetComponent<Pet>();
        var x = Random.Range(-8, 9);
        p.transform.position = new Vector2(x, y);
        var rb = g.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -moveSpeed);
        rb.freezeRotation = true;
        
    }
}
