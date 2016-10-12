using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    int life;

    [SerializeField]
    GameObject bulletPrefab;

    BulletInvader bullet;

    void Start()
    {
       StartCoroutine(RandomShot());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tag.BULLET))
        {
            life--;
            if (life == 0)
            {
                StopCoroutine(RandomShot());
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator RandomShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            if (bullet != null && bullet.IsFly)
                yield return true;
            bullet = bullet ?? Instantiate(bulletPrefab).GetComponent<BulletInvader>();
            bullet.Shot(transform.gameObject.transform);
        }
    }
}
