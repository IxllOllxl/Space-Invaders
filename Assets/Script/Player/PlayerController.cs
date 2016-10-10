using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    [SerializeField]
    float minPosition, maxPosition;

    [Range(1f, 10)]
    [SerializeField]
    float speed;
    
    [SerializeField]
    Transform player;
    
	// Update is called once per frame
	void Update () {

        player.Translate(new Vector3(Input.GetAxis("Horizontal") * (speed/10),0,0));

        // проверка выхода за границы
        if (player.position.x < minPosition)
        {
            player.position = new Vector3(minPosition, player.position.y, player.position.z);
        }
        if (player.position.x > maxPosition)
        {
            player.position = new Vector3(maxPosition, player.position.y, player.position.z);
        }
    }
}
