using UnityEngine;
using System.Collections;

public class MainUIController : MonoBehaviour {
    private PixelCanvasController pcc;
    private ScaleCanvasController scc;

	// Use this for initialization
	void Start () {
        pcc = FindObjectOfType<PixelCanvasController>();
        scc = FindObjectOfType<ScaleCanvasController>();
	}

    public void updatePlayerHealth(int remainingHealth, int maxHealth)
    {
        pcc.updatePlayerHealth(remainingHealth, maxHealth);
    }
}
