using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Sprite fullheart, emptyheart,halfheart;

    [SerializeField] Image life1, life2, life3, life4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Player.instance.currentHealth)
        {

            case 9: //full life
                life4.sprite = fullheart;
                life3.sprite = fullheart;
                life2.sprite = fullheart;
                life1.sprite = fullheart;
                break;

            case 8: //3 coeur et demi
                life4.sprite = halfheart;
                life3.sprite = fullheart;
                life2.sprite = fullheart;
                life1.sprite = fullheart;
                break;

            case 7: //3 coeur 
                life4.sprite = emptyheart;
                life3.sprite = fullheart;
                life2.sprite = fullheart;
                life1.sprite = fullheart;
                break;

            case 6://2 coeur et demi
                life4.sprite = emptyheart;
                life3.sprite = halfheart;
                life2.sprite = fullheart;
                life1.sprite = fullheart;
                break;

            case 5://2 coeur 
                life4.sprite = emptyheart;
                life3.sprite = emptyheart;
                life2.sprite = fullheart;
                life1.sprite = fullheart;
                break;

            case 4://1 coeur et demi
                life4.sprite = emptyheart;
                life3.sprite = emptyheart;
                life2.sprite = halfheart;
                life1.sprite = fullheart;
                break;

            case 3://1 coeur 
                life4.sprite = emptyheart;
                life3.sprite = emptyheart;
                life2.sprite = emptyheart;
                life1.sprite = fullheart;
                break;

            case 2://1 demi coeur 
                life4.sprite = emptyheart;
                life3.sprite = emptyheart;
                life2.sprite = emptyheart;
                life1.sprite = halfheart;
                break;

            case 1: // pas de vie 
                life4.sprite = emptyheart;
                life3.sprite = emptyheart;
                life2.sprite = emptyheart;
                life1.sprite = emptyheart;
                break;
        }

    }
}
