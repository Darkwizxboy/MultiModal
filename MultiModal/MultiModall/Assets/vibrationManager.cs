using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vibrationManager : MonoBehaviour
{
    public GameObject leftHand, rightHand;
    public static vibrationManager singleton;
    // Start is called before the first frame update
    void Start()
    {
        if(singleton && singleton != this)
        {
            Destroy(this);
        }
        else
        {
            singleton = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void triggerVibration(int iteration, int frequency,int strength)
    {
        OVRHapticsClip clip = new OVRHapticsClip();
        for(int i = 0; i < iteration; i++){
            clip.WriteSample(i % frequency == 0 ?(byte) strength : (byte)0);
        }

        OVRHaptics.RightChannel.Preempt(clip);
    }
}
