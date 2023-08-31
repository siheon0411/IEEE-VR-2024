using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move270 : MonoBehaviour    // Move270은 motorcycle에서 사용
{
    private float speed = 13.88f;
    // object별 속도 설정 -> 1 Unity Speed = 1m/s = 3.6km/h
    // car:         30~50km/h   -> 8.33~13.88
    // cycle:       15~30km/h   -> 4.16~8.33
    // kickboard:   15~25km/h   -> 4.16~6.94
    // motorcycle:  20~50km/h   -> 5.55~13.88

    // Start is called before the first frame update
    void Start() 
    {

    }

    // Update is called once per frame
    void Update() 
    {

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
