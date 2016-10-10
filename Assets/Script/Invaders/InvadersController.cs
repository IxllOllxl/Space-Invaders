using UnityEngine;
using System.Collections;
using UniRx;

public class InvadersController : MonoBehaviour {

    [Range(0.1f, 10)]
    [SerializeField]
    float speed;

    [SerializeField]
    float minPosition, maxPosition;

    [SerializeField]
    Transform group;

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
            if (minPosition > group.position.x)
            {
                MainThreadDispatcher.StartCoroutine(flyToMaxPosition());
                group.Translate(Vector3.down / 3);
                break;
            }
            group.Translate(Vector3.left * Time.deltaTime / (speed));
            yield return true;
        }
    }

    IEnumerator flyToMaxPosition()
    {

        while (true)
        {
            if (maxPosition < group.position.x)
            {
                MainThreadDispatcher.StartCoroutine(flyToMinPosition());
                group.Translate(Vector3.down/3);
                break;
            }
            group.Translate(Vector3.right * Time.deltaTime / (speed));
            yield return true;
        }
    }

}
