using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheQuest.WinApp
{
    public partial class TheQuest : Form
    {
        private Game game;
        private Random random = new Random();

        public TheQuest()
        {
            InitializeComponent();
        }
        private void TheQuest_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(125, 94, 700, 280));
            game.NewLevel(random);
            UpdateCharacters();
            //SetTheLevel();
        }


        private void MoveUp_Click(object sender, EventArgs e)
        {
            game.Move(Direction.UP, random);
            UpdateCharacters();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            game.Move(Direction.DOWN, random);
            UpdateCharacters();
        }

        private void UpdateCharacters()
        {
            lblGamer.Text = game.PlayerHitPoints.ToString();
            picPlayer.Location = game.PlayerLocation;
            
            //int enemiesShown = 0;
            //enemiesShown = CountEnemies();

            //Control weaponControl = null;
            //SetPictureBoxVisibility();
            //weaponControl = SetVisibilityToWeaponInRoom(weaponControl);
            //weaponControl.Visible = true;
            //CheckPlayerInventory();
            //weaponControl.Location = game.WeaponInRoom.Location;

            //if (game.WeaponInRoom.PickedUp)
            //    weaponControl.Visible = false;
            //else
            //{
            //    weaponControl.Visible = true;
            //    weaponControl.Location = game.WeaponInRoom.Location;
            //}

            //if (game.PlayerHitPoints <= 0)
            //{
            //    MessageBox.Show("Você Morreu", "is dead...");
            //    Application.Exit();
            //}

            //if (enemiesShown < 1)
            //{
            //    MessageBox.Show("Você derrotou os inimigos neste nível.");
            //    game.NewLevel(random);
            //    UpdateCharacters();
            //}
        }

        private void CheckPlayerInventory()
        {
            CheckPlayerWeapon("Sword", "Weapon", picSwordInventory);
            CheckPlayerWeapon("Bow", "Weapon", picBowInventory);
            CheckPlayerWeapon("Mace", "Weapon", picMaceInventory);

            CheckPlayerPotion("Blue Potion", "Potion", picPotionBlueInventory);
            CheckPlayerPotion("Red Potion", "Potion", picPotionRedInventory);
        }

        private void CheckPlayerPotion(string name, string type, PictureBox picPotion)
        {
            //picPotion.BorderStyle = BorderStyle.None;
            //if (game.CheckPlayerInventory(name))
            //{
            //    if (!game.CheckPotionUsed(name))
            //    {
            //        weaponPictureBox.Visible = true;
            //        if (_game.IsWeaponEquipped(potionName))
            //        {
            //            weaponPictureBox.BorderStyle = BorderStyle.FixedSingle;
            //            SetupAttackButtons(weaponTyp);
            //            _isPotionNeeded = true;
            //        }
            //    }
            //    else
            //    {
            //        weaponPictureBox.BorderStyle = BorderStyle.None;
            //        weaponPictureBox.Visible = false;
            //        if (_isPotionNeeded)
            //        {
            //            _game.Equip("Sword");
            //            CheckPlayerWeapon("Sword", "Weapon", pictureBoxWeapon1);
            //            SetupAttackButtons("weapon");
            //            _isPotionNeeded = false;
            //        }
            //    }
            //}
        }

        private void CheckPlayerWeapon(string name, string type, PictureBox picInventory)
        {
            picInventory.BorderStyle = BorderStyle.None;
            if (game.CheckPlayerInventory(Name))
            {
                picInventory.Visible = true;
                if (game.IsWeaponEquipped(Name))
                {
                    picInventory.BorderStyle = BorderStyle.FixedSingle;
                    SetupAttackButtons(type);
                }
            }
        }

        private void SetupAttackButtons(string type)
        {
            if ("potion".Equals(type.ToLower()))
            {
                btnAttackUp.Text = "Beber";
                btnAttackDown.Visible = false;
                btnAttackLeft.Visible = false;
                btnAttackRight.Visible = false;
            }
            if ("weapon".Equals(type.ToLower()))
            {
                btnAttackUp.Text = "↑";
                btnAttackDown.Visible = true;
                btnAttackLeft.Visible = true;
                btnAttackRight.Visible = true;
            }
        }

        private Control SetVisibilityToWeaponInRoom(Control weaponControl)
        {
            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = picSword;
                    break;
                case "Bow":
                    weaponControl = picBow;
                    break;
                case "Mace":
                    weaponControl = picMace;
                    break;
                case "Red Potion":
                    weaponControl = picPotionRed;
                    break;
                case "Blue Potion":
                    weaponControl = picPotionBlue;
                    break;
            }
            return weaponControl;
        }

        private void SetPictureBoxVisibility()
        {
            picSword.Visible = false;
            picBow.Visible = false;
            picMace.Visible = false;
            picPotionBlue.Visible = false;
            picPotionRed.Visible = false;
        }

        private int CountEnemies()
        {
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    if (UpdateEnemy(enemy, picBat, lblBat))
                        enemiesShown++;
                }
                if (enemy is Ghost)
                {
                    if (UpdateEnemy(enemy, picGhost, lblGhost))
                        enemiesShown++;
                }
                if (enemy is Ghoul)
                {
                    if (UpdateEnemy(enemy, picGhost, lblGhoul))
                        enemiesShown++;
                }
            }
            return enemiesShown;
        }

        private bool UpdateEnemy(Enemy enemy, PictureBox picBoxEnemy, Label labelEnemyPoints)
        {
            bool isEnemyUpdated = false;

            //labelEnemyPoints.Text = enemy.HitPoints.ToString();
            //labelEnemyPoints.Visible = true;
            //if (enemy.HitPoints > 0)
            //{
            //    picBoxEnemy.Location = enemy.Location;
            //    picBoxEnemy.Visible = true;
            //    isEnemyUpdated = true;
            //}
            //else
            //{
            //    picBoxEnemy.Visible = false;
            //    labelEnemyPoints.Visible = false;
            //}

            return isEnemyUpdated;
        }

        private void SetTheLevel()
        {
            picPlayer.BringToFront();
            picBat.SendToBack();
            picGhost.SendToBack();
            picGhost.SendToBack();
            picBow.SendToBack();
            picMace.SendToBack();
            picSword.SendToBack();
            picPotionBlue.SendToBack();
            picPotionRed.SendToBack();
        }

    }
}
