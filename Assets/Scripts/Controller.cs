using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    

    public Text t_step;
    private int step;
    public int Step
    {
        get { return step; }
        set { step = value; }
    }

    private Animator animator;
    [SerializeField] private float speed = 0.03f; 

    private bool MoveTarget = false;
    private Vector3 target;
    private bool finish= false;

    Hero hero;

    // Start is called before the first frame update
    void Start()
    {
        animator=this.GetComponent<Animator>();
        hero = new Hero();

        WriteStep();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");

        if (Input.GetKeyDown(KeyCode.R))
            LevelManager.Restart();

            if (hero.RemainiStep >=0 || finish)
            if (!MoveTarget)
            {
                if (Input.GetButtonDown("Horizontal"))
                {
                    GoStep();
                    MoveX();
                    WriteStep();
                }
                else if (Input.GetButtonDown("Vertical"))
                {
                    GoStep();
                    MoveY();
                    WriteStep();
                }
            }
            else
            {
                AnimateMove();
            }
        else
        {
            LevelManager.Restart();
        }
    }

    private void GoStep()
    {
        animator.SetInteger("State", 1);
        MoveTarget = true;
        hero.SpendStep();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "cliff")
            LevelManager.Restart();
        if (collision.tag == "Finish")
            LevelManager.Next();
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        try
        {
            if (collision.tag == "sand")
            {
                collision.tag = "cliff";
                Destroy(collision.gameObject.transform.GetChild(0).gameObject);
            }
        }
        catch { }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {          
        if (!MoveTarget)
        {
            if (collision.tag == "Right")
            {
                target = new Vector3(target.x + 1.0f, target.y - 0.5f, transform.position.z);
                MoveTarget = true;
                
                AnimateMove();
            }
            if (collision.tag == "Up")
            {
                target = new Vector3(target.x + 1.0f, target.y + 0.5f, transform.position.z);
                MoveTarget = true;
                
                AnimateMove();
            }
            if (collision.tag == "Down")
            {
                target = new Vector3(target.x - 1.0f, target.y - 0.5f, transform.position.z);
                MoveTarget = true;
                
                AnimateMove();
            }
            if (collision.tag == "Left")
            {
                target = new Vector3(target.x - 1.0f, target.y + 0.5f, transform.position.z);
                MoveTarget = true;
                
                AnimateMove();
            }
            
        }
    }



    public void WriteStep() => t_step.text = "Осталось шагов: " + hero.RemainiStep.ToString();

    private void MoveX()
    {
        if (Input.GetAxis("Horizontal") < 0)
            target = new Vector3(transform.position.x - 1.0f, transform.position.y + 0.5f, transform.position.z);
        else
            target = new Vector3(transform.position.x + 1.0f, transform.position.y - 0.5f, transform.position.z);

        AnimateMove();
    }

    private void MoveY()
    {
        if (Input.GetAxis("Vertical") < 0)
            target = new Vector3(transform.position.x - 1.0f, transform.position.y - 0.5f, transform.position.z);
        else
            target = new Vector3(transform.position.x + 1.0f, transform.position.y + 0.5f, transform.position.z);

        AnimateMove();
    }

    private void AnimateMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target ,speed);

        if (transform.position == target)
        {
            
            animator.SetInteger("State", 0);
            MoveTarget = false;
        }
    }


}
