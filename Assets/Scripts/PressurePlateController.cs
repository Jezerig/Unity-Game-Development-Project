using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public bool isPressed;
    public Animator animator;
    public string sceneName;
    AudioManager audioManager;

    // Source: https://www.youtube.com/watch?v=cLzG1HDcM4s

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Used when animation is run
    public void LoadScene(string scene)
    {
        sceneName = scene;
    }

    // sounds
    public void PressPlateSound()
    {
        audioManager.PlaySFX(audioManager.pressPressurePlate);
    }

    // Resets player health (after tutorial)
    public void ResetPlayerHealth()
    {
        GameData.PlayerHealth = 100;
    }

    public void PressPlate()
    {
        if(!isPressed)
        {
            isPressed = true;
            animator.Play("PressedPlate");
            if (string.IsNullOrEmpty(sceneName))
            {
                SceneController.instance.NextScene();
            } else
            {
                SceneController.instance.LoadScene(sceneName);
            }
        }
    }
}
