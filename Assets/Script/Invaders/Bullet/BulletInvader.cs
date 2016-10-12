﻿using System;
using UnityEngine;
using UniRx;
using System.Collections;

public class BulletInvader : MonoBehaviour
{
    [SerializeField]
    float minHeightFly;

    [SerializeField]
    [Range(1, 10)]
    float speed;

    [SerializeField]
    Transform bullet;

    bool isFly = false;

    public bool IsFly
    {
        get { return isFly; }
    }

    public void Shot(Transform player)
    {
        isFly = true;
        bullet.transform.position = player.transform.position;
        MainThreadDispatcher.StartCoroutine(fly());
    }

    public void StopFly()
    {
        isFly = false;
        bullet.transform.position = new Vector3(-100, 100, 0);
    }

    IEnumerator fly()
    {
        while (isFly)
        {
            if (minHeightFly > bullet.position.y)
                break;
            if(Config.IsPlaying)
                bullet.Translate(Vector3.down * Time.deltaTime * (speed));
            yield return true;
        }
        StopFly();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tag.PLAYER) ||
            collision.gameObject.tag.Equals(Tag.WALL) ||
            collision.gameObject.tag.Equals(Tag.BULLET))
                StopFly();
    }
}
