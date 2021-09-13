using System.Linq.Expressions;
using System.Reflection.Emit;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hover : MonoBehaviour {
    // Color mouseColor = new Color(0.75f, 0.44f, 1f, 1f);
    Color mouseColor = new Color(0f, 3f, 3f, 0.5f);
    // Color mouseColor = Color.red;
    List <Color> originals = new List<Color>();
    List <Material> mats = new List<Material>();
    MeshRenderer rend;
    Transform[] tforms;
    Camera mainCam;
    Canvas txtCanvas;
    TextMeshProUGUI label;

    void Start() {
        mainCam = Camera.main;
        label = GameObject.Find("LabelText").GetComponent<TextMeshProUGUI>();
        label.text = "";
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
            label.text = this.tag;
        }
            
    }

    void OnMouseExit(){
        label.text = "";
        if (mats.Count > 0){
            int index = 0;
            foreach(Material mat in mats){
                mat.color = originals[index];
                index++;
            }
        }
    }
}