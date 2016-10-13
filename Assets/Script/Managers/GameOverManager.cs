using UnityEngine;

namespace SpaceInvaders
{
    public class GameOverManager : MonoBehaviour
    {
        [SerializeField]
        PlayerHealth playerHealth;       


        Animator anim;                          


        void Awake ()
        {
            anim = GetComponent <Animator> ();
        }


        void Update ()
        {
            if(playerHealth.currentHealth <= 0)
            {
                anim.SetTrigger ("GameOver");
            }
        }
    }
}