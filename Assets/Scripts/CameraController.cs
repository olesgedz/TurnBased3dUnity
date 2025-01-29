using System;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private const float MIN_FOLLLOW_Y_OFFSET = 2.0f;
    private const float MAX_FOLLLOW_Y_OFFSET = 12.0f;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private CinemachineTransposer cinemachineTransposer;

    private Vector3 targetFollowOffset;

    private void Start()
    {
        cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        targetFollowOffset = cinemachineTransposer.m_FollowOffset;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleZoom();
    }

    public void HandleMovement()
    {
        Vector3 inputMoveDir = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir += Vector3.right;
        }

        float moveSpeed = 5.0f;
        inputMoveDir = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        transform.position += inputMoveDir * (moveSpeed * Time.deltaTime);
   
    }

    public void HandleRotation()
    {
        Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.Q))
        {
            rotation += Vector3.up;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotation += Vector3.down;
        }

        float rotationSpeed = 100.0f;

        transform.eulerAngles += rotation * (rotationSpeed * Time.deltaTime);

    }
    
    public void HandleZoom()
    {
        float zoomAmmout = 1.0f;
        if (Input.mouseScrollDelta.y > 0)
        {
            targetFollowOffset.y -= zoomAmmout;
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            targetFollowOffset.y += zoomAmmout;
        }

        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_FOLLLOW_Y_OFFSET, MAX_FOLLLOW_Y_OFFSET);

        float zoomSpeed = 5.0f;
        cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetFollowOffset,
            Time.deltaTime * zoomSpeed);
    }
}