using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public GameObject promptUI;
    public float openAngle = 90f;
    public float speed = 2f;
    public float interactDistance = 3f;
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
        if (promptUI != null)
            promptUI.SetActive(false);
    }

    void Update()
    {
        if (isOpen)
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * speed);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * speed);

        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        bool isNear = distance <= interactDistance;

        if (promptUI != null)
            promptUI.SetActive(isNear);

        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
        }
    }
}