using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Player : MonoBehaviour {
    public int PlayerNumber;
    public abstract void Play(CellGrid cellGrid);
}
