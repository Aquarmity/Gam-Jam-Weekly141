using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPress : MonoBehaviour
{
    public LevelLoader lvloader;
    public void PlayGame () {
        lvloader.LoadNextLevel();
    }
}
