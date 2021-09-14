
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Hover : MonoBehaviour {
    // Color mouseColor = new Color(0.75f, 0.44f, 1f, 1f);
    Color mouseColor = new Color(0f, 1f, 1f, 0.5f);
    // Color mouseColor = Color.red;
    List <Color> originals = new List<Color>();
    List <Material> mats = new List<Material>();
    MeshRenderer rend;
    Transform[] tforms;
    Camera mainCam;
    Canvas txtCanvas;
    TextMeshProUGUI label;
    Image qmark;

    void Start() {
        // mainCam = Camera.main;
        mainCam = GameObject.Find("UICam").GetComponent<Camera>();
        label = GameObject.Find("LabelText").GetComponent<TextMeshProUGUI>();
        label.text = "+";
        qmark = GameObject.Find("qmark").GetComponent<Image>();
        qmark.enabled = false;
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
               if(mat.color != null){
                   originals.Add(mat.color);
               }
        }
    }

    void OnMouseOver(){
        float dist = Vector3.Distance(mainCam.transform.position, this.transform.position);
        float tx = this.transform.position.x;
        float mx = this.transform.position.x;
        float tz = this.transform.position.z;
        float mz = this.transform.position.z;

        double dist2 = Math.Sqrt(Math.Pow((mx-tx),2)+Math.Pow((mz-tz),2));

        if (dist2 <= 15){
            if (mats.Count > 0){
                foreach(Material mat in mats){
                    if (mat.color != null){
                        mat.color = mouseColor;
                    }
                }
            }
            label.text = this.tag;
            qmark.enabled = true;
        }
            
    }

    void OnMouseExit(){
        label.text = "+";
        qmark.enabled = false;
        if (mats.Count > 0){
            int index = 0;
            foreach(Material mat in mats){
                if (mat.color != null){
                    mat.color = originals[index];
                }
                index++;
            }
        }
    }
}