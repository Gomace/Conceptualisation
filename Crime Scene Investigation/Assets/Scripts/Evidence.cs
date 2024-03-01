using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Evidence : MonoBehaviour
{
    [SerializeField] private Global Global;
    [SerializeField] private Transform evidenceUI;
    
    private Transform[] inventory = new Transform[9];
    private Transform thing;
    //private Transform item;
    
    [HideInInspector] public bool Inspecting;
    private bool Cancelable;
    private bool Won;
    
    /*Vector3 StartRotation;
    Quaternion EndRotation;
    
    Vector3 StartPosition;
    Vector3 EndPosition;*/
    
    void Update()
    {
        if (!Inspecting)
            return;
        if (Input.GetMouseButtonDown(0) && Cancelable)
            StopInspecting();
        if (Inspecting)
            Cancelable = true;

        /*float mouseX = Input.GetAxis("Mouse X") * Global.mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Global.mouseSensitivity * Time.deltaTime;

        item.Rotate(Camera.main.transform.up, -mouseX, Space.World);
        item.Rotate(Camera.main.transform.right, mouseY, Space.World);*/
    }
    
    public void StartInspecting(Transform evidence)
    {
        //item = evidence;
        thing = evidence.parent;
        
        Global.Busy = true;
        Inspecting = true;
        Cancelable = false;
        
        Global.GetComponent<Sounds>().Evidence(Inspecting);

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = thing;
                //thing.parent = transform.GetChild(2); // cam
                WhichEvidence();
                thing.gameObject.SetActive(false);
                return;
            }
        }
        
        /*StartRotation = evidence.parent.rotation.eulerAngles;
        StartPosition = evidence.parent.position;*/
    }

    void StopInspecting()
    {
        Inspecting = false;
        Global.Busy = false;
        
        Global.GetComponent<Sounds>().Evidence(Inspecting);
        
        WhichEvidence();
        Victory();
    }

    private void WhichEvidence()
    {
        evidenceUI.parent.GetChild(0).gameObject.SetActive(false);
        
        for (int i = 0; i < evidenceUI.childCount; i++)
        {
            if (evidenceUI.GetChild(i).name == thing.name)
                evidenceUI.GetChild(i).gameObject.SetActive(Inspecting);
        }
    }
    
    private void Victory()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
                return;
        }
        evidenceUI.parent.GetChild(3).gameObject.SetActive(!Won);
                     
        if (Won)
            return;
        Global.Busy = true;
        Inspecting = true; 
        Cancelable = false;
        Won = true;
    }
}
