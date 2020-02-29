using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hp : MonoBehaviour
{
    [SerializeField] private List<RectTransform> hpList;
    public int CurrentHp { get; private set; }

    private void Start()
    {
        CurrentHp = hpList.Count();
    }

    public void Subtract()
    {
        CurrentHp--;
        for (int i=0; i < hpList.Count(); ++i)
        {
            hpList[i].gameObject.SetActive(i < CurrentHp);
        }
    }
}
