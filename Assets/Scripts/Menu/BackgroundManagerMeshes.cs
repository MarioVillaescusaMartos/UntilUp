using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class BackgroundManagerMeshes : MonoBehaviour
{
    public Mesh model;

    public Material mComet;
    public Material mStar;
    public Material mMoon;

    public int numStars;
    public int numComets;

    public float rotationM;

    public float rotacionC;
    public float distanciaC;
    public float escalaC;

    public float velocidadRotacionC;
    public float velocidadRotacionM;

    public float anchoCampoEstrellas;
    public float altoCampoEstrellas;
    public float distanciaCampoEstrellas;

    public float velocidadEscalaEstrellas;

    Vector3[] posicionesEstrellas;
    float[] escalasEstrellas;

    Matrix4x4[] matricesEstrellas;
    Matrix4x4[] matricesEstrellasEscaladas;

    float escalaEstrellas;



    // Start is called before the first frame update
    void Start()
    {
        posicionesEstrellas = new Vector3[numStars];
        matricesEstrellas = new Matrix4x4[numStars];
        matricesEstrellasEscaladas = new Matrix4x4[numStars];

        escalasEstrellas = new float[numStars];

        for (int i = 0; i < numStars; i++)
        {
            posicionesEstrellas[i] = new Vector3(UnityEngine.Random.Range(-anchoCampoEstrellas / 2, anchoCampoEstrellas / 2),
                                                  UnityEngine.Random.Range(-altoCampoEstrellas / 2, altoCampoEstrellas / 2),
                                                  distanciaCampoEstrellas
                                                );
            matricesEstrellas[i] = Matrix4x4.Translate(posicionesEstrellas[i]);

            escalasEstrellas[i] = UnityEngine.Random.Range(1, 2.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Matrix4x4 Pivot = transform.localToWorldMatrix;

        Matrix4x4 MMoon = Pivot * Matrix4x4.Rotate(Quaternion.Euler(0, 0, rotationM * 360.0f));
        Graphics.DrawMesh(model, MMoon, mMoon, 0);

        for (int i = 0; i < numComets; i++)
        {
            Matrix4x4 MComet = Pivot * Matrix4x4.Rotate(Quaternion.Euler(0, 0, rotacionC + i * 360.0f / numComets)) *
                                   Matrix4x4.Translate(new Vector3(distanciaC, 0, 0)) *
                                   Matrix4x4.Scale(new Vector3(escalaC, escalaC, 1));

            Graphics.DrawMesh(model, MComet, mComet, 0);
        }

        RotationsCalculate();
        

        Debug.Log(rotacionC + " " + rotationM);

        for (int i = 0; i < numStars; i++)
        {
            float s = escalasEstrellas[i];
            matricesEstrellasEscaladas[i] = matricesEstrellas[i] * Matrix4x4.Scale(new Vector3(s, s, 1));
        }

        //Graphics.DrawMeshInstanced(model, 0, mStar, matricesEstrellasEscaladas);


        escalaEstrellas += velocidadEscalaEstrellas * Time.deltaTime;

        if (escalaEstrellas > 1.0f)
        {
            escalaEstrellas = 0;
        }
    }

    void RotationsCalculate()
    {
        rotacionC += velocidadRotacionC * Time.deltaTime;
        rotationM += velocidadRotacionM * Time.deltaTime;
    }
}