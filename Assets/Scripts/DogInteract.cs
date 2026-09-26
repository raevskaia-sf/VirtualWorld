using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DogInteract : InteractPrompt
{
    public GameObject barkUI;
    public float barkDuration = 2f;
    private float barkTimer = 0f;

    protected override void Interact()
    {
        if (barkUI != null)
        {
            barkUI.SetActive(true);
            barkTimer = barkDuration;
        }
    }

    protected override void Update()
    {
        base.Update();

        if (barkTimer > 0)
        {
            barkTimer -= Time.deltaTime;
            if (barkTimer <= 0 && barkUI != null)
            {
                barkUI.SetActive(false);
            }
        }
    }
}