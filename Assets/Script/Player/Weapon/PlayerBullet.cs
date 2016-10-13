using System;
using UnityEngine;
using UniRx;
using System.Collections;

namespace SpaceInvaders
{
    public class PlayerBullet : MonoBehaviour
    {
        [SerializeField]
        [Range(1, 10)]
        float speed;

        [SerializeField]
        [Range(1, 10)]
        int power;

        public int Power { get { return power; } }

        void Update()
        {
            if(!Config.IsPaused)
                gameObject.transform.Translate(Vector3.up * Time.deltaTime * (speed));
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals(Tag.INVADER) ||
                collision.gameObject.tag.Equals(Tag.WALL) ||
                collision.gameObject.tag.Equals(Tag.BULLET_INVADER))
            {
                PlayerShooting.CurrentCountShot--;
                Destroy(transform.gameObject);
            }
        }
    }
}

