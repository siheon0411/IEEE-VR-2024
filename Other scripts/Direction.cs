using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public GameObject player;

    public GameObject directionArrow;
    public RectTransform directionArrowRect;

    public float posX = 0;
    public float posY = 0.1f;
    public float posZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posX = player.transform.position.x - 5.0f;

        Vector3 newPosition = new Vector3 (posX, posY, posZ);
        directionArrowRect.position = newPosition;
    }

    public void On() {
        directionArrow.SetActive(true);
    }

    public void Off() {
        directionArrow.SetActive(false);
    }

    public void PosZ(float z) {
        posZ = z;
    }
    
}
