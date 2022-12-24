using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_creator : MonoBehaviour
{
    // Start is called before the first frame update

    public int width = 30;
    public int height = 200;
    static System.Random rnd = new System.Random();
    public GameObject platform;

    void Awake()
    {

        PlayerPrefs.DeleteKey("level");

        List<List<int>> level = new List<List<int>>();
        if(!PlayerPrefs.HasKey("level"))
        {

            for(int i=0;i<height;i++)
            {
                List<int> row = new List<int>();

                for(int j=0;j<width;j++)
                {
                    row.Add(0);
                }


                int scenario = Random.Range(0, 3);// 0 -> 4x2
                                                  // 1 -> 3x3
                                                  // 2 -> 2x4


                if (scenario == 0)
                {
                    int center = Random.Range(0, width-3);
                    row[center] = 1;
                    row[center+1] = 1;
                    row[center+2] = 1;
                    row[center+3] = 1;

                    center = Random.Range(0, width-3);
                    row[center] = 1;
                    row[center+1] = 1;
                    row[center+2] = 1;
                    row[center+3] = 1;

                    //row[Random.Range(0, width-3)] = 1;

                    /*string log = "";

                    foreach( var x in row) {
                    log += x.ToString();
                    }

                    Debug.Log(log);*/
                }
                else if(scenario == 1)
                {
                    int center = Random.Range(0, width-2);
                    row[center] = 1;
                    row[center+1] = 1;
                    row[center+2] = 1;

                    center = Random.Range(0, width-2);
                    row[center] = 1;
                    row[center+1] = 1;
                    row[center+2] = 1;

                    center = Random.Range(0, width-2);
                    row[center] = 1;
                    row[center+1] = 1;
                    row[center+2] = 1;

                    /*string log = "";

                    foreach( var x in row) {
                    log += x.ToString();
                    }

                    Debug.Log(log);*/

                }
                else
                {
                    int center = Random.Range(0, width-1);
                    row[center] = 1;
                    row[center+1] = 1;

                    center = Random.Range(0, width-1);
                    row[center] = 1;
                    row[center+1] = 1;

                    center = Random.Range(0, width-1);
                    row[center] = 1;
                    row[center+1] = 1;

                    center = Random.Range(0, width-1);
                    row[center] = 1;
                    row[center+1] = 1;

                    //row[Random.Range(0, width-1)] = 1;

                    /*string log = "";

                    foreach( var x in row) {
                    log += x.ToString();
                    }

                    Debug.Log(log);*/
                }


            level.Add(row);

            }
            string total_level = "";

            for(int i=0;i<height;i++)
                {
                    for(int j=0;j<width;j++)
                    {
                        total_level += (level[i][j].ToString());
                    }
                }
            PlayerPrefs.SetString("level", total_level);
            Debug.Log(total_level);

        }

        string total_str= PlayerPrefs.GetString("level");
        Debug.Log(total_str);

            for(int i=0;i<height;i++)
            {
                for(int j=0;j<width;j++)
                {
                    if(total_str[i*width+j] == '1')
                    {
                        Instantiate(platform, new Vector3(-7.75f + j*0.5f, -3f + i*(0.5f+2f),0), Quaternion.identity);
                    }
                }
            }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
