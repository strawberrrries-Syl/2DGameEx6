using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    public AudioClip catSound;
    AudioSource catSource;

    public AudioClip dogSound;
    AudioSource dogSource;

    Rigidbody2D rb_fish;

    // Start is called before the first frame update
    void Start()
    {
        rb_fish = GetComponent<Rigidbody2D>();
        rb_fish.freezeRotation = true;
        catSource = GetComponent<AudioSource>();
        dogSource = GetComponent<AudioSource>();
        // TODO audio parts
    }

    void OnBecameInvisible()
    {
        // DONE
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // feed to cat
        if (collision.collider.CompareTag("Cat"))
        {
            //collider does not have an Orb component
            catSource.PlayOneShot(catSound, 1f);
        }
        else if (collision.collider.CompareTag("Dog"))
        {
            dogSource.PlayOneShot(dogSound, 1f);
        }
    }
}
