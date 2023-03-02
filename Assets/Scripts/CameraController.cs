using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform characterTransform;
    /// <summary>
    /// Distance of the camera from the ground when topdown mode
    /// </summary>
    public float defaultTopDownHeight = 5f;

    /// <summary>
    /// Transform of the object that the camera is pointing to
    /// </summary>
    public Transform objectFollowingTransform;

    /// <summary>
    /// Camera's distance to the focused object
    /// </summary>
    public float cameraDistanceRadius;

    /// <summary>
    /// Direction of the camera, pointing to the focused object
    /// </summary>
    private Vector3 cameraRotation;

    /// <summary>
    /// Angle of the Y axis
    /// </summary>
    private float horizontalAngle;

    /// <summary>
    /// Angle of the XZ axis
    /// </summary>
    private float verticalAngle;

    void Start()
    {
        if(characterTransform == null)
        {
            characterTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        cameraDistanceRadius = 3f;
        horizontalAngle = 0f;
        verticalAngle = 0f;
        cameraRotation = new Vector3(30f, 0f, 0f);
        transform.rotation = Quaternion.Euler(cameraRotation);
    }

    void Update()
    {
        transform.LookAt(characterTransform.position);
    }
}
