using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureinPicture : MonoBehaviour {

	public enum hAllignment { left,center,right};
    public enum vAllignment { top,middle,bottom};

    public hAllignment horAllign = hAllignment.left;
    public vAllignment vertAllign = vAllignment.top;

    public enum UnitsIn { pixels,screen_percentage};

    public  UnitsIn unit = UnitsIn.pixels;

    public int height = 50;
    public int width = 50;
    public int xOffset = 0;
    public int yOffset = 0;

    public bool update = true;
    [SerializeField] private bool PercentageToBeBelow100 = false;
    private int hsize, vsize, hloc, vloc;



    
    
    // Use this for initialization
	void Start ()
    {
        AdjustCamera();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (update)
        {
            AdjustCamera();
        }
	}

    void AdjustCamera ()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        float swPercent = sw * 0.01f;
        float shPercent = sh * 0.01f;
        float xOffsetPercent = xOffset * swPercent;
        float yOffsetPercent = yOffset * shPercent;
        int xOff;
        int yOff;

        if (unit == UnitsIn.screen_percentage)
        {
            hsize = width * (int)swPercent;
            vsize = height * (int)shPercent;
            xOff = (int)xOffsetPercent;
            yOff = (int)yOffsetPercent;
        }
        else
        {
            hsize = width;
            vsize = height;
            xOff = xOffset;
            yOff = yOffset;
        }

        switch (horAllign)
        {
            case hAllignment.left:
                hloc = xOff;
                break;
            case hAllignment.right:
                int justifiedRight = (sw - hsize);
                hloc = (justifiedRight - xOff);
                break;
            case hAllignment.center:
                float justifiedCenter = (sw * 0.5f) - (hsize * 0.5f);
                hloc = (int)(justifiedCenter - xOff);
                break;

        }

        switch(vertAllign)
        {
            case vAllignment.top:
                int justifiedTop = sh - vsize;
                vloc = (justifiedTop - yOff);
                break;
            case vAllignment.bottom:
                vloc = yOff;
                break;
            case vAllignment.middle:
                float justifiedMiddle = (sh * 0.5f) - (vsize * 0.5f);
                vloc = (int)(justifiedMiddle - yOff);
                break;
        }
        GetComponent<Camera>().pixelRect = new Rect(hloc, vloc, hsize, vsize);

        if (width > 99 || height > 99)
        {
            PercentageToBeBelow100 = true;
        }
        else
        {
            PercentageToBeBelow100 = false;
        }
    }
}
