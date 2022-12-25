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
    public GameObject santa;
    public GameObject tree;
    public GameObject bird;
    public Material material;
    public int birdRandom = 10;
    private float branch_kalinlik = 0.25f;
    private float hah = 0.15f;

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
                Instantiate(tree, new Vector3(0, -4f+i*(0.5f+2f),0), Quaternion.identity);
                Instantiate(tree, new Vector3(0, -4f+i*(0.5f+2f)+0.5f,0), Quaternion.identity);
                Instantiate(tree, new Vector3(0, -4f+i*(0.5f+2f)+1f,0), Quaternion.identity);
                Instantiate(tree, new Vector3(0, -4f+i*(0.5f+2f)+1.5f,0), Quaternion.identity);
                Instantiate(tree, new Vector3(0, -4f+i*(0.5f+2f)+2f,0), Quaternion.identity);

                if (Random.Range(0, birdRandom) == 0){
                    Instantiate(bird, new Vector3(0, -4f+i*(0.5f+2f)+1f,0), Quaternion.identity);
                }

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
                            float leaf_center_x = -7.75f + (ones_start+ones_end)*0.25f;
                            float branch_cneter_x = leaf_center_x/2;
                            float leaf_center_y = -3f + i*(0.5f+2f);
                            float branch_center_y = leaf_center_y - Mathf.Abs(branch_cneter_x);
                            
                            
                            float k_end = leaf_center_x/hah;
                            float birim = hah;
                            if(k_end< 0){
                                k_end = -k_end;
                                birim = -birim;
                            }
                            float birim_y = 2/k_end;
                            
                            for(int k = 0; k < k_end; k++)
                            {
                                GameObject x = Instantiate(branch, new Vector3(-7.75f + (ones_start+ones_end)*0.25f, -3f + i*(0.5f+2f),0), Quaternion.identity);
                                LineRenderer l = x.AddComponent<LineRenderer>();
                                l.material = material;
                                // change order layer of line renderer
                                l.sortingOrder = -2;
                                List<Vector3> pos = new List<Vector3>();
                                pos.Add(new Vector3(0+k*birim, leaf_center_y-2 + k*birim_y));
                                pos.Add(new Vector3(0+(k+1)*birim, leaf_center_y-2 + (k+1)*birim_y));
                                l.startWidth = branch_kalinlik;
                                l.endWidth = branch_kalinlik;
                                l.SetPositions(pos.ToArray());
                                l.useWorldSpace = true;
                            }

                            // GameObject x = Instantiate(branch, new Vector3(-7.75f + (ones_start+ones_end)*0.25f, -3f + i*(0.5f+2f),0), Quaternion.identity);
                            // LineRenderer l = x.AddComponent<LineRenderer>();
                            // l.material = material;
                            // List<Vector3> pos = new List<Vector3>();
                            // pos.Add(new Vector3(0, leaf_center_y-2));
                            // pos.Add(new Vector3(leaf_center_x, leaf_center_y));
                            // l.startWidth = 0.25f;
                            // l.endWidth = 0.25f;
                            // l.SetPositions(pos.ToArray());
                            // l.useWorldSpace = true;
                            

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
                    float leaf_center_x = -7.75f + (ones_start+ones_end)*0.25f;
                    float branch_cneter_x = leaf_center_x/2;
                    float leaf_center_y = -3f + i*(0.5f+2f);
                    float branch_center_y = leaf_center_y - Mathf.Abs(branch_cneter_x);
                    
                    
                    float k_end = leaf_center_x/hah;
                    float birim = hah;
                    if(k_end< 0){
                        k_end = -k_end;
                        birim = -birim;
                    }
                    float birim_y = 2/k_end;
                    
                    for(int k = 0; k < k_end; k++)
                    {
                        GameObject x = Instantiate(branch, new Vector3(-7.75f + (ones_start+ones_end)*0.25f, -3f + i*(0.5f+2f),0), Quaternion.identity);
                        LineRenderer l = x.AddComponent<LineRenderer>();
                        l.material = material;
                        l.sortingOrder = -2;
                        List<Vector3> pos = new List<Vector3>();
                        pos.Add(new Vector3(0+k*birim, leaf_center_y-2 + k*birim_y));
                        pos.Add(new Vector3(0+(k+1)*birim, leaf_center_y-2 + (k+1)*birim_y));
                        l.startWidth = branch_kalinlik;
                        l.endWidth = branch_kalinlik;
                        l.SetPositions(pos.ToArray());
                        l.useWorldSpace = true;
                    }

                }

		
            }

		Instantiate(santa, new Vector3(0, -4f+height*(0.5f+2f),0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
