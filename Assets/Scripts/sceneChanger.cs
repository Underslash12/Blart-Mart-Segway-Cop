using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneChanger : MonoBehaviour
{
    public void changeScene(string s){
        SceneManager.LoadScene(s);
    }
}
