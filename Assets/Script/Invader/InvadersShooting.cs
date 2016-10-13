using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceInvaders
{
    public class InvadersShooting : MonoBehaviour
    {
        [SerializeField][Range(0.1f, 1.0f)]
        float waitShot;
        
        List<InvaderAtack> invaders;


        [SerializeField]
        PlayerHealth playerHealth;

        void Start()
        {
            invaders = new List<InvaderAtack>(
                from invader in GameObject.FindGameObjectsWithTag(Tag.INVADER)
                             select invader.GetComponent<InvaderAtack>());

            StartCoroutine(Shooting());
        }

        IEnumerator Shooting()
        {
            while (invaders.Count != 0)
            {
                if (!Config.IsPaused)
                {
                    int rand = UnityEngine.Random.Range(0, invaders.Count);
                    while (invaders[rand] == null)
                    {
                        invaders.RemoveAt(rand);
                        rand = UnityEngine.Random.Range(0, invaders.Count);
                    }
                    invaders[rand].Shoot();
                    yield return new WaitForSeconds(waitShot);
                }
                yield return true;
            }
        }
    }
}
