using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterName : MonoBehaviour
{
    [SerializeField] Damageable damageable;

    private void Awake()
    {
        try
        {
            damageable = gameObject.transform.parent.GetComponentInChildren<Damageable>();
        }
        catch
        {
            damageable = gameObject.transform.parent.GetComponent<Damageable>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (damageable != null)
        {
            if (!damageable.IsAlive)
            {
                Destroy(gameObject);
            }
        }
    }
}
