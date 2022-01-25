using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SetOffMenuObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject displayUI;

    public void UnShowGameObject()
    {
        displayUI.SetActive(false);
    }
}
