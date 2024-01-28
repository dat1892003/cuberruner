using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rb;
    public float jump;
    bool ground;
    GameController g_mc;
    public AudioSource ads;
    public AudioClip jsound;
    public AudioClip lsound;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        g_mc = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {    
        bool jumkey = Input.GetKeyDown(KeyCode.Space);
        if (g_mc.gamestart())
        {
            return;
        }
        if (g_mc.over())
        {
            return;
        }
        if (jumkey && ground)
        {
            m_rb.AddForce(Vector2.up* jump);
            ground = false;
            if (ads && jsound)
            {
                ads.PlayOneShot(jsound);
            }
        }
    }
    public void JUMP()
    {
        if (!ground)
            return;
        if (g_mc.gamestart())
        {
            return;
        }
        if (g_mc.over())
        {
            return;
        }
        if (ground)
        {
            m_rb.AddForce(Vector2.up * jump);
            ground = false;
            if (ads && jsound)
            {
                ads.PlayOneShot(jsound);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            g_mc.setover(true);
            if (ads && lsound)
            {
                ads.PlayOneShot(lsound);
            }
        }   
    }
}
