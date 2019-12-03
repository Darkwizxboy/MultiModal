using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class modeSelect : MonoBehaviour
{
    public GameObject rightHand;

    //countdown variables
    public float timeleft = 60.0f;
    public bool levelIsStarted = false;

    public GameObject audiozone;
    public Material select, standard;
    public GameObject cube1, cube2, cube3, cube4, cube5, cube6;

    //variables for saving
    public int test1Wrong = 0;
    public int test1Correct = 0;

    public int test2Wrong = 0;
    public int test2Correct = 0;

    public int test3Wrong = 0;
    public int test3Correct = 0;

    public int test4Wrong = 0;
    public int test4Correct = 0;

    public int test5Wrong = 0;
    public int test5Correct = 0;
    public int test5CorrectAudio = 0;
    public int test5CorrectVisual = 0;
    public int test5CorrectHaptic = 0; 

    public GameObject[] cubes;
    public int counter = 0;
    public int current = 0;
    int[] array1 = new int[] { 0, 2, 4, 5, 1, 2, 3, 0, 5, 1, 5, 1, 3, 2, 3, 5, 3, 1, 5, 2, 4, 5, 3, 0, 2, 3, 5, 1, 4, 2, 0, 5, 3, 0, 2, 3, 1, 4, 0, 5, 3, 4, 2, 0, 5 };
    int[] array2 = new int[] { 2, 4, 0, 1, 3, 4, 5, 2, 1, 3, 1, 3, 5, 4, 5, 1, 5, 3, 1, 4, 0, 1, 5, 2, 4, 5, 1, 3, 0, 4, 2, 1, 5, 2, 4, 5, 3, 0, 2, 1, 5, 0, 4, 2, 1 };
    int[] array3 = new int[] { 1, 5, 3, 2, 0, 4, 0, 3, 0, 5, 2, 3, 0, 1, 5, 3, 4, 2, 0, 1, 5, 2, 3, 0, 1, 3, 5, 3, 2, 0, 1, 5, 1, 3, 2, 1, 5, 4, 0, 4, 0, 2, 0, 1, 0 };
    int[] array4 = new int[] { 1, 2, 0, 1, 3, 5, 4, 2, 0, 1, 0, 5, 0, 2, 5, 3, 4, 0, 2, 3, 5, 0, 5, 1, 3, 5, 4, 3, 1, 0, 2, 5, 1, 2, 5, 3, 5, 4, 1, 3, 0, 4, 1, 3, 0, 1, 2, 0, 1, 3, 5, 4, 2, 0, 1, 0, 5, 0, 2, 5, 3, 4, 0, 2, 3, 5, 0, 5, 1, 3, 5, 4, 3, 1, 0, 2, 5, 1, 2, 5, 3, 5, 4, 1, 3, 0, 4, 1, 3, 0 };
    public GameObject text;
    //the mode is the sense we are testing. 1 = visual, 2 = audio, 3 = haptic. 
    //Is set manually in the inspector
    public int mode = 0;



    public int test51 = 0;
    public int test52 = 0;
    public int test53 = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeleft = 60.0f;

    cubes = new GameObject[] { cube1, cube2, cube3, cube4, cube5, cube6 };
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeleft);
        modesetup();

        testing();
        if (mode == 1)
        {
            current = array1[counter];
        }else if (mode == 2)
        {
            current = array2[counter];
        }
        else if (mode == 3)
        {
            current = array3[counter];
        }
        else if (mode == 4)
        {
            current = array4[counter];
        }
        else if (mode == 5)
        {
            test51 = array1[counter];
            test52 = array2[counter];
            test53 = array3[counter];
        }

        if (levelIsStarted == true)
        {
            countDown();
        }

    }

    public void testing()
    {
        if (mode == 1)
        {
            for(int i = 0; i < 6; i++)
            {
                cubes[i].GetComponent<MeshRenderer>().material = standard;
            }
            cubes[current].GetComponent<MeshRenderer>().material = select;

        }
        if(mode == 2)
        {
            for (int i = 0; i < 6; i++)
            {
                cubes[i].GetComponent<MeshRenderer>().material = standard;
            }
            audiozone.transform.position = cubes[current].transform.position;
        }


        if (mode == 3)
        {
            
            float dist = Vector3.Distance(cubes[current].transform.position, rightHand.transform.position);
            float nonliniar = 3.0f - dist;

            float mapped = nonliniar / 4.0f * 255;

            
            vibrationManager.singleton.triggerVibration(40, 2, Mathf.RoundToInt(mapped));
        }

        if (mode == 4)
        {
            for(int i = 0; i < 6; i++)
            {
                cubes[i].GetComponent<MeshRenderer>().material = standard;
            }
            cubes[current].GetComponent<MeshRenderer>().material = select;

            audiozone.transform.position = cubes[current].transform.position;

            float dist = Vector3.Distance(cubes[current].transform.position, rightHand.transform.position);
            float nonliniar = 3.0f - dist;

            float mapped = nonliniar / 4.0f * 255;


            vibrationManager.singleton.triggerVibration(60, 2, Mathf.RoundToInt(mapped));
        }

        if (mode == 5)
        {
            for (int i = 0; i < 6; i++)
            {
                cubes[i].GetComponent<MeshRenderer>().material = standard;
            }
            cubes[test51].GetComponent<MeshRenderer>().material = select;

            audiozone.transform.position = cubes[test52].transform.position;

            float dist = Vector3.Distance(cubes[test53].transform.position, rightHand.transform.position);
            float nonliniar = 3.0f - dist;

            float mapped = nonliniar / 4.0f * 255;
            vibrationManager.singleton.triggerVibration(60, 2, Mathf.RoundToInt(mapped));
        }
  
    }


    private void nextIte()
    {
        counter = counter + 1;
    }


    public void countDown()
    {
        if (timeleft > 0)
        {
            timeleft -= Time.deltaTime;
        }

        if (timeleft <= 0)
        {
            mode = mode + 1;
            levelIsStarted = false;
            counter = 0;
            timeleft = 60.0f;
        }
      
        
    }




    public void modesetup()
    {
        if (mode == 1)
        {
            text.GetComponent<TextMeshPro>().text = "Currently testing: \n Visual";
        }
        else if (mode == 2)
        {
            text.GetComponent<TextMeshPro>().text = "Currently testing: \n Audio";
        }
        else if (mode == 3)
        {
            text.GetComponent<TextMeshPro>().text = "Currently testing: \n Haptic";
        }
        else if (mode == 4)
        {
            text.GetComponent<TextMeshPro>().text = "Currently testing: \n All";
        }
        else if (mode == 5)
        {
            text.GetComponent<TextMeshPro>().text = "Currently testing: \n All";
        }
        else if (mode == 6)
        {
            string finalString = "visual wrong: " + test1Wrong + "\n visual correct: " + test1Correct + "\n Audio wrong: " + test2Wrong + "\n Audio correct: " + test2Correct +
                "\n haptic wrong: " + test3Wrong + "\n haptic correct: " + test3Correct + "\n all wrong: " + test4Wrong + "\n all correct: " + test4Correct +
                "\n test5 wrong: " + test5Wrong + "\n test5 visualcorrect: " + test5CorrectVisual + "\n test5 audiocorrect: " + test5CorrectAudio + "\n test5 hapticCorrect: " + test5CorrectHaptic;

            text.GetComponent<TextMeshPro>().text = finalString;
            text.GetComponent<TextMeshPro>().fontSize = 8;

           
        }
        if (mode == 2||mode==4 ||mode==5)
        {
            audiozone.gameObject.SetActive(true);
        }
        else
        {
            audiozone.gameObject.SetActive(false);
        }
    }
}
