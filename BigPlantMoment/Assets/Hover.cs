using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {
    // Color mouseColor = new Color(0.27f, 0.76f, 1f, 1f);
    Color mouseColor = Color.red;
    List <Color> originals = new List<Color>();
    List <Material> mats = new List<Material>();
    MeshRenderer rend;
    Transform[] tforms;
    Camera mainCam;

    void Start() {
        mainCam = Camera.main;
        
        if (GetComponent<MeshRenderer>()){
            rend = GetComponent<MeshRenderer>();
            mats = rend.materials.OfType<Material>().ToList();
        } else {

         
            tforms = this.GetComponentsInChildren<Transform>();
            foreach (Transform tran in tforms){
                if(tran.GetComponent<MeshRenderer>()){
                    MeshRenderer tmpRend = tran.GetComponent<MeshRenderer>();
                    List <Material> tmpMats = tmpRend.materials.OfType<Material>().ToList();
                    foreach(Material mat in tmpMats){
                        mats.Add(mat);
                    }
                }
            }
        
        }
         foreach(Material mat in mats){
               originals.Add(mat.color);
        }
    }

    void OnMouseOver(){
        float dist = Vector3.Distance(mainCam.transform.position, this.transform.position);
        if (dist <= 10f){
            if (mats.Count > 0){
                foreach(Material mat in mats){
                    mat.color = mouseColor;
                }
            }
        }
            
    }

    void OnMouseExit(){
        if (mats.Count > 0){
            int index = 0;
            foreach(Material mat in mats){
                mat.color = originals[index];
                index++;
            }
        }
    }
}