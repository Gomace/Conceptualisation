using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    [HideInInspector] public bool IsOpen = false;
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float PositionAmount = 2f;
    
    private Vector3 StartPosition;
    private Vector3 EndPosition;

    private Coroutine AnimationCoroutine;
    
    private void Awake()
    {
        StartPosition = transform.parent.position;
        EndPosition = transform.parent.position + transform.parent.forward * PositionAmount;
    }

    public void OpenClose()
    {
        if (AnimationCoroutine != null)
            StopCoroutine(AnimationCoroutine);

        AnimationCoroutine = StartCoroutine(IsOpen ? DoClose() : DoOpen());
    }
    
    private IEnumerator DoOpen()
    {
        Vector3 startPosition = transform.parent.position;
        Vector3 endPosition = EndPosition;

        IsOpen = true;

        float time = 0;
        while (time < 1)
        {
            transform.parent.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }

    private IEnumerator DoClose()
    {
        Vector3 startPosition = transform.parent.position;
        Vector3 endPosition = StartPosition;

        IsOpen = false;

        float time = 0;
        while (time < 1)
        {
            transform.parent.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }
}
