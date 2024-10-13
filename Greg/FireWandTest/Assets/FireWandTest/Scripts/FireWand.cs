using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireWand : MonoBehaviour
{
    public InputActionReference triggerInputActionReference;
    [Header("1 is max pressed. 0 is not pressed.")]
    [SerializeField] private float triggerThreshold = 1f;
    [SerializeField] private GameObject spellPrefab;
    public string objectName;
    private bool triggerPressedRecently = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for trigger pull
        if (triggerInputActionReference.action.ReadValue<float>() >= triggerThreshold)
        {
            // If trigger is pulled log it
            //Debug.Log(objectName + "'s trigger pulled");

            // If trigger hasn't been pulled recently, spawn a spell prefab
            if (!triggerPressedRecently)
            {
                SpawnSpell();
                triggerPressedRecently = true;
            }
        }

        // Reset trigger pulled recently when the trigger is released
        if (triggerPressedRecently && triggerInputActionReference.action.ReadValue<float>() == 0)
        {
            triggerPressedRecently = false;
        }
    }
    private void SpawnSpell()
    {
        Vector3 spawnPoint = transform.position; // We'll use the parent's transform for now
        GameObject spell = Instantiate(spellPrefab, spawnPoint, transform.rotation);
        //spell.transform.SetParent(this.transform);
    }
}
