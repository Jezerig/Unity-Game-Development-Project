using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    // Source: https://www.youtube.com/watch?v=_lREXfAMUcE

    [SerializeField] private Slider slider;

    // Updates slider value based on character health
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
       slider.value = currentHealth / maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        // Stops health bar from rotating and moving
        transform.parent.rotation = Camera.main.transform.rotation;
        if (slider.value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
