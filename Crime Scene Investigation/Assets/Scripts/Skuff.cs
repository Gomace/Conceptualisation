using System.Collections;
using UnityEngine;

public class Skuff : MonoBehaviour
{
    public bool IsOpen = false;
    [SerializeField] private float Speed = 1f;
    [Header("Rotation Configs")]
    [SerializeField] private float RotationAmount = 90f;
    [SerializeField] private bool ForwardDirection = false;

    private Vector3 StartRotation;

    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        StartRotation = transform.parent.rotation.eulerAngles;
    }

    public void OpenClose()
    {
        if (AnimationCoroutine != null)
            StopCoroutine(AnimationCoroutine);
        
        AnimationCoroutine = StartCoroutine(IsOpen ? DoRotationClose() : DoRotationOpen());
    }

    private IEnumerator DoRotationOpen()
    {
        Quaternion startRotation = transform.parent.rotation;
        Quaternion endRotation;

        if (ForwardDirection)
            endRotation = Quaternion.Euler(new Vector3(0, 0, StartRotation.x - RotationAmount));
        else
            endRotation = Quaternion.Euler(new Vector3(0, 0, StartRotation.x + RotationAmount));

        IsOpen = true;

        float time = 0;
        while (time < 1)
        {
            transform.parent.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion startRotation = transform.parent.rotation;
        Quaternion endRotation = Quaternion.Euler(StartRotation);

        IsOpen = false;

        float time = 0;
        while (time < 1)
        {
            transform.parent.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }    
}