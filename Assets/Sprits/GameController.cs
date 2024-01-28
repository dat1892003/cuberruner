using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public float time;
    private float m_time;
    bool gameover;
    bool gamest;
    private int score;
    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        m_time = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.setsc("SCORE : " + score);
        m_ui.showGamestart(true);
        gamest = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamest)
        {
            return;
        }
        if (gameover == true)
            {
               m_time = 0;
               m_ui.showgameover(true);
               return;
            }
            m_time -= Time.deltaTime;
           if (m_time <= 0)
            {
               taovat();
               m_time = time;
            }
    }
    public void taovat()
    {
        float rand = Random.Range(-2f, 0.11f);
        Vector2 swanpos = new Vector2(12, rand);
        if (obstacle)
        {
            Instantiate(obstacle, swanpos, Quaternion.identity);
        }
    }
    public void setscore(int a)
    {
        score = a; 
    }
    public int getscore()
    {
        return score;
    }
    public void upscore()
    {
        score++;
        m_ui.setsc("SCORE : "+ score);
    }
    public bool over()
    {
        return gameover;
    }
    public void setover(bool a)
    {
        gameover = a;
    }
    public void anstart()
    {
        m_ui.showGamestart(false);
        gamest = false;
        Update();
    }
    public void angameover()
    {
        SceneManager.LoadScene("Main");
        m_ui.showGamestart(false);
    }
    public bool gamestart()
    {
        return gamest;
    }
}
