using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvl : MonoBehaviour
{
    public int totalLvl;
    public int points;
    public bool pointsLock;
    [SerializeField] private Text lvlText;
    [SerializeField] private Slider pointsSlider;
    [SerializeField] private allScripts scripts;

    public void PointAdd()
    {
        if (!pointsLock)
        {
            points++;
            if (points == 5)
            {
                totalLvl++;
                scripts.spawnerManager.modif += 0.1f;
                points = 0;
            }
            lvlText.text = totalLvl.ToString();
            pointsSlider.value = points;
        }
        
    }
}
