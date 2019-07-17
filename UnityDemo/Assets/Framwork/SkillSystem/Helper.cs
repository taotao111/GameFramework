using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper {
    /// <summary>
    /// create new gameobject
    /// </summary>
    /// <returns></returns>
    public static GameObject NewGameObject()
    {
        GameObject go = new GameObject();
        return go;
    }
    /// <summary>
    /// create new gameobject
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static GameObject NewGameObject(string name)
    {
        GameObject go = new GameObject(name);
        return go;
    }
}
