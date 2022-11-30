using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplayer : MonoBehaviour
{
    [SerializeField] private List<Image> _checkmarks;

    public void SetDisplayingCountStars(int count)
    {
        for(int i = 0; i < _checkmarks.Count; i++)
        {
            if (count > i)
                _checkmarks[i].enabled = true;
            else
                _checkmarks[i].enabled = false;
        }
    }
}
