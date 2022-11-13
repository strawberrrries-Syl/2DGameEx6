using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
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

    void DestroySelf() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var rb = GetComponent<Rigidbody2D>();
        var pet = collision.collider.GetComponent<Pet>();
        if (rb.velocity.y < 0.1)
        {
            return;
        }
        // feed to cat
        if (collision.collider.CompareTag("Cat"))
        {
            catSource.PlayOneShot(catSound, 1f);
            Invoke("DestroySelf", 0.3f);
        }
        else if (collision.collider.CompareTag("Dog"))
        {
            dogSource.PlayOneShot(dogSound, 1f);
            Invoke("DestroySelf", 0.3f);
        }
    }

}
