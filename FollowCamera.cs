
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public Vector3 offset =
        new Vector3(0f, 5f, -10f);

    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition =
            target.TransformPoint(offset);

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        Vector3 lookPosition =
            target.position + Vector3.up * 1.5f;

        Quaternion desiredRotation =
            Quaternion.LookRotation(
                lookPosition - transform.position
            );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            desiredRotation,
            smoothSpeed * Time.deltaTime
        );
    }
}

