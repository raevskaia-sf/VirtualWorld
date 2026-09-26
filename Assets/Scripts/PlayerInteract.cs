using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f;
    public KeyCode interactKey = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                DoorInteract door = hit.collider.GetComponentInParent<DoorInteract>();
                if (door != null)
                {
                    //door.ToggleDoor();
                }
            }
        }
    }
}