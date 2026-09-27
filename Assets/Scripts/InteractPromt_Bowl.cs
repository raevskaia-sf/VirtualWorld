using UnityEngine;
using TMPro;

public class InteractPrompt_Bowl : MonoBehaviour
{
    public GameObject promptUI;
    public float interactDistance = 3f;
    public KeyCode interactKey = KeyCode.E;

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        bool isNear = distance <= interactDistance;

        if (promptUI != null)
            promptUI.SetActive(isNear);

        if (isNear && Input.GetKeyDown(interactKey))
        {
            Interact();
        }
    }

    void Interact()
    {
        // Этот метод будет переопределён в BowlInteract
    }
}