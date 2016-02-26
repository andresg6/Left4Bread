using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class PixelCanvasController : MonoBehaviour {
    public Image healthImage;
    public RectTransform HPPanel;

    private int hpMax = 0;
    private int currentHP = 0;
    private Stack<Image> HPStack;
    private float widthRatio = 50;
    private float halfCenter;
	
	void Start () {
        HPStack = new Stack<Image>();
        halfCenter = widthRatio / 2;
        updatePlayerHealth(3, 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updatePlayerHealth(int newCurrentHealth, int newMaxHealth)
    {
        if(newMaxHealth != hpMax)
        {
            updatePlayerMaxHealth(newMaxHealth);
        }
        if(newCurrentHealth != currentHP)
        {
            updatePlayerCurrentHealth(newCurrentHealth);
        }
    }

    private void updatePlayerMaxHealth(int newMax)
    {
        //resize health panel
        hpMax = newMax;
        HPPanel.sizeDelta = new Vector2(newMax * widthRatio, HPPanel.sizeDelta.y);
        HPPanel.anchoredPosition = new Vector2(newMax * widthRatio / 2, HPPanel.anchoredPosition.y);
    }

    private void updatePlayerCurrentHealth(int newHP)
    {
        if(newHP > currentHP) //if Healed health
        {
            int diff = newHP - currentHP ;
            float baseX = halfCenter + (widthRatio * HPStack.Count());
            currentHP = newHP;
            for(int i = 0; i < diff; i++) //Create new health UI Icons & add to health stack
            {
                Image newHPImage = Instantiate(healthImage) as Image;
                newHPImage.transform.SetParent(this.transform, false);
                newHPImage.rectTransform.anchoredPosition = new Vector2(baseX + widthRatio * i, newHPImage.rectTransform.anchoredPosition.y);
                HPStack.Push(newHPImage);
            }
        }
        else if(newHP < currentHP) //else if Lost health
        {
            int diff = currentHP - newHP;
            currentHP = newHP;
            for(int i = 0; i < diff; i++) //Pop health icons from stack and run "lost" animation
            {
                Image lostHP = HPStack.Pop();
                lostHP.GetComponent<UI_HP>().removeHealth();
            }
        }   
    }
}
