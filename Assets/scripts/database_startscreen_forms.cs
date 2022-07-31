using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class database_startscreen_forms : MonoBehaviour
{
    //the static words like loading , example words are created here

    public Text start_word_text;
    public Text exit_word_text;
    
    public float time_limit = 3f;
    public float time_passed = 0f;
    public int current_index = 0;
    public Animator[] text_fading;
    [SerializeField] int how_many_animators = 6;
    //database
    three_form_words_data_struct start = new three_form_words_data_struct(new string[] { "始める", "はじめる", "start" });
    three_form_words_data_struct exit = new three_form_words_data_struct(new string[] { "辞める", "やめる", "quit" });
    three_form_words_data_struct onyomi = new three_form_words_data_struct(new string[] { "音読み", "おんよみ", "Chinese reading" });
    three_form_words_data_struct kunyomi = new three_form_words_data_struct(new string[] { "訓読み", "くんよみ", "Japanese reading" });
    three_form_words_data_struct left = new three_form_words_data_struct(new string[] { "左", "ひだり", "left" });
    three_form_words_data_struct right = new three_form_words_data_struct(new string[] { "右", "みぎ", "right" });
    three_form_words_data_struct jump = new three_form_words_data_struct(new string[] { "飛ぶ", "とぶ", "jump" });
    void Start()
    {
        Application.targetFrameRate = 30;
    }

    private void Update()
    {

        // changes the text into one of it's forms by the time fixed
        time_passed += Time.deltaTime;
        if (time_passed >= time_limit)
        {
            time_passed = 0f;
            for (int i = 0; i < how_many_animators; i++)
            {

                text_fading[i].SetTrigger("start_textfading_anim");
            }

            //change_the_form();

        }

    }

    public void change_the_form()
    {

        if (current_index < 2) current_index += 1;
        else current_index = 0;
        start_word_text.text = start.data[current_index];
        exit_word_text.text = exit.data[current_index];
      


    }
}
