using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class JobTest : MonoBehaviour {
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 forward = transform.forward * 1;
        Transform[] transforms = new[] { transform };
        TransformAccessArray accessArray = new TransformAccessArray(transforms);

        NativeArray<float> position = new NativeArray<float>(1,Allocator.TempJob);
        float speed = 2f;
        MyJob job = new MyJob
        {
            dt = Time.deltaTime,
            speed = speed,
            objectPosition = position
            
        };

        print(forward);

        MyJob paraJob = new MyJob {
            dt = Time.deltaTime,
            speed = 2f,
            forward = forward
        };
        //JobHandle paraHandle = paraJob.Schedule(1,1);
        JobHandle handle = job.Schedule(accessArray);
        handle.Complete();
        position.Dispose();
        accessArray.Dispose();
        

        //transform.Translate(Vector3.forward * Time.deltaTime);
        //transform.Rotate(Vector3.up * Time.deltaTime);
	}
}
