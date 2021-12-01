using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursividadExplosion : MonoBehaviour
{
    //Paleta colores para las diferentes zonas de la explosion
    public Color fireColorCenter;
    public Color fireColorMiddle;
    public Color fireColorExterior;

    //Aqui se indica la dispersion que tendran las diferentes zonas de la explosion, los valores van ordenados dependiendo de la zona a pintar ([0] = centro, [1] = medio, [2] = exterior)
    public float fireDispersionCenter;
    public float fireDispersionMiddle;
    public float fireDispersionExterior;

    //Aqui se indican las escalas de los prefabs, los valores van ordenados dependiendo de la zona a pintar ([0] = centro, [1] = medio, [2] = exterior)
    public float[] fireScaleX;
    public float[] fireScaleY;

    //Prefab y material de la explosion
    public GameObject[] firePrefab;
    Material fireMaterialCenter;
    Material fireMaterialMiddle;
    Material fireMaterialExterior;

    public float fireDuration;
    float fireTimer;

    //Boleano para decidir cuando generar la explosion
    public bool active;
    public bool activeCenter;
    public bool activeMiddle;
    public bool activeExterior;
    public bool explosionLoop;

    //explosionGenerator genera la explosion
    void explosionGeneratorCenter(Vector3 position, float scaleX, float scaleY)
    {
        if (scaleY < 0.2f)
        {
            GameObject go = (GameObject)GameObject.Instantiate(firePrefab[0], position, Quaternion.identity);
            go.transform.localScale = new Vector3(scaleX, scaleY, 1);
        }
        else
        {
            GameObject go = (GameObject)GameObject.Instantiate(firePrefab[0], position, Quaternion.identity);
            go.transform.localScale = new Vector3(scaleX, scaleY, 1);

            float x = UnityEngine.Random.Range(-1, fireDispersionCenter / 2);
            float y = UnityEngine.Random.Range(-1, fireDispersionCenter / 2);
            Vector3 p1 = new Vector3(x, y, -0.2f);

            explosionGeneratorCenter(p1, scaleX / 2, scaleY / 2);


            x = UnityEngine.Random.Range(-1, fireDispersionCenter / 2);
            y = UnityEngine.Random.Range(-1, fireDispersionCenter / 2);
            Vector3 p2 = position + new Vector3(x, y, 0);

            explosionGeneratorCenter(p2, scaleX / 2, scaleY / 2);

            x = UnityEngine.Random.Range(-1, fireDispersionCenter / 2);
            y = UnityEngine.Random.Range(-1, fireDispersionCenter / 2);
            Vector3 p3 = position + new Vector3(x, y, 0);

            explosionGeneratorCenter(p3, scaleX / 2, scaleY / 2);
        }
    }

    void explosionGeneratorMiddle(Vector3 position, float scaleX, float scaleY)
    {
        if (scaleY < 0.2f)
        {
            GameObject go = (GameObject)GameObject.Instantiate(firePrefab[1], position, Quaternion.identity);
            go.transform.localScale = new Vector3(scaleX, scaleY, 1);
        }
        else
        {

            GameObject go = (GameObject)GameObject.Instantiate(firePrefab[1], position, Quaternion.identity);
            go.transform.localScale = new Vector3(scaleX, scaleY, 1);

            float x = UnityEngine.Random.Range(0, fireDispersionMiddle / 2);
            float y = UnityEngine.Random.Range(0, fireDispersionMiddle / 2);
            Vector3 p1 = new Vector3(x, y, -0.1f);

            explosionGeneratorMiddle(p1, scaleX / 2, scaleY / 2);

            x = UnityEngine.Random.Range(0, fireDispersionMiddle / 2);
            y = UnityEngine.Random.Range(0, fireDispersionMiddle / 2);
            Vector3 p2 = position + new Vector3(x, y, 0);

            explosionGeneratorMiddle(p2, scaleX / 2, scaleY / 2);

            x = UnityEngine.Random.Range(0, fireDispersionMiddle / 2);
            y = UnityEngine.Random.Range(0, fireDispersionMiddle / 2);
            Vector3 p3 = position + new Vector3(x, y, 0);

            explosionGeneratorMiddle(p3, scaleX / 2, scaleY / 2);
        }
    }

    void explosionGeneratorExterior(Vector3 position, float scaleX, float scaleY)
    {
        if (scaleY < 0.2f)
        {
            GameObject go = (GameObject)GameObject.Instantiate(firePrefab[2], position, Quaternion.identity);
            go.transform.localScale = new Vector3(scaleX, scaleY, 1);
        }
        else
        {

            GameObject go = (GameObject)GameObject.Instantiate(firePrefab[2], position, Quaternion.identity);
            go.transform.localScale = new Vector3(scaleX, scaleY, 1);

            float x = UnityEngine.Random.Range(0, fireDispersionExterior / 2);
            float y = UnityEngine.Random.Range(0, fireDispersionExterior / 2);
            Vector3 p1 = new Vector3(x, y, 0.1f);

            explosionGeneratorExterior(p1, scaleX / 2, scaleY / 2);

            x = UnityEngine.Random.Range(0, fireDispersionExterior / 2);
            y = UnityEngine.Random.Range(0, fireDispersionExterior / 2);
            Vector3 p2 =  position + new Vector3(x, y, 0);

            explosionGeneratorExterior(p2, scaleX / 4, scaleY / 4);

            x = UnityEngine.Random.Range(0, fireDispersionExterior / 2);
            y = UnityEngine.Random.Range(0, fireDispersionExterior / 2);
            Vector3 p3 = position + new Vector3(x, y, 0);

            explosionGeneratorExterior(p3, scaleX / 2, scaleY / 2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mrCenter = firePrefab[0].GetComponent<MeshRenderer>();
        MeshRenderer mrMiddle = firePrefab[1].GetComponent<MeshRenderer>();
        MeshRenderer mrExterior = firePrefab[2].GetComponent<MeshRenderer>();

        fireMaterialCenter = mrCenter.sharedMaterial;
        fireMaterialMiddle = mrMiddle.sharedMaterial;
        fireMaterialExterior = mrExterior.sharedMaterial;

        fireTimer = 0;

        explosionLoop = false;
    }

    private void OnDrawGizmos()
    {
        if (Switches.debugMode && Switches.debugShowGizmoCenter)
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawWireSphere(transform.position, fireDispersionCenter);

        }
        if (Switches.debugMode && Switches.debugShowGizmoMiddle)
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawWireSphere(transform.position, fireDispersionMiddle);

        }
        if (Switches.debugMode && Switches.debugShowGizmoExterior)
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(transform.position, fireDispersionExterior);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer + Time.deltaTime > fireDuration)
        {
            fireTimer = 0;
        }
        else
        {
            fireTimer += Time.deltaTime;
        }

        if (activeCenter)
        {
            Debug.Log("Active center");

            explosionGeneratorCenter(transform.position, fireScaleX[0], fireScaleY[0]);

        }
        if (activeMiddle)
        {
            Debug.Log("Active middle");

            explosionGeneratorMiddle(transform.position, fireScaleX[1], fireScaleY[1]);

        }

        if (activeExterior)
        {
            Debug.Log("Active exterior");

            explosionGeneratorExterior(transform.position, fireScaleX[2], fireScaleY[2]);
        }

        if (active)
        {
            explosionGeneratorExterior(transform.position, fireScaleX[2], fireScaleY[2]); 
            explosionGeneratorMiddle(transform.position, fireScaleX[1], fireScaleY[1]);
            explosionGeneratorCenter(transform.position, fireScaleX[0], fireScaleY[0]);
        }

        fireMaterialExterior.color = new Color(fireColorExterior.r, fireColorExterior.g, fireColorExterior.b, fireTimer / fireDuration);
        fireMaterialMiddle.color = new Color(fireColorMiddle.r, fireColorMiddle.g, fireColorMiddle.b, fireTimer / fireDuration );
        fireMaterialCenter.color = new Color(fireColorCenter.r, fireColorCenter.g, fireColorCenter.b, fireTimer / fireDuration );


        active = false;
        activeCenter = false;
        activeMiddle = false;
        activeExterior = false;
    }
}
