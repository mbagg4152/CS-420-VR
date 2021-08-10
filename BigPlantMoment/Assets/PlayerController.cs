using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    CharacterController control;
    public float mvmtSpeed = 7;
    public float grav = 9.8f;
    private float vel = 0;
 
    private void Start() {
        control = GetComponent<CharacterController>();
    }
 
    void Update() {
        float hPos = Input.GetAxis("Horizontal") * mvmtSpeed;
        float vPos = Input.GetAxis("Vertical") * mvmtSpeed;
        control.Move((Vector3.right * hPos + Vector3.forward * vPos) * Time.deltaTime);
 
        if(control.isGrounded) {
            vel = 0;
        } else {
            vel -= grav * Time.deltaTime;
            control.Move(new Vector3(0, vel, 0));
        }
    }
}