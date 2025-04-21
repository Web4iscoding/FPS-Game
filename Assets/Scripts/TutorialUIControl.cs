using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TutorialUIControl : MonoBehaviour
{
    public TextMeshProUGUI welcomeUI1, yourHP, yourTimer, yourGunUI, pressW, pressA, pressS, pressD, clickToContinue, 
    clickToContinue2, press1, press2, pressQ, pleaseChangeWeapon, pressShift, pressCtrl, pressSpace, pistolExplain, AK47Explain,
    MeleeExplain, enterToContinue, exit;

    public GameObject welcomebg, yourHPImage, yourTimerImage, yourGunUIImage, enemySpawner, tutorialZombie;

    private int step;

    private bool pressedW, pressedA, pressedS, pressedD, WASDSession, pressed1, pressed2, pressedQ, pressedShift, pressedCtrl, pressedEnter
    , pressedSpace;

    // Update is called once per frame
    void Update()
    {
        Gun activeWeapon = WeaponManager.Instance.activeSlot.GetComponentInChildren<Gun>();
        
        // handling UI logics on step 11
        if (step == 11) {
            if(Input.GetKeyDown(KeyCode.W) && pressW.text.Length != 0) {
                pressW.text = "Press W to move forward (DONE)";
                pressedW = true;
            }
            else if(Input.GetKeyDown(KeyCode.A) && pressA.text.Length != 0) {
                pressA.text = "Press A to move to the left (DONE)";
                pressedA = true;
            }
            else if(Input.GetKeyDown(KeyCode.S) && pressS.text.Length != 0) {
                pressS.text = "Press S to move backward (DONE)";
                pressedS = true;
            }
            else if(Input.GetKeyDown(KeyCode.D) && pressD.text.Length != 0) {
                pressD.text = "Press D to move to the right (DONE)";
                pressedD = true;
            }
            else if(Input.GetKeyDown(KeyCode.LeftShift) && pressShift.text.Length != 0) {
                pressShift.text = "Hold Shift to sprint (DONE)";
                pressedShift = true;
            }
            else if(Input.GetKeyDown(KeyCode.LeftControl) && pressCtrl.text.Length != 0) {
                pressCtrl.text = "Hold Ctrl to crouch (DONE)";
                pressedCtrl = true;
            }
            else if(Input.GetKeyDown(KeyCode.Space) && pressSpace.text.Length != 0) {
                pressSpace.text = "Press Backspace to jump (DONE)";
                pressedSpace = true;
            }

            if (pressedW && pressedA && pressedS && pressedD && pressedShift && pressedCtrl && pressedSpace) {
                clickToContinue.text = "(Click to continue)";
                step++;
            }
        }
        // handling UI logics on step 16
        else if (step == 16) {
            if(Input.GetKeyDown(KeyCode.Alpha1) && press1.text.Length != 0) {
                press1.text = "Press 1 to switch to pistol (DONE)";
                pressed1 = true;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2) && press2.text.Length != 0) {
                press2.text = "Press 2 to switch to AK-47 (DONE)";
                pressed2 = true;
            }
            else if(Input.GetKeyDown(KeyCode.Q) && pressQ.text.Length != 0) {
                pressQ.text = "Press Q to switch to Melee (DONE)";
                pressedQ = true;
            }

            if (pressed1 && pressed2 && pressedQ) {
                clickToContinue2.text = "(Click to continue)";
                step++;
            }
        }

        // handling UI logics on specific steps
        if (step == 19) {
            if (!(activeWeapon.gunModel == Gun.Model.Pistol))
                pleaseChangeWeapon.text = "(Press 1 to switch to pistol)";
            else
                pleaseChangeWeapon.text = "";
            
        }
        else if (step == 21 || step == 22) {
            if (!(activeWeapon.gunModel == Gun.Model.AK47))
                pleaseChangeWeapon.text = "(Press 2 to switch to AK-47)";
            else
                pleaseChangeWeapon.text = "";
        }
        else if (step == 24 || step == 25 || step == 26) {
            if (!(activeWeapon.gunModel == Gun.Model.Bat))
                pleaseChangeWeapon.text = "(Press Q to switch to Melee)";
            else
                pleaseChangeWeapon.text = "";
        }

        // handling UI logics on specific steps
        if(enterToContinue.text.Length != 0 && Input.GetKeyDown(KeyCode.Return)) {
            welcomebg.SetActive(true);
            if (step == 19)
                welcomeUI1.text = "Now, let's take a look at the AK-47";
            else if (step == 22)
                welcomeUI1.text = "Now, let's take a look at the Melee weapon";
            else
                welcomeUI1.text = "Perfect";
            pleaseChangeWeapon.text = "";
            pistolExplain.text = "";
            AK47Explain.text = "";
            MeleeExplain.text = "";
            enterToContinue.text = "";
            enemySpawner.SetActive(false);
            try {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
                    enemy.GetComponent<Enemy>().TakeDamage(2147483647);
                }
            }
            catch {
                print("Ignore");
            }
            pressedEnter = true;
        }

        if(pressedEnter)
                step++;
                pressedEnter = false;
        
        // changing UI texts according to step
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (step == 0) {
                welcomeUI1.text = "We will first be going over the basics in this mode";
                step++;
            }
            else if (step == 1) {
                welcomeUI1.text = "Please follow the on-screen instructions carefully";
                step++;
            }
            else if (step == 2) {
                welcomeUI1.text = "";
                yourHPImage.SetActive(true);
                yourHP.text = "This is you HP (Health Point)";
                step++;
            } 
            else if (step == 3) {
                yourHP.text = "Once it reaches 0, the game will end automatically";
                step++;
            }
            else if (step == 4) {
                yourHP.text = "Please monitor your HP carefully during battles";
                step++;
            }
            else if (step == 5) {
                yourHP.text = "";
                yourHPImage.SetActive(false);
                yourTimerImage.SetActive(true);
                yourTimer.text = "This is a timer";
                step++;
            }
            else if (step == 6) {
                yourTimer.text = "It can be used as a convenient way to keep track of the duration of the play session";
                step++;
            }
            else if (step == 7) {
                yourTimer.text = "";
                yourTimerImage.SetActive(false);
                yourGunUIImage.SetActive(true);
                yourGunUI.text = "This is your Weapon UI";
                step++;
            }
            else if (step == 8) {
                yourGunUI.text = "Information about ammos and the current weapon type will be displayed here";
                step++;
            }
            else if (step == 9) {
                yourGunUI.text = "Please use this graphic to your advantage";
                step++;
            }
            else if (step == 10) {
                yourGunUI.text = "";
                yourGunUIImage.SetActive(false);
                welcomeUI1.text = "Now, let's take a look at the controls";
                step++;
            }
            else if (step == 11) {
                welcomeUI1.text = "";
                welcomebg.SetActive(false);
                if (!pressedW)
                    pressW.text = "Press W to move forward ()";
                if (!pressedA)
                    pressA.text = "Press A to move to the left ()";
                if (!pressedS)
                    pressS.text = "Press S to move backward ()";
                if (!pressedD)
                    pressD.text = "Press D to move to the right ()";
                if (!pressedShift)
                    pressShift.text = "Hold Shift to sprint ()";
                if (!pressedCtrl)
                    pressCtrl.text = "Hold Ctrl to crouch ()";
                if (!pressedSpace)
                    pressSpace.text = "Press Backspace to jump ()";
            }
            else if (step == 12) {
                pressW.text = "";
                pressA.text = "";
                pressS.text = "";
                pressD.text = "";
                pressShift.text = "";
                pressCtrl.text = "";
                pressSpace.text = "";
                clickToContinue.text = "";
                welcomebg.SetActive(true);
                welcomeUI1.text = "Excellent";
                step++;
            }
            else if (step == 13) {
                welcomeUI1.text = "Next, let's review the mechanics of the game";
                step++;
            }
            else if (step == 14) {
                welcomeUI1.text = "The fundamental of this game relies on three weapons:\n1. Pistol\n2. AK-47\n3. Melee bat";
                step++;
            }
            else if (step == 15) {
                welcomeUI1.text = "Let's take a look at the weapons";
                step++;
            }
            else if (step == 16) {
                welcomeUI1.text = "";
                welcomebg.SetActive(false);
                if (!pressed1)
                    press1.text = "Press 1 to switch to pistol ()";
                if (!pressed2)
                    press2.text = "Press 2 to switch to AK-47 ()";
                if (!pressedQ)
                    pressQ.text = "Press Q to switch to Melee ()";
            }
            else if (step == 17) {
                press1.text = "";
                press2.text = "";
                pressQ.text = "";
                clickToContinue2.text = "";
                welcomeUI1.text = "Next, let's break each weapon down individually";
                welcomebg.SetActive(true);
                step++;
            }
            else if (step == 18) {
                welcomeUI1.text = "";
                welcomebg.SetActive(false);
                pistolExplain.text = "The pistol is a weapon of great mobility, it consists of 7 ammos and deals a moderate amount of damage";
                step++;
            }
            else if (step == 19) {
                if (!pressedEnter) {
                    pleaseChangeWeapon.text = "";
                    enemySpawner.SetActive(true);
                    pistolExplain.text = "Go ahead and free feel to practice on the dummy zombie (Press R to reload!)";
                    enterToContinue.text = "(Press Enter to continue)";
                }
            }
            else if (step == 20) {
                welcomeUI1.text = "";
                welcomebg.SetActive(false);
                AK47Explain.text = "The AK-47 contains 30 ammos, and is very effective at spraying at enemies";
                step++;
            }
            else if (step == 21) {
                AK47Explain.text = "This weapon has two modes: auto and single, you can switch between modes by pressing F";
                step++;
            }
            else if (step == 22) {
                if (!pressedEnter) {
                    pleaseChangeWeapon.text = "";
                    enemySpawner.GetComponent<EnemySpawnController>().inCooldown = false;
                    enemySpawner.SetActive(true);
                    AK47Explain.text = "Go ahead and free feel to practice on the dummy zombie (Press R to reload!)";
                    enterToContinue.text = "(Press Enter to continue)";
                }
            }
            else if (step == 23) {
                welcomeUI1.text = "";
                welcomebg.SetActive(false);
                MeleeExplain.text = "The melee Bat is a close-range weapon";
                step++;
            }
            else if (step == 24) {
                MeleeExplain.text = "You can perform simple swing action by clicking";
                step++;
            } 
            else if (step == 25) {
                MeleeExplain.text = "It could be a powerful weapon if utilized correctly";
                step++;
            }
            else if (step == 26) {
                if (!pressedEnter) {
                    pleaseChangeWeapon.text = "";
                    enemySpawner.GetComponent<EnemySpawnController>().inCooldown = false;
                    enemySpawner.SetActive(true);
                    MeleeExplain.text = "Go ahead and free feel to practice on the dummy zombie";
                    enterToContinue.text = "(Press Enter to continue)";
                }
            }
            else if (step == 27) {
                
                welcomeUI1.text = "These are the foundamentals that you should know before starting the game";
                step++;
            }
            else if (step == 28) {
                welcomeUI1.text = "Please keep them in mind as you venture through the levels";
                step++;
            }
            else if (step == 29) {
                welcomeUI1.text = "Now enjoy the game and have fun!";
                step++;
            }
            else if (step == 30) {
                welcomeUI1.text = "";
                welcomebg.SetActive(false);
                enemySpawner.GetComponent<EnemySpawnController>().inCooldown = false;
                enemySpawner.GetComponent<EnemySpawnController>().currentEnemiesPerWave = 3;
                enemySpawner.SetActive(true);
                exit.text = "When you are done, press ESC and BACK TO MENU to exit tutorial mode";
            }
        }
    }
}

