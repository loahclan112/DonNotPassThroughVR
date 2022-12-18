using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PassThroughManager : MonoBehaviour
{
    public GameObject oVRCameraRig;
    public bool isPassThroughEnabled;
    public bool isEdgeRenderingEnabled;
    private OVRManager oVRManager;
    private OVRPassthroughLayer passthrough;
    public OVRInput.Button buttonPassthrough;
    public OVRInput.Button buttonEdgeRendering;
    public OVRInput.Controller controller;


    public Transform anchorPoint;
    public Transform centerEye;
    public float intensity;

    public TextMeshPro textMeshPro;


    // Start is called before the first frame update
    void Start()
    {
        oVRManager = oVRCameraRig.GetComponent<OVRManager>();
        passthrough = oVRCameraRig.GetComponent<OVRPassthroughLayer>();
        oVRManager.isInsightPassthroughEnabled = isPassThroughEnabled;
        passthrough.edgeRenderingEnabled = isEdgeRenderingEnabled;
        passthrough.enabled = isPassThroughEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(buttonPassthrough, controller))
        {
            isPassThroughEnabled = !isPassThroughEnabled;
            passthrough.hidden = isPassThroughEnabled;
        }

        else if (OVRInput.GetDown(buttonEdgeRendering, controller))
        {
            isEdgeRenderingEnabled = !isEdgeRenderingEnabled;
            passthrough.edgeRenderingEnabled = isEdgeRenderingEnabled;
        }
         
        if (isPassThroughEnabled)
        {
           // UpdateOpacity();
        }
    }

    public void UpdateOpacity() {

        // intensity = Mathf.InverseLerp(0f,1f,Vector3.Distance(anchorPoint.localPosition, oVRCameraRig.localPosition));
        float distance = Vector2.Distance(new Vector2(anchorPoint.localPosition.x, anchorPoint.localPosition.z), new Vector2(centerEye.localPosition.x, centerEye.localPosition.z));
        intensity = Mathf.InverseLerp(0f, 1f, distance*2);
        textMeshPro.text = "Intensity: " + intensity.ToString();
        //passthrough.textureOpacity = intensity;
        Color actColor = passthrough.edgeColor;
        actColor.a = intensity;
        passthrough.edgeColor = actColor;
    }
}
