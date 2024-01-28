using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float move;
    GameController g_ct;
    // Start is called before the first frame update
    void Start()
    {
        g_ct = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (g_ct.over())
        {
            return;
        }
            transform.position = transform.position + Vector3.left * move * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SceneLimit"))
        {
            g_ct.upscore();
            Destroy(gameObject);
        }
    }
}
