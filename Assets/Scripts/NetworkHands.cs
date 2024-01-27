using Leap;
using Leap.Unity;
using Leap.Unity.Encoding;
using UnityEngine;
using Unity.Netcode;

public class NetworkHands : NetworkBehaviour
{
    [SerializeField]
    private HandModelBase leftModel = null, rightModel = null;

[SerializeField]
    private LeapXRServiceProvider leapProvider;

    private VectorHand leftVector = new VectorHand(), rightVector = new VectorHand();
    private Hand leftHand = new Hand(), rightHand = new Hand();

    private byte[] leftBytes = new byte[VectorHand.NUM_BYTES], rightBytes = new byte[VectorHand.NUM_BYTES];

    private bool leftTracked, rightTracked;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            leapProvider = FindFirstObjectByType<LeapXRServiceProvider>();
            leapProvider.OnUpdateFrame += OnUpdateFrame;
            Destroy(leftModel?.gameObject);
            Destroy(rightModel?.gameObject);
        }
        else
        {
            leftModel.leapProvider = null;
            rightModel.leapProvider = null;
        }
    }

    public override void OnNetworkDespawn()
    {
        if (IsOwner)
        {
            leapProvider.OnUpdateFrame -= OnUpdateFrame;
        }
    }

    private void OnUpdateFrame(Frame frame)
    {
        int ind = frame.Hands.FindIndex(x => x.IsLeft);
        if (ind != -1)
        {
            leftTracked = true;
            leftVector.Encode(frame.Hands[ind]);
            leftVector.FillBytes(leftBytes);
        }
        else
        {
            leftTracked = false;
        }

        ind = frame.Hands.FindIndex(x => !x.IsLeft);
        if (ind != -1)
        {
            rightTracked = true;
            rightVector.Encode(frame.Hands[ind]);
            rightVector.FillBytes(rightBytes);
        }
        else
        {
            rightTracked = false;
        }

        UpdateHandServerRpc(NetworkManager.LocalClientId, leftTracked, rightTracked, leftBytes, rightBytes);
    }

    [ServerRpc]
    private void UpdateHandServerRpc(ulong clientId, bool leftTracked, bool rightTracked, byte[] leftHand, byte[] rightHand)
    {
        if (!IsServer) return;

        LoadHandsData(leftTracked, rightTracked, leftHand, rightHand);

        UpdateHandClientRpc(clientId, leftTracked, rightTracked, leftHand, rightHand);
    }

    [ClientRpc]
    private void UpdateHandClientRpc(ulong clientId, bool leftTracked, bool rightTracked, byte[] leftHand, byte[] rightHand)
    {
        if (IsOwner) return;

        LoadHandsData(leftTracked, rightTracked, leftHand, rightHand);
    }

    private void LoadHandsData(bool leftTracked, bool rightTracked, byte[] leftHand, byte[] rightHand)
    {
        if (leftModel != null)
        {
            leftModel.gameObject.SetActive(leftTracked);

            if (leftTracked)
            {
                leftVector.ReadBytes(leftHand);
                leftVector.Decode(this.leftHand);
                leftModel?.SetLeapHand(this.leftHand);
                leftModel?.UpdateHand();
            }
        }

        if (rightModel != null)
        {
            rightModel.gameObject.SetActive(rightTracked);

            if (rightTracked)
            {
                rightVector.ReadBytes(rightHand);
                rightVector.Decode(this.rightHand);
                rightModel?.SetLeapHand(this.rightHand);
                rightModel?.UpdateHand();
            }
        }
    }
}
