using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace SpaceInvaders
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;

        Text scoreText;                      


        void Awake()
        {
            scoreText = GetComponent<Text>();
            
            score = 0;
        }


        void Update()
        {
            scoreText.text = "Score: " + score;
        }
    }
}