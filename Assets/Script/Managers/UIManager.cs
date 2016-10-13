using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UniRx;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SpaceInvaders
{
    public class UIManager : MonoBehaviour
    {
        Canvas canvas;
        Animator anim;

        void Awake()
        {
            canvas = GetComponent<Canvas>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }

        public void Pause()
        {
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
            Config.IsPaused = !Config.IsPaused;
            anim.SetBool(Tag.Animation.PAUSE, Config.IsPaused);
        }

        public void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}