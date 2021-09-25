using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class LoadMain : MonoBehaviour {
//    public void OnButtonPress(){
//        
//    }
    void Start() {}


    void Update(){
        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Mouse0)) { // allow right trigger or mouse click
            SceneManager.LoadScene("MainScene");       
        }
    }

}
