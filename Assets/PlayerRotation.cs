using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;
        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}