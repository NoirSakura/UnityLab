using UnityEngine;
using System.Collections;

public class ThirdLockCamera : MonoBehaviour
{
    public Transform pivot;
    public Vector3 pivotOffset = Vector3.zero;
    public float distance = 10.0f; // distance from target (used with zoom)
    public float distanceLimit = 3f;//distance when camera change Angles for 180
    public float zoomSpeed = 1f;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;

    public bool allowYTilt = true;
    public float yMinLimit = -60f;
    public float yMaxLimit = 60f;

    private float x = 0.0f;
    private float y = 0.0f;
    private float targetX = 0f;
    private float targetY = 0f;
    private float targetDistance = 0f;
    private float xVelocity = 1f;
    private float yVelocity = 1f;
    private float zoomVelocity = 1f;
    private float m_distance;
    // Use this for initialization
    void Start()
    {

        var angles = transform.eulerAngles;
        targetX = x = angles.x;
        targetY = y = ClampAngle(angles.y, yMinLimit, yMaxLimit);
        targetDistance = distance;
        m_distance = distance;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (pivot)
        {
            targetDistance = m_distance;

            if (Input.GetMouseButton(1) || (Input.GetMouseButton(0) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))))
            {
                targetX += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                if (allowYTilt)
                {
                    targetY -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                    targetY = ClampAngle(targetY, yMinLimit, yMaxLimit);
                }
            }
            x = Mathf.SmoothDampAngle(x, targetX, ref xVelocity, 0.3f);
            if (allowYTilt) y = Mathf.SmoothDampAngle(y, targetY, ref yVelocity, 0.3f);
            else y = targetY;
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -m_distance) + pivot.position;//calculate the true camera positon
            RaycastHit hit;//ues a ray to make camera not be blocked
            if (Physics.Linecast(position, pivot.position, out hit))
            {
                string name = hit.collider.gameObject.tag;
                if (name == "Untagged")
                {
                    targetDistance = (hit.point - pivot.position).magnitude;//if the hit object's tag is Untagged,change the distance
                }
            }
            distance = Mathf.SmoothDamp(distance, targetDistance, ref zoomVelocity, 0.5f);
            if (distance > distanceLimit)
            {
                position = rotation * new Vector3(0.0f, 0.0f, -distance) + pivot.position + pivotOffset;
            }
            else
            {
                rotation = Quaternion.Euler(y, x + 180f, 0);
                position = rotation * new Vector3(0.0f, 0.0f, -m_distance) + pivot.position + pivotOffset;
                targetX = targetX + 180;
                x = x + 180;
            }
            transform.rotation = rotation;
            transform.position = position;
        }
    }
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}