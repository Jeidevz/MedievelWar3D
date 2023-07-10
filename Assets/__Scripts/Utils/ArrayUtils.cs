using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayUtils : MonoBehaviour {

    public static T getRandomClipFromAudioList<T>(T[] arrayList)
    {
        if (arrayList != null)
        {
            int index = Random.Range(0, arrayList.Length);
            //print(index);
            return arrayList[index];
        }
        return default(T);
    }
}
