using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class learnippet_data_struct: MonoBehaviour
{
    //datastructure is declared here

    public learnippet_data_struct(char Kanji,string[] Rei_kanji,string[] Rei_furigana,string[] Rei_english,string[] Onyomi,string[] Kunyomi,string Story="",string Overallmeaning="")
    {
        kanji = Kanji;
        rei_english = Rei_english;
        rei_furigana = Rei_furigana;
        rei_kanji = Rei_kanji;
        kunyomi = Kunyomi;
        onyomi = Onyomi;
        story = Story;
        overallmeaning = Overallmeaning;
    }
    public char kanji;
    public string[] onyomi;
    public string[] kunyomi;
    public string[] rei_kanji;
    public string[] rei_furigana;
    public string[] rei_english;
    public Image kanji_mnemonic;
    public string story;
    public string  overallmeaning;
  
}
