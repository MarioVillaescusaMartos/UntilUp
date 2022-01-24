using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string username;
    public static int id;
    public static int health;
    public static int blasterbullet;
    public static int laserbullet;
    public static int score;
    public static int attempt;
    public static float posX;
    public static float posY;

    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }
}