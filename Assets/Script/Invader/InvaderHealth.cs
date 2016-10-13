using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceInvaders
{
    public class InvaderHealth : MonoBehaviour
    {
        [Range(1, 10)]
        public int currentHealth;

        [Range(100, 1000)]
        public int score;
        
        public AudioClip deathClip;
       
        Animator anim;
        AudioSource playerAudio;

        bool isDead;
        
        void Awake()
        {
            anim = GetComponent<Animator>();
            playerAudio = GameObject.FindGameObjectWithTag(Tag.Audio.BRICK).GetComponent<AudioSource>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals(Tag.BULLET))
            {
                TakeDamage(collision.GetComponent<PlayerBullet>().Power);
            }
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            
            playerAudio.Play();

            if (currentHealth <= 0 && !isDead)
                Death();
        }
        
        void Death()
        {
            isDead = true;
            ScoreManager.score += score;
            anim.SetTrigger(Tag.Animation.DIE);

            playerAudio.clip = deathClip;
            playerAudio.Play();

        }

        //Вызывается по завершению анимации смерти
        void DestroyInvader()
        {
            Destroy(gameObject);
        }
    }
}
