using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + offset;

        // Apply the player's y-axis rotation to the camera's rotation
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
