using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class LoadMain : MonoBehaviour {
   public void OnButtonPress(){
       SceneManager.LoadScene("MainScene");
   }
}
