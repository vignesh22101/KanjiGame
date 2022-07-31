using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class call_text_change_function_startscreen : MonoBehaviour
{
    public database_startscreen_forms three_form_database;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void change_the_text()
    {
        three_form_database.change_the_form();
    }
}
