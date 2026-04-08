using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Narazaka.VRChat.AreaPlayerCount
{
    [RequireComponent(typeof(Collider))]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class AreaPlayerCount : UdonSharpBehaviour
    {
        [System.NonSerialized]
        public int _playerCount = 0;
        public int playerCount
        {
            get => _playerCount;
            set
            {
                _playerCount = value;
                var text = value.ToString();
                foreach (var uiText in uiTexts)
                {
                    if (uiText != null)
                    {
                        uiText.text = text;
                    }
                }
                foreach (var tmpText in tmpTexts)
                {
                    if (tmpText != null)
                    {
                        tmpText.text = text;
                    }
                }
                foreach (var tmpUiText in tmpUiTexts)
                {
                    if (tmpUiText != null)
                    {
                        tmpUiText.text = text;
                    }
                }
            }
        }

        [SerializeField] float firstCalculationDelay = 2f;
        [SerializeField]
        UnityEngine.UI.Text[] uiTexts;
        [SerializeField]
        TMPro.TextMeshPro[] tmpTexts;
        [SerializeField]
        TMPro.TextMeshProUGUI[] tmpUiTexts;

        Collider cachedCollider;
        Collider _collider
        {
            get
            {
                if (cachedCollider == null)
                {
                    cachedCollider = GetComponent<Collider>();
                }
                return cachedCollider;
            }
        }

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            _RecalculatePlayerCount();
        }

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            _RecalculatePlayerCount();
        }

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            if (player.isLocal)
            {
                SendCustomEventDelayedSeconds(nameof(_RecalculatePlayerCount), firstCalculationDelay);
            }
        }

        public override void OnPlayerLeft(VRCPlayerApi player)
        {
            SendCustomEventDelayedSeconds(nameof(_RecalculatePlayerCount), 0.1f);
        }

        public void _RecalculatePlayerCount()
        {
            int count = 0;
            var players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
            VRCPlayerApi.GetPlayers(players);
            var bounds = _collider.bounds;
            foreach (var player in players)
            {
                if (Utilities.IsValid(player) && bounds.Contains(player.GetPosition()))
                {
                    count++;
                }
            }
            playerCount = count;
        }
    }
}
