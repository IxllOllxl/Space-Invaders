using System.Collections;
using UniRx;
using UnityEngine;

namespace SpaceInvaders
{
    public class InvadersMovement : MonoBehaviour
    {
        [SerializeField]
        PlayerHealth playerHealth;

        [Range(0.1f, 2)]
        [SerializeField]
        float speed;

        [SerializeField]
        float minPosition, maxPosition;
        
        [SerializeField]
        Transform enemies;

        void Start()
        {
            StartCoroutine(
                new System.Random().Next(2) == 1 ?
                  flyToMinPosition() : flyToMaxPosition());
        }

        IEnumerator flyToMinPosition()
        {
            while (true)
            {
                if (!Config.IsPaused)
                {
                    if (minPosition > enemies.position.x)
                    {
                        MainThreadDispatcher.StartCoroutine(flyToMaxPosition());
                        enemies.Translate(Vector3.down / 3);
                        break;
                    }
                    if (!Config.IsPaused)
                        enemies.Translate(Vector3.left * Time.deltaTime * speed);
                }
                yield return true;
            }
        }

        IEnumerator flyToMaxPosition()
        {
            while (true)
            {
                if (!Config.IsPaused)
                {
                    if (maxPosition < enemies.position.x)
                    {
                        MainThreadDispatcher.StartCoroutine(flyToMinPosition());
                        enemies.Translate(Vector3.down / 3);
                        break;
                    }
                    if (!Config.IsPaused)
                        enemies.Translate(Vector3.right * Time.deltaTime * speed);
                }
                yield return true;
            }
        }
    }
}