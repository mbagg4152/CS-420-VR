using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLook : MonoBehaviour
{
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("script start");
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask)) {
            var obj = hit.collider.gameObject;
    
            if ((obj.name != "Terrain") && (obj.name != "Game Object")) {
                Debug.Log($"looking at {obj.name}", this);
            } 
            
        }
    }
}
