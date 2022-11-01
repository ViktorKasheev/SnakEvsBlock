using TMPro;
using UnityEngine;

public class BallsFood : MonoBehaviour
{
    public int Value;
    public TextMeshPro PointsText;

    void Start()
    {
        PointsText.SetText(Value.ToString());
    }
}
