using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public ThirdPersonUserControl userControl;
    public GameObject target;
    private GameObject originalTarget;
    public float damping = 1;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        originalTarget = target;
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        //if (Input.GetMouseButton(1))
        //    MouseAimCamera();
        //else
        //{
        //    DungeonCamera();
        //    FollowCamera();
        //}

        //if(userControl.m_Move == Vector3.zero)
        //MouseAimCamera();
        //ForwardCamera();
    }

    public void LookAtTarget(GameObject _target)
    {
        target = _target;
    }

    public void ReleaseTarget()
    {
        target = originalTarget;
    }

    void DungeonCamera()
    {
        Vector3 desiredPosition = target.transform.position - offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;

        transform.LookAt(target.transform.position);
    }

    void FollowCamera()
    {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }

    void MouseAimCamera()
    {
        //float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float horizontal = Input.GetAxis("Horizontal") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }

    void ForwardCamera()
    {
        Vector3 dir = new Vector3(player.transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, player.transform.localEulerAngles.z);
        //player.transform.localEulerAngles = dir;

        player.transform.localEulerAngles = Vector3.Lerp(player.transform.localEulerAngles, dir, damping);


    }
}