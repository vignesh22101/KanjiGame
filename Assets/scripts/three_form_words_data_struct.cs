using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class three_form_words_data_struct : MonoBehaviour
{
    public string[]  data=new string[3];
    public int current_index=0;
    public three_form_words_data_struct(string[] Data,int Current_index=0)
    {

        data = Data;
    }
}
