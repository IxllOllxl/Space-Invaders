using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceInvaders
{
    public class InvaderAtack : MonoBehaviour
    {
        [SerializeField]
        GameObject WeaponPrefab;

        AudioSource gunAudio;
        
        void Awake()
        {
            gunAudio = GameObject.FindGameObjectWithTag(Tag.Audio.SHOT).GetComponent<AudioSource>();
        }

        public void Shoot()
        {
            gunAudio.Play();
            Instantiate(WeaponPrefab,gameObject.transform.position, Quaternion.Euler(0,0,0));
        }
    }
}
