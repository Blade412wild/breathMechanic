using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform TargetToFollow;
    public float offset;

    private Vector3 CameraPos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(TargetToFollow.position.x, TargetToFollow.position.y + offset, TargetToFollow.position.z);
    }
}
