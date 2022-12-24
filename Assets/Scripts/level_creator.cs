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
    public GameObject branch;
    public GameObject cloud;

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
                    int to_place = 1;
                    if ((height/2 <i) && (center<width/3 || center>width*2/3))
                        to_place = 2;

                    row[center] = to_place;
                    row[center+1] = to_place;
                    row[center+2] = to_place;
                    row[center+3] = to_place;

                    center = Random.Range(0, width-3);
                    to_place = 1;
                    if ((height/2 <i) && (center<width/3 || center>width*2/3))
                        to_place = 2;

                    row[center] = to_place;
                    row[center+1] = to_place;
                    row[center+2] = to_place;
                    row[center+3] = to_place;

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
                    int to_place = 1;
                    if ((height/2 <i) && (center<width/3 || center>width*2/3))
                        to_place = 2;
                    row[center] = to_place;
                    row[center+1] = to_place;
                    row[center+2] = to_place;

                    center = Random.Range(0, width-2);
                    to_place = 1;
                    if ((height/2 <i) && (center<width/3 || center>width*2/3))
                        to_place = 2;
                    row[center] = to_place;
                    row[center+1] = to_place;
                    row[center+2] = to_place;

                    center = Random.Range(0, width-2);
                    to_place = 1;
                    if ((height/2 <i) && (center<width/3 || center>width*2/3))
                        to_place = 2;
                    row[center] = to_place;
                    row[center+1] = to_place;
                    row[center+2] = to_place;

                    /*string log = "";

                    foreach( var x in row) {
                    log += x.ToString();
                    }

                    Debug.Log(log);*/

                }
                else
                {
                    int center = Random.Range(0, width-1);
                    int to_place = 1;
                    if ((height/2 <i) && (center<width/3 || center>width*2/3))
                        to_place = 2;
                    row[center] = to_place;
                    row[center+1] = to_place;

                    center = Random.Range(0, width-1);
                    to_place = 1;
                    if ((height/2 <i) && (center<width/3 || center>width*2/3))
                        to_place = 2;
                    row[center] = to_place;
                    row[center+1] = to_place;

                    center = Random.Range(0, width-1);
                    to_place = 1;
                    if ((height/2 <i) && (center<width/3 || center>width*2/3))
                        to_place = 2;
                    row[center] = to_place;
                    row[center+1] = to_place;

                    center = Random.Range(0, width-1);
                    to_place = 1;
                    if ((height/2 <i) && (center<width/3 || center>width*2/3))
                        to_place = 2;
                    row[center] = to_place;
                    row[center+1] = to_place;

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
                int ones_start = -1;
                int ones_end = -1;
                for(int j=0;j<width;j++)
                {
                    if(total_str[i*width+j] == '1')
                    {
                        Instantiate(platform, new Vector3(-7.75f + j*0.5f, -3f + i*(0.5f+2f),0), Quaternion.identity);

                        if (ones_start == -1)
                        {
                            ones_start = j;
                            ones_end = -1;
                        }
                    }
                    else if(total_str[i*width+j] == '0' || total_str[i*width+j] == '2')
                    {
                        if (ones_start > -1)
                        {
                            ones_end = j -1;

                            Instantiate(branch, new Vector3(-7.75f + (ones_start+ones_end)*0.25f, -3f + i*(0.5f+2f),0), Quaternion.identity);

                            ones_start = -1;

                        }

                    }
                if(total_str[i*width+j] == '2')
                {
                    Instantiate(cloud, new Vector3(-7.75f + j*0.5f, -3f + i*(0.5f+2f),0), Quaternion.identity);
                }

                }
                if (ones_end == -1 && ones_start != -1)
                {
                    ones_end = width -1;
                    Instantiate(branch, new Vector3(-7.75f + (ones_start+ones_end)*0.25f, -3f + i*(0.5f+2f),0), Quaternion.identity);

                }


            }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
