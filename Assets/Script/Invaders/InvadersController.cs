using System;
using UnityEngine;
using System.Collections;
using UniRx;
using System.Collections.Generic;

public class InvadersController : MonoBehaviour {

    [Serializable]
    class FlyingController
    {
        [Range(0.1f, 2)]
        [SerializeField]
        float speed;

        public float Speed { get { return speed; } }

        [SerializeField]
        float minPosition, maxPosition;

        public float MinPosition { get { return minPosition; } }
        public float MaxPosition { get { return maxPosition; } }

        [SerializeField]
        Transform group;

        public Transform transform { get { return group; } }
    }
    [SerializeField]
    FlyingController flying;
    
    void Start()
    {
        MainThreadDispatcher.StartCoroutine(
            new System.Random().Next(2) == 1 ?
              flyToMinPosition() : flyToMaxPosition());
    }


    IEnumerator flyToMinPosition()
    {
        while (true)
        {
            if (flying.MinPosition > flying.transform.position.x)
            {
                MainThreadDispatcher.StartCoroutine(flyToMaxPosition());
                flying.transform.Translate(Vector3.down / 3);
                break;
            }
            if(Config.IsPlaying)
                flying.transform.Translate(Vector3.left * Time.deltaTime * (flying.Speed));
            yield return true;
        }
    }
    IEnumerator flyToMaxPosition()
    {
        while (true)
        {
            if (flying.MaxPosition < flying.transform.position.x)
            {
                MainThreadDispatcher.StartCoroutine(flyToMinPosition());
                flying.transform.Translate(Vector3.down/3);
                break;
            }
            if(Config.IsPlaying)
                flying.transform.Translate(Vector3.right * Time.deltaTime * (flying.Speed));
            yield return true;
        }
    }
}
