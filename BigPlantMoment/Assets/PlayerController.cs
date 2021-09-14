

using UnityEngine;
 
public class PlayerController : MonoBehaviour {
    CharacterController control;
    public Camera mainCam;
    public float mvmtSpeed = 10;
    public float grav = 9.8f;
    private float vel = 0;
    float hPos = 0; 
    float vPos = 0;
    Vector3  vRight, vForward;
    private void Start() {
        control = GetComponent<CharacterController>();
        mainCam  = Camera.main;
    }
  void OnGUI(){
     if(GUI.Button(new Rect(10,10,40,20),"Test")){
         Debug.Log("test button");
     }
  }
    void Update() {
       
        hPos = Input.GetAxis("Horizontal") * mvmtSpeed; // horizontal axis position
        vPos = Input.GetAxis("Vertical") * mvmtSpeed; // vertical axis position
        var hAxisValue = Input.GetAxis("XRI_Left_Secondary2DAxis_Horizontal");
        if (hAxisValue != 0){
            Debug.Log(hAxisValue);
        }
        // change movements relative to camera
        vRight = mainCam.transform.right * hPos * mvmtSpeed; // get horizontal movement from player input & camera position
        vForward = mainCam.transform.forward * vPos * mvmtSpeed; // get vertical movement from player input & camera position  

        control.Move((vRight + vForward) * Time.deltaTime); // move using relative vectors
 
        if(control.isGrounded) { // handles code if for some reason character is falling
            vel = 0;
        } else {
            vel -= grav * Time.deltaTime;
            control.Move(new Vector3(0, vel, 0));
        }
    }
}