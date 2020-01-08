using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerSpawner : MonoBehaviour
{
    public Sprite sprite1;
    public UnityEvent SpawnTurret;
    private SpriteRenderer spriteRenderer;
    private bool ifClicked, valid;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Clicked()
    {
        if (sprite1 != null)
        {
            spriteRenderer.sprite = sprite1;
        }
        ifClicked = true;
        valid = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ifClicked == true)
        {
            spriteRenderer.color = Color.red;
            valid = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (ifClicked == true)
        {
            spriteRenderer.color = Color.white;
            valid = true;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (valid == true)
            {
                SpawnTurret.Invoke();
            }
        }

        if (Input.GetKeyDown("q"))
        {
            transform.Rotate(0, 0, 90);
        }

        if (Input.GetKeyDown("e"))
        {
            transform.Rotate(0, 0, -90);
        }
    }

}
