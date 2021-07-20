using UnityEngine;
 
public class MouseHandler : MonoBehaviour {

    public float hSpeed = 1f;
    public float vSpeed = 1f;
    private float xRot = 0.0f;
    private float yRot = 0.0f;
    private Camera mainCam;
 
    void Start() {
        mainCam = Camera.main;
        Debug.Log("Current camera type is " + Camera.main.cameraType);
    }
 
    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * hSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * vSpeed;
 
        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);
 
        mainCam.transform.eulerAngles = new Vector3(xRot, yRot, 0.0f);
    }
}