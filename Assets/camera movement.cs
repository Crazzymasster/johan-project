using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public float camerasensitivity = 100f;
    public Transform playerbody;

    float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * camerasensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * camerasensitivity * Time.deltaTime;

        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerbody.Rotate(Vector3.up * mousex);
    }
}
