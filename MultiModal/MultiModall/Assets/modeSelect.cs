using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class modeSelect : MonoBehaviour
{



    public GameObject audiozone;
    public Material select, standard;
    public GameObject cube1, cube2, cube3, cube4, cube5, cube6;


    public GameObject[] cubes;
    public int counter = 0;
    public int current = 0;
    int[] array1 = new int[] { 0, 2, 4, 5, 1,2,3,0,5,1,5,1,3,2,3,5,3,1,5,2,4,5 };
    public GameObject text;
    //the mode is the sense we are testing. 1 = visual, 2 = audio, 3 = haptic. 
    //Is set manually in the inspector
    public int mode = 0;
    // Start is called before the first frame update
    void Start()
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

        if (mode == 2)
        {
            audiozone.gameObject.SetActive(true);
        }
        else
        {
            audiozone.gameObject.SetActive(false);
        }

       cubes = new GameObject[] { cube1, cube2, cube3, cube4, cube5, cube6 };
    }

    // Update is called once per frame
    void Update()
    {
        testing();
        current = array1[counter];
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
            audiozone.transform.position = cubes[current].transform.position;
        }
  
    }


    private void nextIte()
    {
        counter = counter + 1;
    }
}
