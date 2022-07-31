using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class datastruct_forkanjidata : MonoBehaviour
{
    //datastructure is declared here
    //this is used for testing data parsing from csv files
    public datastruct_forkanjidata(string data_split)
    {       
        string[] data = data_split.Split(',');
        Debug.Log("data splitted by ,"+data[20]);
        foreach (var item in data)
        {
            Debug.Log(item);
        } 
        {

        }
        for (int i=0;i<4;i++)
        {
            rei_kanji[i] = data[i + 1];
           rei_furigana[i] = data[i + 5];
            rei_english[i] = data[i + 9];
            onyomi[i] = data[i + 13];
            kunyomi[i] = data[i + 17];
        }
        kanji = data[0];
        story = data[21];
       overallmeaning = data[22];
    }
    public string kanji;
    public string[] onyomi = new string[4];
    public string[] kunyomi = new string[4];
    public string[] rei_kanji = new string[4];
    public string[] rei_furigana = new string[4];
    public string[] rei_english = new string[4];
    public Image kanji_mnemonic;
    public string story;
    public string overallmeaning;

}
