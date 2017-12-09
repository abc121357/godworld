using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public float offsetX = 0f;
    public float offsetY = 2f;
    public float offsetZ = -10f;
    public float followSpeed = 1f;
    Vector3 cameraposition;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        cameraposition.x = player.transform.position.x + offsetX;

        cameraposition.y = player.transform.position.y + offsetY;
        cameraposition.z = player.transform.position.z + offsetZ;
        transform.position = Vector3.Lerp(transform.position, cameraposition, followSpeed * Time.deltaTime);

    }
}
