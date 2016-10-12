using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Brick : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tag.BULLET) ||
            collision.gameObject.tag.Equals(Tag.BULLET_INVADER) || 
            collision.gameObject.tag.Equals(Tag.INVADER))
                Destroy(gameObject);
    }
}
