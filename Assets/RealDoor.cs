using UnityEngine;

public class RealDoor : MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 3f;
    
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private AudioSource doorSound;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0); 
        
        // Ищем AudioSource на этом же объекте автоматически
        doorSound = GetComponent<AudioSource>(); 
    }

    public void Interact()
    {
        isOpen = !isOpen;
        Debug.Log("Дверь нажата! isOpen: " + isOpen);
        
        if (doorSound != null) 
        {
            doorSound.Play();
        }
    }

    void Update()
    {
        if (isOpen)
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * speed);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * speed);
    }
}