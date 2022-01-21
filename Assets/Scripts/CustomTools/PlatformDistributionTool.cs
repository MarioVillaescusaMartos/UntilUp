using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlatformDistributionTool : MonoBehaviour
{
    [SerializeField]
    private Camera gameCamera;

    [SerializeField]
    private GameObject[] platforms;

    [SerializeField]
    private float minSeparationY;
    [SerializeField]
    private float maxSeparationY;

    private float numGenSeperationX;

    [SerializeField]
    private bool distribute;

    private int prefabPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (distribute)
        { 
            for (int i = 0; i < platforms.Length; i++)
            {
                float numGenSeparationY = UnityEngine.Random.Range(minSeparationY, maxSeparationY);
                
                if (i == 0)
                {
                    prefabPosition = i;
                }
                else
                {
                    prefabPosition = i - 1;
                }

                if (platforms[i].transform.position.y == platforms[i + 1].transform.position.y)
                {
                    for (int r = 0; r < 2; r++)
                    {
                        numGenSeperationX = UnityEngine.Random.Range(-gameCamera.orthographicSize, gameCamera.orthographicSize);
                        Debug.Log("r: " + r + " X: " + numGenSeperationX + " Y: " + numGenSeparationY);
                        platforms[i].transform.position = new Vector3(numGenSeperationX, platforms[prefabPosition].transform.position.y + numGenSeparationY, 0);
                    }
                }
                else
                {
                    numGenSeperationX = UnityEngine.Random.Range(-gameCamera.orthographicSize, gameCamera.orthographicSize);

                    platforms[i].transform.position = new Vector3(numGenSeperationX, platforms[prefabPosition].transform.position.y + numGenSeparationY, 0);
                }
            }

            distribute = false;
        }
    }
    public void DoPlatformDistributionOnY()
    {
        distribute = true;
        Update();
    }

    [MenuItem("Custom Tools//Distribute On Y Platforms")]
    private static void DistributeOnYPlatforms()
    {
        Debug.Log("Generating Platforms");

        GameObject go = GameObject.Find("PlatformCreatorTool");
        PlatformDistributionTool editor = go.GetComponent<PlatformDistributionTool>();
        editor.DoPlatformDistributionOnY();
    }

}
