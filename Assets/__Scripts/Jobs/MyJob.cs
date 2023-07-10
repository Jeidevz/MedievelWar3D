using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;


public struct MyJob : IJobParallelForTransform
{
    public float dt;
    public float speed;
    public Vector3 forward;
    [ReadOnly]
    public NativeArray<float> objectPosition;



    /*
    public void Execute()
    {
        for (int i = 0; i < objectPosition.Length; i++)
        {
            Debug.Log("dt:" + dt);
            Debug.Log("before" + objectPosition[i]);
            objectPosition[i] = objectPosition[i] + speed * 10 * dt;
            Debug.Log("after " + objectPosition[i]);
            
        }
        
    }
    */

    public void Execute(int index, TransformAccess transform)
    {
        transform.position +=  transform.rotation * Vector3.forward * speed * dt;
    }
}
