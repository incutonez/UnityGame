using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Because this script is attached to the camera object, the
        // transform in this scope references the camera's transform
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called just like Update, but it runs after all
    // other Updates have been processed... this ensures that when
    // we set the position of the camera, we know the player has already
    // moved to that frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
