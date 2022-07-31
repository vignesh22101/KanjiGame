using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class database_for_three_forms : MonoBehaviour
{
    //the static words like loading , example words are created here

    public Text example_word_text;
    public Text onyomi_word_text;
    public Text kunyomi_word_text;
    public Text left_word_text;
    public Text right_word_text;
    public Text jump_word_text;
    public Text close_word_text;
    //order for the sake of text example_word,onyomi,kunyomi,left,right,jump,close
    public GameObject[] texts;

  


      //  string lines[] = System.IO.File.ReadAllLines(@"Assets/csv_files/test_file.csv");
        public float time_limit = 3f;
    public float time_passed=0f;
   public int current_index = 0;
    public Animator[] text_fading_animators;
    [SerializeField]int how_many_animators=6;
    //database
    three_form_words_data_struct loading = new three_form_words_data_struct(new string[] { "読み込み", "よみこみ", "loading" });
    three_form_words_data_struct example_word = new three_form_words_data_struct(new string[] { "例の言葉", "れいのことば", "example word" });
    three_form_words_data_struct onyomi = new three_form_words_data_struct(new string[] { "音読み", "おんよみ", "Chinese reading" });
    three_form_words_data_struct kunyomi = new three_form_words_data_struct(new string[] { "訓読み", "くんよみ", "Japanese reading"  });
    three_form_words_data_struct left = new three_form_words_data_struct(new string[] { "左", "ひだり", "left" });
    three_form_words_data_struct right = new three_form_words_data_struct(new string[] { "右", "みぎ", "right" });
    three_form_words_data_struct jump = new three_form_words_data_struct(new string[] { "飛ぶ", "とぶ", "jump" });
    three_form_words_data_struct close = new three_form_words_data_struct(new string[] { "閉める", "しめる", "close" });
    void Start()
    {
        Application.targetFrameRate = 30;

    }

    private void Update()
    {

        // changes the text into one of it's forms by the time fixed
        time_passed += Time.deltaTime;
        if (time_passed>=time_limit)
        {
            time_passed = 0f;
            for (int i = 0; i < how_many_animators; i++) { 

                text_fading_animators[i].SetTrigger("start_textfading_anim");  }

        //change_the_form();

    }

    }

   public void change_the_form()
    {
        
        if (current_index < 2) current_index += 1;
        else current_index = 0;
        var instance_list = new List<three_form_words_data_struct>() {example_word,onyomi,kunyomi,left,right,jump,close };
        for (int i=0;i<how_many_animators;i++)
        {
           
            if (texts[i].activeInHierarchy) {
                //Debug.Log(texts[i]);
                texts[i].GetComponent<Text>().text = instance_list[i].data[current_index];
            }
           
        }
        /*example_word_text.text =example_word.data[current_index];
        onyomi_word_text.text= onyomi.data[current_index];
        kunyomi_word_text.text = kunyomi.data[current_index];
        left_word_text.text = left.data[current_index];
        right_word_text.text = right.data[current_index];
        jump_word_text.text = jump.data[current_index];
        close_word_text.text = close.data[current_index];*/


    }


        
}


