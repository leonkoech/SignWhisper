using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    private GameObject myXRRig;
    // private OVRCameraRigRef RigRef;
    private NetworkHands networkHands;
    public Transform myXRCam;
    Transform myXRLC, myXRRC;
    Transform avHead, avLeft, avRight, avBody;

    [SerializeField]
    private Vector3 avatarLeftPositionOffset, avatarRightPositionOffset;
    [SerializeField]
    private Quaternion avatarLeftRotationOffset, avatarRightRotationOffset;
    [SerializeField]
    private Vector3 avatarHeadPositionOffset;
    [SerializeField]
    private Quaternion avatarHeadRotationOffset;
    [SerializeField]
    private Vector3 avatarBodyPositionOffset;
    [SerializeField]
    private AssignLeap userType;

    public override void OnNetworkSpawn()
    {
        var myID = transform.GetComponent<NetworkObject>().NetworkObjectId;
        if (IsOwnedByServer)
            transform.name = "Host:" + myID;
        else
            transform.name = "Client:" + myID;

        if (!IsOwner) return;

        myXRRig = GameObject.Find("XRRig");
        if (myXRRig) Debug.Log("Found OVRCameraRig");
        else Debug.Log("Could not find OVRCameraRig!");

        // this is scene specific 
        if(userType.is_speaker){
            Vector3 initialSpeakerPosition = new Vector3(0f,0f,3f);
            Quaternion initialSpeakerRotation = Quaternion.Euler(90f, 0f, 0f); // Rotation of (90, 0, 0)

            myXRRig.transform.position = initialSpeakerPosition;
            myXRRig.transform.rotation = initialSpeakerRotation;
        }

        myXRCam = FindFirstObjectByType<Camera>().transform;

        // RigRef = myXRRig.GetComponent<OVRCameraRigRef>();
        // myXRLC = RigRef.LeftController;
        // myXRRC = RigRef.RightController;
        // myXRCam = RigRef.CameraRig.centerEyeAnchor.transform;

        // avLeft = transform.Find("Left Hand");
        // avRight = transform.Find("Right Hand");
        avHead = transform.Find("Head");
        avBody = transform.Find("Body");

        // Get reference to NetworkHands script
        networkHands = GetComponent<NetworkHands>();
    }

    void Update()
    {
        if (!IsOwner) return;
        if (!myXRRig) return;

        if (networkHands != null)
        {
            // Adjust XR rig based on hand data
            // For example, you might want to move the XR rig based on hand positions
            // Replace this with your specific logic
            // e.g., myXRRig.transform.position = networkHands.GetHandPosition();
        }

        // if (avLeft)
        // {
        //     avLeft.rotation = myXRLC.rotation * avatarLeftRotationOffset;
        //     avLeft.position = myXRLC.position + avatarLeftPositionOffset.x * myXRLC.transform.right + avatarLeftPositionOffset.y * myXRLC.transform.up + avatarLeftPositionOffset.z * myXRLC.transform.forward;
        // }

        // if (avRight)
        // {
        //     avRight.rotation = myXRRC.rotation * avatarRightRotationOffset;
        //     avRight.position = myXRRC.position + avatarRightPositionOffset.x * myXRRC.transform.right + avatarRightPositionOffset.y * myXRRC.transform.up + avatarRightPositionOffset.z * myXRRC.transform.forward;
        // }

        if (avHead)
        {
            Debug.Log("ID "+transform.GetComponent<NetworkObject>().NetworkObjectId + "position: "+ myXRCam.position);
            avHead.rotation = myXRCam.rotation;
            avHead.position = myXRCam.position + avatarHeadPositionOffset.x * myXRCam.transform.right + avatarHeadPositionOffset.y * myXRCam.transform.up + avatarHeadPositionOffset.z * myXRCam.transform.forward;
        }

        if (avBody)
        {
            avBody.position = avHead.position + avatarBodyPositionOffset;
        }
    }
}
