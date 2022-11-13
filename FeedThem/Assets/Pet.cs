using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public Sprite Cat1;
    public Sprite Cat2;
    public Sprite Cat3;
    public Sprite Cat4;
    public Sprite Dog1;
    public Sprite Dog2;
    public Sprite Dog3;
    public Sprite Dog4;

    SpriteRenderer Sprite;

    bool counted = false;
    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        int pick = Random.Range(0, 5);
        if (tag == "Cat")
        {
            if (pick == 0)
            {
                Sprite.sprite = Cat1;
            } else if (pick == 1) {
                Sprite.sprite = Cat2;
            }
            else if (pick == 2)
            {
                Sprite.sprite = Cat3;
            }
            else if (pick == 3)
            {
                Sprite.sprite = Cat4;
            }
        } else if (tag == "Dog") {
            if (pick == 0)
            {
                Sprite.sprite = Dog1;
            }
            else if (pick == 1)
            {
                Sprite.sprite = Dog2;
            }
            else if (pick == 2)
            {
                Sprite.sprite = Dog3;
            }
            else if (pick == 3)
            {
                Sprite.sprite = Dog4;
            }
        }
    }

    void OnBecameInvisible()
    {
        ScoreKeeper.ScorePoints(-2);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        // feed to cat
        if (collision.collider.CompareTag("Meat") || collision.collider.CompareTag("Fish"))
        {
            ProcessKeeper.Process(1);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -4 && !counted)
        {
            counted = true;
            Debug.Log("position: " + transform.position.y);
            MissedTracker.MissedPoint(1);
        }
    }
}
