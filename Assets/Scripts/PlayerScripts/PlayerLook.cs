using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 100f;
    public float ySensitivity = 100f;

public void processLook(Vector2 Input)
    {
        float mouseX = Input.x;
        float mouseY = Input.y;
        //calculate the camera rotation for up and down.
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //apply the rotation to the camera.
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //rotate the player left and right.

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);


    }
}
