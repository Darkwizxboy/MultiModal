using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTouch : MonoBehaviour
{
    public AudioSource correct, wrong;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (this.gameObject == Player.GetComponent<modeSelect>().cubes[Player.GetComponent<modeSelect>().current])
            {
                Player.GetComponent<modeSelect>().counter = Player.GetComponent<modeSelect>().counter + 1;
                correct.Play();

            }
            else
            {
                wrong.Play();
            }
        }
    }
}
