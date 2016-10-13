using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField][Range(1,10)]
    public int currentHealth;

    SpriteRenderer damageImage;
    [Range(1,5)][SerializeField]
    float flashSpeed = 5f;
    [SerializeField]
    Color flashColour;
    
    [SerializeField]
    AudioSource brickAudio;

    bool damaged = false;

    void Awake()
    {
        damageImage = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (damaged)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            damageImage.color = flashColour;
        }
        damaged = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tag.BULLET) ||
            collision.gameObject.tag.Equals(Tag.BULLET_INVADER) || 
            collision.gameObject.tag.Equals(Tag.INVADER))
        {
            damaged = true;
            currentHealth--;
            if(currentHealth <= 0)
                Destroy(gameObject);
        }
    }
}
