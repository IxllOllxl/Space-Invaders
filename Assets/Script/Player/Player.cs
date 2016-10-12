using System;
using UnityEngine;

[Serializable]
public class Player
{
    [Range(1f, 10)]
    [SerializeField]
    float speed;

    [SerializeField]
    [Range(1, 10)]
    int life;

    public int Life { get { return life; } }

    public float Speed { get { return speed; } }

    [SerializeField]
    Transform player;

    public Transform transform { get { return player; } }

    public void Hit(int power)
    {
        life -= power;
    }
}
