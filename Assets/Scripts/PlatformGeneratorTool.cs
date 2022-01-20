using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PlatformGeneratorTool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabPlatform;

    [SerializeField]
    private int numPlatforms;

    [SerializeField]
    private float minSeparationY;
    [SerializeField]
    private float maxSeparationY;
    [SerializeField]
    private float separationX;

    [SerializeField]
    private bool generatePlatforms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (generatePlatforms)
        {
            GameObject gameo = new GameObject("Platforms");

            for (int i = 0; i < numPlatforms; i++)
            {
                int numGenPrefab = UnityEngine.Random.Range(0, prefabPlatform.Length);
                float numGenSeparationY = UnityEngine.Random.Range(minSeparationY, maxSeparationY);
                int numGenChoosePlatformOnX = UnityEngine.Random.Range(0, 2);

                Debug.Log(i);
                Debug.Log(numGenSeparationY);

                if (numGenChoosePlatformOnX == 1)
                {
                    for (int r = 0; r < 2; r++)
                    {
                        GameObject go = (GameObject)GameObject.Instantiate(prefabPlatform[numGenPrefab], transform.position + Vector3.up * numGenSeparationY * i
                            , transform.rotation);
                        go.transform.parent = gameo.transform;

                    }
                    //Debug.Log("2" + i);
                }
                else
                {
                    GameObject go = (GameObject)GameObject.Instantiate(prefabPlatform[numGenPrefab], transform.position + Vector3.up * numGenSeparationY * i
                        , transform.rotation);
                    go.transform.parent = gameo.transform;
                    //Debug.Log("0");
                }

                

            }
        }

        generatePlatforms = false;
    }

    public void DoPlatformGenerator()
    {
        generatePlatforms = true;
        Update();
    }

    [MenuItem("Custom Tools//Generate Platforms")]
    private static void GeneratePlatforms()
    {
        Debug.Log("Generating Platforms");

        GameObject go = GameObject.Find("PlatformCreatorTool");
        PlatformGeneratorTool editor = go.GetComponent<PlatformGeneratorTool>();
        editor.DoPlatformGenerator();
    }

}
