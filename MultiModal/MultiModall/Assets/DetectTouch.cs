using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTouch : MonoBehaviour
{

    public bool detected = false;
    public bool detected2 = false;
    public AudioSource correct, wrong;
    public GameObject Player;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = WaitAndNext(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.GetComponent<modeSelect>().test5Wrong);
    }

    public void OnTriggerEnter(Collider other)
    {
        
            if (other.gameObject.CompareTag("Hand"))
            {
            if (Player.GetComponent<modeSelect>().mode == 5)
            {
                if (detected == false)
                {
                    detected = true;
                    StartCoroutine(coroutine);
                    if (Player.GetComponent<modeSelect>().mode == 3 || Player.GetComponent<modeSelect>().mode == 4 || Player.GetComponent<modeSelect>().mode == 5)
                    {
                        vibrationManager.singleton.triggerVibration(0, 0, 0);
                    }
                    if (this.gameObject == Player.GetComponent<modeSelect>().cubes[Player.GetComponent<modeSelect>().test51])
                    {
                        Player.GetComponent<modeSelect>().test5CorrectVisual = Player.GetComponent<modeSelect>().test5CorrectVisual + 1;
                    }
                    else if (this.gameObject == Player.GetComponent<modeSelect>().cubes[Player.GetComponent<modeSelect>().test52])
                    {
                        Player.GetComponent<modeSelect>().test5CorrectAudio = Player.GetComponent<modeSelect>().test5CorrectAudio + 1;
                    }
                    else if (this.gameObject == Player.GetComponent<modeSelect>().cubes[Player.GetComponent<modeSelect>().test53])
                    {
                        Player.GetComponent<modeSelect>().test5CorrectHaptic = Player.GetComponent<modeSelect>().test5CorrectHaptic + 1;
                    }
                    else
                    {
                        Player.GetComponent<modeSelect>().test5Wrong = Player.GetComponent<modeSelect>().test5Wrong + 1;
                    }
                }
                correct.Play();
                if (Player.GetComponent<modeSelect>().levelIsStarted == false)
                {
                    Player.GetComponent<modeSelect>().levelIsStarted = true;
                }
            }
            if (Player.GetComponent<modeSelect>().mode <= 4)
            {
                if (this.gameObject == Player.GetComponent<modeSelect>().cubes[Player.GetComponent<modeSelect>().current])
                {

                    if (detected == false)
                    {
                        detected = true;
                        StartCoroutine(coroutine);
                        if (Player.GetComponent<modeSelect>().mode == 3 || Player.GetComponent<modeSelect>().mode == 4 || Player.GetComponent<modeSelect>().mode == 5)
                        {
                            vibrationManager.singleton.triggerVibration(0, 0, 0);
                        }
                        //shitty if statements for score system
                        if (Player.GetComponent<modeSelect>().mode == 1)
                        {
                            Player.GetComponent<modeSelect>().test1Correct = Player.GetComponent<modeSelect>().test1Correct + 1;
                        }
                        if (Player.GetComponent<modeSelect>().mode == 2)
                        {
                            Player.GetComponent<modeSelect>().test2Correct = Player.GetComponent<modeSelect>().test2Correct + 1;
                        }
                        if (Player.GetComponent<modeSelect>().mode == 3)
                        {
                            Player.GetComponent<modeSelect>().test3Correct = Player.GetComponent<modeSelect>().test3Correct + 1;
                        }
                        if (Player.GetComponent<modeSelect>().mode == 4)
                        {
                            Player.GetComponent<modeSelect>().test4Correct = Player.GetComponent<modeSelect>().test4Correct + 1;
                        }


                    }
                    correct.Play();
                    if (Player.GetComponent<modeSelect>().levelIsStarted == false)
                    {
                        Player.GetComponent<modeSelect>().levelIsStarted = true;
                    }
                }


                else
                {

                    if (detected == false)
                    {

                        StartCoroutine(coroutine);


                        //shitty if statements for score system
                        if (Player.GetComponent<modeSelect>().mode == 1)
                        {
                            Player.GetComponent<modeSelect>().test1Wrong = Player.GetComponent<modeSelect>().test1Wrong + 1;
                        }
                        if (Player.GetComponent<modeSelect>().mode == 2)
                        {
                            Player.GetComponent<modeSelect>().test2Wrong = Player.GetComponent<modeSelect>().test2Wrong + 1;
                        }
                        if (Player.GetComponent<modeSelect>().mode == 3)
                        {
                            Player.GetComponent<modeSelect>().test3Wrong = Player.GetComponent<modeSelect>().test3Wrong + 1;
                        }
                        if (Player.GetComponent<modeSelect>().mode == 4)
                        {
                            Player.GetComponent<modeSelect>().test4Wrong = Player.GetComponent<modeSelect>().test4Wrong + 1;
                        }


                    }

                    correct.Play();
                }
            }
            }
        
    }

    private IEnumerator WaitAndNext(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Player.GetComponent<modeSelect>().counter = Player.GetComponent<modeSelect>().counter + 1;
            detected = false;
            StopCoroutine(coroutine);
            
            
        }
    }
}
