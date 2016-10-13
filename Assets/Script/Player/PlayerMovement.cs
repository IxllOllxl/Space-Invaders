using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace SpaceInvaders
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(1f, 10)]
        [SerializeField]
        float speed;
        
        [SerializeField]
        float minPosition, maxPosition;

        void Update()
        {
            if(!Config.IsPaused)
                gameObject.transform.Translate
                    (new Vector3(Input.GetAxis(Tag.HORIZONTAL) * (speed / 10), 0, 0));

            if (gameObject.transform.position.x < minPosition)
            {
                gameObject.transform.position =
                    new Vector3(minPosition, 
                        gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else if (gameObject.transform.position.x > maxPosition)
            {
                gameObject.transform.position =
                    new Vector3(maxPosition, 
                        gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }
    }
}
