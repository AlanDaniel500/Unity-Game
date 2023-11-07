using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float cameraSpeed = 5f;
    [SerializeField] Vector3 cameraOffset = new Vector3(0f, 0f, -1f);
    Vector3 pos;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 playerPos = player.position + cameraOffset;
        pos = Vector3.Slerp(transform.position, playerPos, cameraSpeed * Time.deltaTime);

        transform.position = pos;
    }
}
