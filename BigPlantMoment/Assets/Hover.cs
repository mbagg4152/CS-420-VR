using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {
    Color mouseColor = new Color(0.27f, 0.76f, 1f, 1f);
    Color [] originals;
    Material[] mats;
    MeshRenderer rend;

    void Start() {
        if (GetComponent<MeshRenderer>()){
            rend = GetComponent<MeshRenderer>();
            mats = rend.materials;

            Array.Resize(ref originals, mats.Length);
            int index = 0;
            foreach(Material mat in mats){
                originals[index] = mat.color;
                index ++;
            }
        }
       
    }

    void OnMouseOver(){
        if (GetComponent<MeshRenderer>()){
            foreach(Material mat in mats){
                mat.color = mouseColor;
            }
        }
    }

    void OnMouseExit(){
        if (GetComponent<MeshRenderer>()){
            int index = 0;
            foreach(Material mat in mats){
                mat.color = originals[index];
                index++;
            }
        }
    }
}