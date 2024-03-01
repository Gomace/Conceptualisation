using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource drawerOpen;
    [SerializeField] private AudioSource drawerClose;
    [Header("")]
    [SerializeField] private AudioSource doorOpen;
    [SerializeField] private AudioSource doorClose;
    [Header("")]
    [SerializeField] private AudioSource cabinetOpen;
    [SerializeField] private AudioSource cabinetClose;
    [Header("")]
    [SerializeField] private AudioSource PickUp;
    [SerializeField] private AudioSource PutDown;
    [Header("")]
    [SerializeField] private AudioSource locked;
    
    private AudioSource sfx;

    public void Drawer(bool IsOpen)
    {
        if (sfx != null)
            sfx.Stop();
            
        sfx = (IsOpen ? drawerOpen : drawerClose);
        sfx.Play();
    }
    
    public void Door(bool IsOpen)
    {
        if (sfx != null)
            sfx.Stop();
            
        sfx = (IsOpen ? doorOpen : doorClose);
        sfx.Play();
    }
    
    public void Cabinet(bool IsOpen)
    {
        if (sfx != null)
            sfx.Stop();
            
        sfx = (IsOpen ? cabinetOpen : cabinetClose);
        sfx.Play();
    }

    public void Evidence(bool Inspecting)
    {
        if (sfx != null)
            sfx.Stop();
                    
        sfx = (Inspecting ? PickUp : PutDown);
        sfx.Play();
    }
    
    public void Locked()
    {
        if (sfx != null)
            sfx.Stop();
        
        sfx = locked;
        sfx.Play();
    }
}
