using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // Source: https://www.youtube.com/watch?v=cLzG1HDcM4s

    public bool isInArea;
    public UnityEvent interactAction;

    // Update is called once per frame
    void Update()
    {
        if (isInArea)
        {
            interactAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInArea = true;
        }
    }
}
