# Full Test Report (2026-06-14 23:55)

[23:55:07] TEST1 (2-client parity): launching Test-TwoClientMedusa.ps1
[23:59:32] TEST1: GAME_STARTED_both=True guest_Char_Medusa_assetId=2964328207 leader_assetId=2964328207 parity=True
[23:59:32] TEST1 RESULT: PASS
[23:59:35] TEST2 (live cast): launching Test-NetCustomCast.ps1 against ark
[00:03:31] TEST2: castEvidence="[22:02:34.858] [NetworkedCustomChar] [M3] [M3c] spawned authentic Medusa networked prefab \u0027Hitbox_Medusa_NetSlot3\u0027 slot=3 proj=False owner=1 team=1 dmg=160.",
[00:03:31] TEST2: ownerPositive=True
[00:03:31] TEST2 RESULT: PASS
[00:03:31] TEST3 (config-driven): 
[00:03:31] TEST3 RESULT: FAIL
[00:03:34] DONE. SUMMARY: TEST1(parity)=PASS TEST2(live-cast)=PASS TEST3(config)=FAIL
