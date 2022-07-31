using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void load_scene_1()
    {
        StartCoroutine(loading_level(1));
       
    }

    public void load_main_menu()
    {
        StartCoroutine(loading_level(0));

    }

    public void exit_application()
    {
        Application.Quit();
    }

    IEnumerator loading_level(int sceneindex)
    {

        yield return new WaitForSeconds(.5f);
       SceneManager.LoadScene(sceneindex);

    }
}
