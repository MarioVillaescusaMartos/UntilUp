using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PooledItems  //Esta clase servira para identidicar cada lista
{
    public string Name;  //El identificador de la lista
    public GameObject objectToPool;  //El objeto que queremos multilicar
    public int amount;  //La cantidad de instancias iniciales
}

public class PoolingManager: MonoBehaviour
{
    /*private static PoolingManager _instance;
    public static PoolingManager Instance => _instance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amount;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amount; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }*/



    private static PoolingManager _instance;
    public static PoolingManager Instance
    {
        get  //Para asegurarnos de que se crea la instancia antes que nada
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolingManager>();
            }
            return _instance;
        }
    }

    //Lista de todos los objetos que vamos a multiplicar
    [SerializeField]
    private List<PooledItems> pooledLists = new List<PooledItems>();

    [SerializeField]
    private Dictionary<string, List<GameObject>> _items = new Dictionary<string, List<GameObject>>();

    private void Awake()
    {
        for (int i = 0; i < pooledLists.Count; i++)  //Para cada lista de objetos
        {
            PooledItems l = pooledLists[i];
            _items.Add(l.Name, new List<GameObject>());  //creamos una entrada en
                                                    //el Dictionary                                                     
            for (int j = 0; j < l.amount; j++)  //y añadimos las copias
            {
                GameObject tmp;
                tmp = Instantiate(l.objectToPool);  //Aqui creamos la copia
                tmp.SetActive(false);  //la desactivamos
                _items[l.Name].Add(tmp);  //y la añadimos a la lista
            }
        }
    }

    public GameObject GetPooledObject (string name)  //Para obtener una copia
                                                     //es necesario especificar el nombre de la
                                                     //lista de donde lo vamos a obtener
    {
        List<GameObject> tmp = _items[name];
        for (int i = 0; i < tmp.Count; i++)
        {
            if (!tmp[i].activeInHierarchy)
            {
                return tmp[i];
            }
        }
        return null;
    }
}