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
        switch (Mouvement.instance.currentHealth)
        {
            case 9:
                life4.sprite = fullheart;
                life3.sprite = fullheart;
                life2.sprite = fullheart;
                life1.sprite = fullheart;
                break;

            case 8:
                life4.sprite = halfheart;
                life3.sprite = fullheart;
                life2.sprite = fullheart;
                life1.sprite = fullheart;
                break;

            case 7:
                life4.sprite = emptyheart;
                life3.sprite = fullheart;
                life2.sprite = fullheart;
                life1.sprite = fullheart;
                break;

            case 6:
                life4.sprite = emptyheart;
                life3.sprite = halfheart;
                life2.sprite = fullheart;
                life1.sprite = fullheart;
                break;

            case 5:
                life4.sprite = emptyheart;
                life3.sprite = emptyheart;
                life2.sprite = fullheart;
                life1.sprite = fullheart;
                break;

            case 4:
                life4.sprite = emptyheart;
                life3.sprite = emptyheart;
                life2.sprite = halfheart;
                life1.sprite = fullheart;
                break;

            case 3:
                life4.sprite = emptyheart;
                life3.sprite = emptyheart;
                life2.sprite = emptyheart;
                life1.sprite = fullheart;
                break;

            case 2:
                life4.sprite = emptyheart;
                life3.sprite = emptyheart;
                life2.sprite = emptyheart;
                life1.sprite = halfheart;
                break;

            case 1:
                life4.sprite = emptyheart;
                life3.sprite = emptyheart;
                life2.sprite = emptyheart;
                life1.sprite = emptyheart;
                break;
        }

    }
}
