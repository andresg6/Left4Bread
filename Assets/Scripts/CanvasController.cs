using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class CanvasController : MonoBehaviour {
    public Image healthImage;
    public RectTransform HPPanel;

    private int hpMax = 0;
    private int currentHP = 0;
    private Stack<Image> HPStack;
    private float widthRatio = 50;
    private float halfCenter;
	
	void Start () {
        halfCenter = widthRatio / 2;
        hpMax = 3;
        currentHP = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void updatePlayerMaxHealth(int newMax)
    {
        //resize health panel
        hpMax = newMax;
        HPPanel.sizeDelta = new Vector2(newMax * widthRatio, HPPanel.sizeDelta.y);
    }

    private void updatePlayerCurrentHealth(int newHP)
    {
        if(newHP > currentHP) //if Healed health
        {
            int diff = newHP - currentHP + HPStack.Count;
            currentHP = newHP;
            for(int i = HPStack.Count; i < diff; i++) //Create new health UI Icons & add to health stack
            {
                Image newHPImage = Instantiate(healthImage) as Image;
                newHPImage.rectTransform.anchoredPosition = new Vector2(halfCenter + (i - 1) * widthRatio, newHPImage.rectTransform.anchoredPosition.y);
                HPStack.Push(newHPImage);
            }
        }
        else if(newHP < currentHP) //else if Lost health
        {
            int diff = HPStack.Count - (currentHP - newHP);
            currentHP = newHP;
            for(int i = HPStack.Count; i > diff; i--) //Pop health icons from stack and run "lost" animation
            {
                Image lostHP = HPStack.Pop();

            }
        }   
    }
}
