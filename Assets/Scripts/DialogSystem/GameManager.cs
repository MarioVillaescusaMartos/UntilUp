using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform gameCamera;

    public Transform[] cameraPositions;

    public enum CinematicCommandId
    {
        enterCinematicMode,
        exitCinematicMode,
        wait,
        log,
        setCameraPosition,
        setCameraSize,
        showDialog,
        setObjectActive,
        setObjectPosition,
        setLightning
    };

    [System.Serializable]
    public struct CinematicCommand
    {
        public CinematicCommandId id;
        public string param1;
        public string param2;
        public string param3;
        public string param4;

    };

    [Header("Cinematic system")]
    public CinematicCommand[] commands;

    [Header("Light System")]
    public Transform lightPoint;
    public Color lightColor;


    [Header("Dialog system")]
    public Transform[] dialogCommon;
    public Transform[] dialogCharacters;
    public Transform dialogText;

    [System.Serializable]
    public struct DialogData
    {
        public int character;
        public string text;

    };

    public DialogData[] dialogsData;

    //Objects
    public Transform[] objects;
    public Transform[] objectsPosition;
    int objectActive;

    // Cinematic system
    int commandIndex;

    bool waiting;
    float waitTimer;

    Vector3 originalPos;
    GameCamera originalSize;

    // Dialogs system

    bool isCinematicMode;

    bool showingDialog;

    //TextMeshPro dialogTextC;
    Text dialogTextC;

    int dialogIndex;

    GameCamera gameCameraC;

    //Lightning System
    Light lt;

    // Start is called before the first frame update
    void Start()
    {
        // Init state

        isCinematicMode = false;
        waiting = false;

        // Init dialog system

        showingDialog = false;
        dialogIndex = 0;

        //dialogTextC = dialogText.GetComponent<TextMeshPro>();
        dialogTextC = dialogText.GetComponent<Text>();

        gameCameraC = gameCamera.GetComponent<GameCamera>();

        lt = lightPoint.GetComponent<Light>();
    }



    // Update is called once per frame
    void Update()
    {
        if(isCinematicMode)
        {
            if (showingDialog)
            {
                for (int i = 0; i < dialogCommon.Length; i++) { dialogCommon[i].gameObject.SetActive(true); }
                for (int i = 0; i < dialogCharacters.Length; i++) { dialogCharacters[i].gameObject.SetActive(false); }

                int character = dialogsData[dialogIndex].character;
                string text = dialogsData[dialogIndex].text;

                dialogCharacters[character].gameObject.SetActive(true);
                dialogTextC.text = text;


                if (Input.GetKeyDown(KeyCode.Return))
                {
                    showingDialog = false;
                    for (int i = 0; i < dialogCommon.Length; i++) { dialogCommon[i].gameObject.SetActive(false); }
                    for (int i = 0; i < dialogCharacters.Length; i++) { dialogCharacters[i].gameObject.SetActive(false); }
                    commandIndex++;
                }

            }
            else if (waiting)
            {
                if (waitTimer <= 0)
                {
                    waiting = false;
                    commandIndex++;
                }
                else
                {
                    waitTimer -= Time.deltaTime;
                }
            }
            else if (commandIndex < commands.Length)
            {
                CinematicCommand command = commands[commandIndex];

                if (command.id == CinematicCommandId.enterCinematicMode)
                {
                    isCinematicMode = true;

                    PauseManager.pauseMode = true;

                    Time.timeScale = 0f;

                    Debug.Log("EnterCinematicMode");
                }
                else if (command.id == CinematicCommandId.exitCinematicMode)
                {
                    isCinematicMode = false;

                    PauseManager.pauseMode = false;

                    Time.timeScale = 1f;

                    Debug.Log("ExitCinematicMode");
                }
                else if (command.id == CinematicCommandId.wait)
                {
                    float time = Single.Parse(command.param1);

                    waiting = true;
                    waitTimer = time;
                }
                else if (command.id == CinematicCommandId.log)
                {
                    string message = command.param1;

                    Debug.Log("Cinematic Log: " + message);
                }
                else if (command.id == CinematicCommandId.showDialog)
                {
                    int index = Int32.Parse(command.param1);

                    showingDialog = true;
                    dialogIndex = index;
                }
                else if (command.id == CinematicCommandId.setCameraPosition)
                {
                    int index = Int32.Parse(command.param1);

                    gameCamera.position = cameraPositions[index].position;
                }
                else if (command.id == CinematicCommandId.setCameraSize)
                {
                    float size = Single.Parse(command.param1);

                    gameCameraC.SetSize(size);
                }
                else if (command.id == CinematicCommandId.setObjectActive)
                {
                    int objectIndex = Int32.Parse(command.param1);
                    int active = Int32.Parse(command.param2);

                    if (active == 1)
                    {
                        objects[objectIndex].gameObject.SetActive(true);
                    }
                    else
                    {
                        objects[objectIndex].gameObject.SetActive(false);
                    }

                    objectActive = active;
                }
                else if (command.id == CinematicCommandId.setObjectPosition)
                {
                    int objectIndex = Int32.Parse(command.param1);
                    int index = Int32.Parse(command.param2);

                    if (objectActive == 1)
                    {
                        objects[objectIndex].position = objectsPosition[index].position;
                    }
                    else
                    {
                        Debug.Log("No Active");
                    }
                }
                else if (command.id == CinematicCommandId.setLightning)
                {
                    float timeFade = Single.Parse(command.param1);
                    float maxIntesity = Single.Parse(command.param2);

                    lt.color = lightColor;

                    if (lt.intensity >= maxIntesity)
                    {
                        lt.intensity -= timeFade;
                    }
                    else if (lt.intensity <= 0)
                    {
                        lt.intensity += timeFade;
                    } 
                }
                else
                {
                    Debug.Log("Comando de cinematica no implementado");
                }



                if (!waiting && !showingDialog)
                {
                    commandIndex++;
                }
            }
            else
            {
                isCinematicMode = false;
            }

        }
    }

    public void OnTriggerCinematic(int index)
    {

        if(!isCinematicMode)
        {
            isCinematicMode = true;
            commandIndex = 0;
        }
        else
        {
            Debug.Log("No puede iniciarse la cinematica " + index + " porque ya hay una en ejecucion");
        }

        //showingDialog = true;
        //dialogIndex = index;
    }

    public bool IsCinematicMode()
    {
        return isCinematicMode;
    }    
}
