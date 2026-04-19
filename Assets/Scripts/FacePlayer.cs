using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform camTransform;

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - camTransform.position);
    }
}
