using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class call_text_change_function : MonoBehaviour
{
    public database_for_three_forms three_form_database;
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
