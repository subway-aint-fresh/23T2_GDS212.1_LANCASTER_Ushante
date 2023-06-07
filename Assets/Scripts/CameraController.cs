using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;

    void Start()
    {
        // calculate the inital offset between the player and the camera
        offset = transform.position - player.position;
    }

    void Update()
    {
        // Update the camera's position to match the player's position
        transform.position = player.position + offset;
    }
}
