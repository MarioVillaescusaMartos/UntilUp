using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Transform comet;
    public Transform moon;

    public float rotationC = 30;
    public float distanceC = 5;
    public float scaleC = 0.5f;
    public float rotationSpeedC = 10;

    public float rotationM = 60;
    public float rotationSpeedM = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Matrix4x4 Central = transform.localToWorldMatrix;

        Matrix4x4 MComet = Central * Matrix4x4.Rotate(Quaternion.Euler(0, 0, rotationC * 360.0f)) *
                                   Matrix4x4.Translate(new Vector3(distanceC, 0, 0)) *
                                   Matrix4x4.Scale(new Vector3(scaleC, scaleC, 1));

        comet.position = MComet.MultiplyPoint(new Vector3(0, 0, 0));
        comet.localScale = MComet.lossyScale;

        rotationC += rotationSpeedC * Time.deltaTime;

        Matrix4x4 MMoon = Central * Matrix4x4.Rotate(Quaternion.Euler(0, 0, rotationM));

        rotationM += rotationSpeedM * Time.deltaTime;

        moon.position = MMoon.MultiplyPoint(new Vector3(0, 0, 0));
        moon.localScale = MMoon.lossyScale;
    }
}
