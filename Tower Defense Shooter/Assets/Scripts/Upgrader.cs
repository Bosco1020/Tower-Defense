using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{
    public Sprite sprite1;
    public UnityEvent Upgrade, NoMoney;
    public int Cost;
    private int payment;
    private SpriteRenderer spriteRenderer;
    private bool ifClicked, valid;
    private Collider2D selected = null;
    private int num = 100;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Clicked()
    {
        spriteRenderer.sprite = sprite1;
        ifClicked = true;
        valid = true;
        spriteRenderer.color = Color.red;
        selected = null;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (ifClicked == true)
        {
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
                selected = other;
                spriteRenderer.color = Color.white;
                valid = true;
            }
        }
    }

    private void Update()
    {
        //num = int.Parse(scrapText.text);

        if (Input.GetMouseButton(0))
        {
            if (valid == true && num >= Cost)
            {
                Upgrade.Invoke();
                payment = 0 - Cost;
                selected.transform.SendMessage("UpgradeSelected", selected, SendMessageOptions.DontRequireReceiver);
            }
            else if (valid == true && num < Cost)
            {
                NoMoney.Invoke();
            }
        }
    }
}
