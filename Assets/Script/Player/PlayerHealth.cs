using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

namespace SpaceInvaders
{
    public class PlayerHealth : MonoBehaviour
    {
        [Range(1, 10)]
        public int currentHealth;
                                           
        public Slider healthSlider;                                       
        public AudioClip deathClip;                                 
        public float flashSpeed = 5f;                               
        public Color flashColour;

        List<SpriteRenderer> playerImageConstructor;

        Animator anim;                                              
        AudioSource playerAudio;                                    
        PlayerMovement playerMovement;                              
        PlayerShooting playerShooting;                              
        bool isDead;                                                
        bool damaged;                                               


        void Awake ()
        {
            anim = GetComponent <Animator> ();
            playerAudio = GameObject.FindGameObjectWithTag(Tag.Audio.BRICK).GetComponent<AudioSource>();
            playerMovement = GetComponent <PlayerMovement> ();
            playerShooting = GetComponentInChildren <PlayerShooting> ();
            healthSlider.maxValue = currentHealth;
            playerImageConstructor = new List<SpriteRenderer>(
                from item in GetComponentsInChildren<SpriteRenderer>()
                    where item.tag.Equals(Tag.BRICK) select item);
        }


        void Update ()
        {
            if(damaged)
            {
                foreach (var item in playerImageConstructor)
                    item.color = Color.red;
                StartCoroutine(RestoreColor());
            }
            damaged = false;
        }

        IEnumerator RestoreColor()
        {
            yield return new WaitForSeconds(0.1f);
            foreach (var item in playerImageConstructor)
                item.color = flashColour;
        }


        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals(Tag.BULLET_INVADER))
            {
                TakeDamage(collision.GetComponent<InvaderBullet>().Power);
            }
            else if (collision.gameObject.tag.Equals(Tag.INVADER))
            {
                TakeDamage(currentHealth);
            }
        }

        public void TakeDamage (int amount)
        {
            damaged = true;

            currentHealth -= amount;

            healthSlider.value = currentHealth;

            playerAudio.Play ();
            
            if (currentHealth <= 0 && !isDead)
            {
                Death ();
            }
        }


        void Death ()
        {
            isDead = true;

            anim.SetBool(Tag.Animation.DIE, true);

            playerAudio.clip = deathClip;
            playerAudio.Play ();

            Config.IsPaused = true;
            playerMovement.enabled = false;
            playerShooting.enabled = false;
        }
    }
}