using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public bool isPressed;
    public Animator animator;
    public string sceneName;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void LoadScene(string scene)
    {
        sceneName = scene;
    }

    public void PressPlateSound()
    {
        audioManager.PlaySFX(audioManager.pressPressurePlate);
    }
    public void ResetPlayerHealth()
    {
        GameData.PlayerHealth = 100;
    }

    public void PressPlate()
    {
        if(!isPressed)
        {
            PressPlateSound();
            isPressed = true;
            Debug.Log("Pressure plate pressed.");
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
