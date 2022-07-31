using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player_movement : MonoBehaviour
{
    float horizontal_move = 0f;
    public CharacterController2D controller;
    bool jump = false;
    public Animator player_animator;
    bool check_if_landed = false;
    public learnippet_popup learnippet;
    public database_for_learnippet learnippet_database;
    public bool player_control;
    public GameObject jump_button;
    public GameObject learnt_kanji;
    public GameObject learnt_kanji_bg;
    public ParticleSystem level_finish_star_spread;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<-20f)
        {
            restart_level();
        }

        //when the player_control value equals to false the learnippet must be active
        player_control=!learnippet.learnippet.activeInHierarchy;
        jump_button.SetActive(player_control);
        if (!player_control)
        {
            
            reset_horizontal_value();
                    }
        
        if (Input.GetButtonDown("Jump")&&player_control)
        {
            jump =true ;
            player_animator.SetBool("jump", true);

        }
        //Debug.Log(controller.m_Grounded);
        
        player_animator.SetFloat("move", Mathf.Abs(horizontal_move)); 
        if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log("asdjf");
        }
        if (!controller.m_Grounded)
        {
            check_if_landed = true;
        }

        if (check_if_landed)
        {
            if (controller.m_Grounded)
            {
                player_animator.SetBool("jump",false);
                check_if_landed = false;
            }
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontal_move,false,jump);
        if (!controller.m_Grounded)
        {
            jump = false;          
        }     

    }

    public void Set_horizontal_value_left()
    {
        if (player_control) { horizontal_move = -1; }
       
    }
    public void reset_horizontal_value()
    {
        horizontal_move = 0; 
    }
    public void Set_horizontal_value_right()
    {
        if (player_control) { horizontal_move = 1; }
    }

    public void Set_jump()
    {
        if (player_control) { jump = true; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        open_learnippet(collision);

    }

    public void open_learnippet(Collider2D collision)
    {
        if (collision.CompareTag("star") == true)
        {
            learnippet.popup = true;
            learnippet_database.call_set_learnipper_data();
            Destroy(collision.gameObject);
        }
    }

    public void close_learnippet()
    {
        learnippet.popup = false;
        if (learnippet_database.current_instance_index == 4)
            set_learnt_kanji_setup();


    }

    private void set_learnt_kanji_setup()
    {
        learnt_kanji.SetActive(true);
        //learnt_kanji_bg.SetActive(true);
        level_finish_star_spread.Play();

    }

    public void restart_level()
    {
        SceneManager.LoadScene(1);
    }

}
