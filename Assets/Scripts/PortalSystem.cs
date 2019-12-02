using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSystem : Interactable
{
    [SerializeField] Transform spawnPoint = null;
    
    public float costTeleport = 10f;
    
    public float delay = 2f;
    float _time = 0;
    private void Update() {
        _time += Time.deltaTime;
    }
    protected override void EnterInteract(PlayerRaycastSystem playerRaycast)
    {
        base.EnterInteract(playerRaycast);
        if (playerRaycast.interactObject == this)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) && _time > delay)
            {
                float teleportNeedUseAmount = costTeleport;
                _time = 0;
                Player p = playerRaycast.gameObject.GetComponent<Player>();
                if(playerRaycast.GetComponent<PortalNeed>().Spend(teleportNeedUseAmount)) {
                    p.SetStatus(PlayerStatus.teleport);
                    p.SetTranstition(1f);
                    playerRaycast.gameObject.transform.position = this.spawnPoint.position;
                }
            }
        }
    }
}
