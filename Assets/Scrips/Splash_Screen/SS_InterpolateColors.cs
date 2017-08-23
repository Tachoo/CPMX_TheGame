using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SS_InterpolateColors : MonoBehaviour
{

    #region Variables


    private Image Dissolve;
    /**/
    [SerializeField]
    public float speed;//0.7
    /**/
    private float transition;
    /**/
    [SerializeField]
    public Color A;
    /**/
    [SerializeField]
    public Color B;
    /**/
    [SerializeField]
    public bool IsReverse;
    /**/
    [SerializeField]
    public bool Done;
    /**/

    #endregion

    private void Awake()
    {
        Dissolve = GetComponent<Image>();
    }


    void Update()
    {
        if (Done == false)
        {
            InterPolateColors(!IsReverse);
        }

    }
    //Interpolation Colors defines Linear Ecuation for  A - B  (Time.Deltatime * 1 / m)*speed where m is a (A.position -B.position).magnitude
    /*
     *Vector4.x= Red Canel 
     *Vector4.y= Green Canel 
     *Vector4.z= Blue Canel 
     *Vector4.w= Alpha Canel 
     *Only 0->255; 
     * 
     */
    #region Convert Secction
    #region Convert Color To a Vector4
    private Vector4 ConvertColorToVector4(Color Color)
    {
        return new Vector4(Color.r, Color.g, Color.b, Color.a);
    }
    #endregion
    #region Convert Vector4 to a Color
    private Color ConvertVector4ToColor(Vector4 Color)
    {
        return new Color(Color.x, Color.y, Color.z, Color.w);
    }
    #endregion
    #endregion
    #region Interpolation 
    #region Linear-Interpolation Colors
    private Vector4 Interpolation(Vector4 ColorA, Vector4 ColorB, float t)
    {
        return Vector4.Lerp(ColorA, ColorB, t);
    }
    #endregion
    #region Linear % of t base a time
    float Porcent(Vector4 A, Vector4 B)
    {
        float m = (A - B).magnitude;
        float s = (Time.deltaTime * 1 / m) * speed;
        return s;
    }
    #endregion
    #endregion
    #region InterpolateColors MainFunc
    #region Interpolate Colors
    public void InterPolateColors(bool foward = true)
    {

        if (transition < 0)
        {
            transition = 0;
        }
        else if (transition > 1)
        {
            transition = 1;
        }
        else
        {
            transition += (foward) ? Porcent(ConvertColorToVector4(A), ConvertColorToVector4(B)) : -Porcent(ConvertColorToVector4(A), ConvertColorToVector4(B));
        }
        //        Dissolve.color= ConvertVector4ToColor(Interpolation(ConvertColorToVector4(A), ConvertColorToVector4(B), transition));
        Dissolve.color = Interpolation(ConvertColorToVector4(A), ConvertColorToVector4(B), transition);

        if (Dissolve.color == B)//Caso cuando es se difumina
        {
            Done = true;
        }
        if (Dissolve.color == A)//Caso cuando hace el fade out
        {
            Done = true;
        }

    }
    #endregion
    #endregion


}
