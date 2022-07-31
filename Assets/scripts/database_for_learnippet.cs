using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class database_for_learnippet : MonoBehaviour
{
    // Start is called before the first frame update
    public Text kanji;
    public Text story;
    public GameObject[] rei_english=new GameObject[4];
    public GameObject[] rei_furigana = new GameObject[4];
    public GameObject[] rei_kanji = new GameObject[4];
    public GameObject[] onyomi = new GameObject[4];
    public GameObject[] kunyomi = new GameObject[4];
    public GameObject[] learnt_kanji_kanji = new GameObject[5];
    public GameObject[] learnt_kanji_english= new GameObject[5];
    public Image learnippet_picture_mnemonics;
    public picture_database picture;
   public int current_instance_index=-1;
    learnippet_data_struct current_item;
    //public GameObject learnt_kanji;
    public TextAsset newasset; 
        //database
    #region database
    learnippet_data_struct hito = new learnippet_data_struct('人', new string[] { "人","一人","二人","日本人" }, new string[] { "ひと", "ひとり", "ふたり", "にほんじん" }, new string[] { "person", "one person", "two person", "japanese person" }, new string[] { "ニン", "ジン", "", "" }, new string[] { "ひと", "ーと", "ーり", "" },Overallmeaning:"person");
    learnippet_data_struct ki = new learnippet_data_struct('木', new string[] { "木", "木曜日", "木彫", "高木" }, new string[] { "き", "もくようび", "もくちょう", "こうぼく" }, new string[] { "tree", "thursday", "woodencraft", "tall tree" }, new string[] { "ボク", "モク", "", "" }, new string[] { "き", "こー", "", "" },Overallmeaning:"tree");
    learnippet_data_struct hon = new learnippet_data_struct('本', new string[] { "本", "日本", "日本語", "本部" }, new string[] { "ほん", "にほん", "にほんご", "ほんぶ" }, new string[] { "book", "japan", "japanese", "head office" }, new string[] { "ホン", "", "", "" }, new string[] { "もと", "", "", "" }, "papers(used to create BOOKS[本]) were made by cutting down TREES[木]","book");
    learnippet_data_struct yasumi = new learnippet_data_struct('休', new string[] { "休み", "夏休み", "休憩", "連休" }, new string[] { "やすみ", "なつやすみ", "きゅうけい", "れんきゅう" }, new string[] { "holiday", "summer vacation", "break(free hour)", "consecutive holidays" }, new string[] { "キュウ", "", "", "" }, new string[] { "やす(まる)", "やす(める)", "やす(む)", "" }, "a PERSON[人] is RESTING[休] under a TREE[木]","holiday");
    learnippet_data_struct karada = new learnippet_data_struct('体', new string[] { "体", "体重", "体力", "体育館" }, new string[] { "からだ", "たいじゅう", "たいりょく", "たいいくかん" }, new string[] { "body", "body weight", "physical strength", "gymnasium" }, new string[] { "タイ", "テイ", "", "" }, new string[] { "かたち", "からだ", "", "" }, "a PERSON[人] is reading about BODY[体] parts in a BOOK[本]","body");
   // learnippet_data_struct karada = new learnippet_data_struct('', new string[] { "", "", "", "" }, new string[] { "", "", "", "" }, new string[] { "", "", "", "" }, new string[] { "", "", "", "" }, new string[] { "", "", "", "" });
    //update the list at declaration of instance list
    #endregion

    void Start()
    {

       // read();

        kanji.text = hito.kanji.ToString();
        
       
    }


    void set_learnippet_data()
    {
        
        current_instance_index++;
        var instance_list = new List<learnippet_data_struct>() { hito,ki, hon,yasumi,karada };
        current_item = instance_list[current_instance_index];
        kanji.text = current_item.kanji.ToString();
        learnippet_picture_mnemonics.GetComponent<Image>().sprite = picture.picture_mnemonics[current_instance_index];
        story.GetComponent<Text>().text = current_item.story;
        #region forloops
        //rei_english_loop a for loop that  iterates through the learnippet fields and the corresponding data from database
        /* for (int i = 0; i<4;i++)
         {

             if (current_item.onyomi[i] != null)
             { onyomi[i].GetComponent<Text>().text = current_item.onyomi[i]; }
         }
         for (int i = 0; i < 4; i++)
         {
             if (current_item.kunyomi[i] != null)
             { kunyomi[i].GetComponent<Text>().text = current_item.kunyomi[i]; }
         }
         for (int i = 0; i < 4; i++)
         {

             if (current_item.rei_kanji[i] != null)
             { rei_kanji[i].GetComponent<Text>().text = current_item.rei_kanji[i]; }
         }
         for (int i = 0; i < 4; i++)
         {

             if (current_item.rei_furigana[i] != null)
             { rei_furigana[i].GetComponent<Text>().text = current_item.rei_furigana[i]; }
         }
         for (int i = 0; i < 4; i++)
         {

             if (current_item.rei_english[i] != null)
             { rei_english[i].GetComponent<Text>().text = current_item.rei_english[i]; }
         }
         // calling when 5 kanji are completed
         if (current_instance_index==0)
         {
             for (int i = 0; i < 5; i++)
             {  
                     learnt_kanji_kanji[i].GetComponent<Text>().text = instance_list[i].kanji.ToString();
                 learnt_kanji_english[i].GetComponent<Text>().text = instance_list[i].overallmeaning;
             } 
         }*/
        #endregion



    }

    public void call_set_learnipper_data()
    {
        read();
    }

    public void read()
    {
        current_instance_index++;
        int k = current_instance_index;
        var datas= new List<datastruct_forkanjidata>();
        //string[] data = System.IO.File.ReadAllLines(@"Assets/csv_files/test_file.csv");
        //string[] data = System.IO.File.ReadAllLines(newasset.text);
        string[] data = newasset.text.Split('\n');

        Debug.Log("lenght"+data.Length);

        //loads data from the csv file into the datas variable
        for (int i=0;i<data.Length;i++)
        {
            var kanji_data = new datastruct_forkanjidata(data[i]);
            datas.Add(kanji_data);
        }

        learnippet_picture_mnemonics.GetComponent<Image>().sprite = picture.picture_mnemonics[current_instance_index];

        #region updating data to learnippet from a csv file
        for (int i = 0; i < 4; i++)
        {
            if (datas[k].onyomi[i] != null) onyomi[i].GetComponent<Text>().text = datas[k].onyomi[i];
            if (datas[k].kunyomi[i] != null) kunyomi[i].GetComponent<Text>().text = datas[k].kunyomi[i];
            if (datas[k].rei_kanji[i] != null) rei_kanji[i].GetComponent<Text>().text = datas[k].rei_kanji[i];
            if (datas[k].rei_furigana[i] != null) rei_furigana[i].GetComponent<Text>().text = datas[k].rei_furigana[i];
            if (datas[k].rei_english[i] != null) rei_english[i].GetComponent<Text>().text = datas[k].rei_english[i];        
        }

        kanji.text = datas[k].kanji.ToString();
        story.GetComponent<Text>().text = datas[k].story;
        // calling when 5 kanji are completed

        #endregion

    }
}
