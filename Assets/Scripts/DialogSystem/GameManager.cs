using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool activeTimeScale;

    public Transform gameCamera;

    public Transform[] cameraPositions;

    public Transform lightPoint;

    public Transform[] lightPositions;

    public GameObject[] sounds;

    public enum CinematicCommandId
    {
        enterCinematicMode,
        exitCinematicMode,
        wait,
        log,
        setCameraPosition,
        setCameraSize,
        cameraZoom,
        setLightPosition,
        showDialog,
        setObjectActive,
        setObjectPosition,
        loadNextScene,
        loadSound
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

    //Camera zoom
    bool zoom;
    float zoomSpeed;
    float cameraSize;

    //Sounds System
    float time;

    // Dialogs system
    bool isCinematicMode;

    bool showingDialog;

    //TextMeshPro dialogTextC;
    Text dialogTextC;

    int dialogIndex;

    GameCamera gameCameraC;

    CinematicSounds cinSound;

    // Start is called before the first frame update
    void Start()
    {
        // Init state

        isCinematicMode = false;
        waiting = false;
        zoom = false;

        // Init dialog system

        showingDialog = false;
        dialogIndex = 0;

        //dialogTextC = dialogText.GetComponent<TextMeshPro>();
        dialogTextC = dialogText.GetComponent<Text>();

        gameCameraC = gameCamera.GetComponent<GameCamera>();

        cinSound = gameCamera.GetComponent<CinematicSounds>();
    }



    // Update is called once per frame
    void Update()
    {
        if (activeTimeScale)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0f;
        }

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
                    Debug.Log(waitTimer);
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

                    Debug.Log("Show Dielog: " + index);

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
                else if (command.id == CinematicCommandId.cameraZoom)
                {
                    float minSize = Single.Parse(command.param1);
                    //float speed = Single.Parse(command.param2);
                    float camSize = Single.Parse(command.param2);

                    if (!zoom)
                    {
                        zoom = true;
                        cameraSize = camSize;
                        originalPos = gameCamera.localPosition;
                    }

                    if (zoom)
                    {
                        if (cameraSize <= minSize)
                        {
                            zoom = false;
                        }
                        else
                        {
                            cameraSize -= Time.deltaTime;
                            gameCameraC.SetSize(cameraSize);
                            Debug.Log(cameraSize);
                        }
                    }
                }
                else if (command.id == CinematicCommandId.setLightPosition)
                {
                    int index = Int32.Parse(command.param1);

                    lightPoint.position = lightPositions[index].position;
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
                else if (command.id == CinematicCommandId.loadNextScene)
                {
                    string sceneName = command.param1;

                    SceneManager.LoadScene(sceneName);
                }
                else if (command.id == CinematicCommandId.loadSound)
                {
                    int index = Int32.Parse(command.param1);
                    int time = Int32.Parse(command.param2);

                    cinSound.SoundEmition(sounds[index], transform.position, time);
                }
                else
                {
                    Debug.Log("Comando de cinematica no implementado");
                }



                if (!waiting && !showingDialog && !zoom)
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
