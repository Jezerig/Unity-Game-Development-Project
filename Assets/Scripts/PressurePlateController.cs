using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public bool isPressed;
    public Animator animator;
    public string sceneName;
    public void LoadScene(string scene)
    {
        sceneName = scene;
    }

    public void PressPlate()
    {
        if(!isPressed)
        {
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
