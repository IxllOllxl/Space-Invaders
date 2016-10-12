using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    BulletPlayer[] bullets;

    [SerializeField]
    Player player;

    [SerializeField]
    float minPosition, maxPosition;

    
	void Update ()
    {
        ControllPlayer();

        CheckingShotPlayer();
    }

    private void ControllPlayer()
    {
        player.transform.Translate
            (new Vector3(Input.GetAxis(Tag.HORIZONTAL) * (player.Speed / 10), 0, 0));

        CheckingFlyingBorder();
    }

    private void CheckingShotPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (BulletPlayer bullet in bullets)
            {
                if (!bullet.IsFly)
                {
                    bullet.Shot(player.transform);
                    break;
                }
            }
        }
    }

    //Проверка вылета за границы доступного
    private void CheckingFlyingBorder()
    {
        if (player.transform.position.x < minPosition)
        {
            player.transform.position =
                new Vector3(minPosition, player.transform.position.y, player.transform.position.z);
        }
        if (player.transform.position.x > maxPosition)
        {
            player.transform.position =
                new Vector3(maxPosition, player.transform.position.y, player.transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tag.BULLET_INVADER) ||
            collision.gameObject.tag.Equals(Tag.INVADER))
        {
            player.Hit(1);
            if (player.Life <= 0)
                Destroy(this.gameObject);
        }
    }
}
