using System.Threading;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KorumaRotator : MonoBehaviour
{

    private int coefficient=1;

    // Update is called once per frame
    void Update()
    {
        if((int)(Time.frameCount)%200==0){
            coefficient*=-1;
        }
    
        transform.RotateAround(new UnityEngine.Vector3(0,0,0), new UnityEngine.Vector3 (0,1,0), 20 * Time.deltaTime*coefficient);
        transform.Rotate(new UnityEngine.Vector3(0,30,0)*Time.deltaTime);
    
    }
}
