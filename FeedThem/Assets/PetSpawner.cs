using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    public GameObject CatPrefab;
    public GameObject DogPrefab;

    float moveSpeed = 1.5f;
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > t)
        {
            geneNewPet(moveSpeed, 5.5f);
            t += Random.Range(1.5f, 2.5f);
            moveSpeed = Random.Range(1, 3);
        }
    }

    void geneNewPet(float s, float y) {
        float pick = Random.Range(0, 1);
        GameObject g;
        if (pick < 0.5f)
        {
            g = Instantiate(CatPrefab);

        }
        else {
            g = Instantiate(DogPrefab);
        }

        var p = g.GetComponent<Pet>();
        var x = Random.Range(-8, 8);
        p.transform.position = new Vector2(x, y);
        var rb = g.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -moveSpeed);
        
    }
}
