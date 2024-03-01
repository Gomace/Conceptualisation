using TMPro;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HoverText;
    [SerializeField] private float MaxUseDistance = 4f;
    [SerializeField] private LayerMask UseLayers;
    [SerializeField] private Global Global;
    
    private Transform Camera;

    private void Awake()
    {
        Camera = transform.GetChild(2);
    }
        
    private void Update()
    {
        if (Global.Busy)
            return;
        
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
        {
            if (hit.collider.CompareTag("Evidence")) // Evidence
            {
                HoverText.SetText("Left-Click to Inspect");
                HoverText.gameObject.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    transform.GetComponent<Evidence>().StartInspecting(hit.transform);
                    //transform.GetComponent<Evidence>().StartInspecting(hit.transform.parent);
                }
            }
            else if (hit.collider.TryGetComponent<Door>(out Door door)) // Door
            {
                HoverText.SetText(door.IsOpen ? "Left-Click to Close" : "Left-Click to Open");
                HoverText.gameObject.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    door.OpenClose();
                    Global.GetComponent<Sounds>().Door(door.IsOpen);
                }
            }
            else if (hit.collider.TryGetComponent<Drawer>(out Drawer drawer))   // Drawer
            {
                HoverText.SetText(drawer.IsOpen ? "Left-Click to Close" : "Left-Click to Open");
                HoverText.gameObject.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    drawer.OpenClose();
                    Global.GetComponent<Sounds>().Drawer(drawer.IsOpen);
                }
            }
            else if (hit.collider.TryGetComponent<Skuff>(out Skuff skuff))   // Drawer
            {
                HoverText.SetText(skuff.IsOpen ? "Left-Click to Close" : "Left-Click to Open");
                HoverText.gameObject.SetActive(true);
                
                if (Input.GetMouseButtonDown(0))
                    skuff.OpenClose();
            }
            else if (hit.collider.TryGetComponent<Cabinet>(out Cabinet cabinet)) // Door
            {
                HoverText.SetText(cabinet.IsOpen ? "Left-Click to Close" : "Left-Click to Open");
                HoverText.gameObject.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    cabinet.OpenClose();
                    Global.GetComponent<Sounds>().Cabinet(cabinet.IsOpen);
                }
            }
            else if (hit.collider.CompareTag("Movables"))
            {
                HoverText.SetText("Left-Click to Open");
                HoverText.gameObject.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                    Global.GetComponent<Sounds>().Locked();
            }
            else
                HoverText.gameObject.SetActive(false);
        }
        else
            HoverText.gameObject.SetActive(false);
    }
}