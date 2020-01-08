using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{
    public Sprite sprite1;
    public UnityEvent Upgrade;
    private SpriteRenderer spriteRenderer;
    private bool ifClicked, valid;
    private Collider2D target = null;

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
        spriteRenderer.color = Color.red;
        target = null;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (ifClicked == true)
        {
            target = null;
            spriteRenderer.color = Color.red;
            valid = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ifClicked == true)
        {
            if (other.gameObject.tag == "Turret")
            {
                target = other;
                spriteRenderer.color = Color.white;
                valid = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (valid == true)
            {
                target.transform.SendMessage("UpgradeSelected", target, SendMessageOptions.DontRequireReceiver);
                Upgrade.Invoke();
            }
        }
    }
}
