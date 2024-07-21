using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FadeRemoveBehaviour : StateMachineBehaviour
{
    /* Source: https://www.youtube.com/watch?v=KtPxBe1f8Kg */

    public float fadeTime = 2f;
    private float TimeElapsed = 0f;
    SpriteRenderer spriteRenderer;
    GameObject target;
    Color startColor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TimeElapsed = 0f;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        target = animator.transform.parent.gameObject;
        startColor = spriteRenderer.color;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TimeElapsed += Time.deltaTime;

        float newAlpha = startColor.a * (1 - (TimeElapsed / fadeTime));

        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

        if (TimeElapsed > fadeTime)
        {
            Destroy(target);
        }
    }
}
