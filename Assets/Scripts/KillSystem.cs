using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillSystem : MonoBehaviour
{
    public int kills;
    public Text ScoreText;

    public static KillSystem ins;

    private void Start()
    {
        ins = this;
    }

    public void KillMade()
    {
        kills++;
        ScoreText.text = $"{kills}";
    }
}
