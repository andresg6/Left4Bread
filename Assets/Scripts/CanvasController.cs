using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class CanvasController : MonoBehaviour {
    public Image healthImage;
    public RectTransform HPPanel;
    private PlayerControl player;
    private int hpMax;
    private int currentHP; 
	
	void Start () {
        player = FindObjectOfType<PlayerControl>().GetComponent<PlayerControl>();
        hpMax = 3;
        currentHP = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void updatePlayerMaxHealth(int newMax)
    {
        //resize health panel
        int widthRatio = (int)HPPanel.sizeDelta.x / hpMax;
        hpMax = newMax;
        HPPanel.sizeDelta = new Vector2(newMax * widthRatio, HPPanel.sizeDelta.y);
    }

    private void updatePlayerCurrentHealth(int currentHP)
    {
        
    }
}
