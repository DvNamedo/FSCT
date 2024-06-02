using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRotater : MonoBehaviour
{
    [Header("Application Image")]
    [SerializeField]
    Image title;

    [Header("Application Scope")]
    [SerializeField]
    bool isMoveUp_Dwn = true;

    [SerializeField]
    bool isMoveRgt_Lf = true;

    [SerializeField]
    bool isMoveWth_Hgt = true;

    [Header("Application StartDirection")]
    [SerializeField]
    bool isInitialMoveUptoDwn = true;

    [SerializeField]
    bool isInitialMoveRgttoLf = true;

    [SerializeField]
    bool isInitialMoveWthtoHgt = true;

    [Header("Application Maximum Value")]
    [SerializeField]
    float MoveMax = 3f;

    [SerializeField]
    float RotateMax = 3f;

    [SerializeField]
    float SizeMax = 3f;

    Vector2 CenterPos;
    Vector2 Pos;

    Quaternion CenterRot;
    Quaternion Rot;

    Vector2 CenterSize;
    Vector2 Size;

    [Header("Application Speed")]
    [SerializeField]
    [Range(0.01f, 10000)]
    float MoveDelay = 1;

    [SerializeField]
    [Range(0.01f, 10000)]
    float RotateDelay = 1;

    [SerializeField]
    [Range(0.01f, 10000)]
    float SizeDelay = 1;

    // Start is called before the first frame update
    void Awake()
    {
        CenterPos = title.GetComponent<RectTransform>().localPosition;
        Pos = CenterPos;

        CenterRot = title.GetComponent<RectTransform>().rotation;
        Rot = CenterRot;

        CenterSize = title.GetComponent<RectTransform>().localScale;
        Size = CenterSize;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isMoveUp_Dwn)
        {
            var tsp = (isInitialMoveUptoDwn ? -1 : 1) * Mathf.Sin(Time.time / MoveDelay);
            Pos = CenterPos + new Vector2(0, MoveMax * tsp);
            title.GetComponent<RectTransform>().localPosition = Pos;
        }

        if (isMoveRgt_Lf)
        {
            var tsr = (isInitialMoveRgttoLf ? -1 : 1) * Mathf.Sin(Time.time / RotateDelay);
            Rot = CenterRot * Quaternion.Euler(new Vector3(RotateMax * tsr, RotateMax * tsr, RotateMax * tsr));
            title.GetComponent<RectTransform>().rotation = Rot;
        }

        if (isMoveWth_Hgt)
        {
            var tss = (isInitialMoveWthtoHgt ? -1 : 1) * Mathf.Abs(Mathf.Sin(Time.time / SizeDelay));
            Size = CenterSize + new Vector2(SizeMax * tss, SizeMax * tss);
            title.GetComponent<RectTransform>().localScale = Size;
        }

    }
}
