using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace SpaceInvaders
{
    public class PlayerShooting : MonoBehaviour
    {
        public static int CurrentCountShot = 0;

        [Range(1, 5)][SerializeField]
        int maxCountShot;

        [SerializeField]
        GameObject WeaponPrefab;

        [SerializeField]
        AudioSource gunAudio;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !Config.IsPaused)
                if (CurrentCountShot < maxCountShot)
                    Shoot();
        }

        void Shoot ()
        {
            CurrentCountShot++;
            gunAudio.Play();
            Instantiate(WeaponPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}