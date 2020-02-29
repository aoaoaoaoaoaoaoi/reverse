using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hp : MonoBehaviour
{
    [SerializeField] private List<RectTransform> hpList;
    public int currentHp;

    private void Start()
    {
        currentHp = hpList.Count();
    }

    public void Subtract()
    {
        currentHp--;
        for (int i=0; i < hpList.Count(); ++i)
        {
            hpList[i].gameObject.SetActive(i < currentHp);
        }
    }
}
