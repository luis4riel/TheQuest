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
        private Game _game;
        private Random _random = new Random();

        public TheQuest()
        {
            InitializeComponent();
        }
        private void TheQuest_Load(object sender, EventArgs e)
        {
            _game = new Game(new Rectangle(78, 57, 420, 155));
            _game.NewLevel(_random);
            UpdateCharacters();

        }
        
        #region Move
        private void MoveUp_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.UP, _random);
            UpdateCharacters();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.DOWN, _random);
            UpdateCharacters();
        }
        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.LEFT, _random);
            UpdateCharacters();
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            _game.Move(Direction.RIGHT, _random);
            UpdateCharacters();
        }
        #endregion

        #region Attack
        private void btnAttackUp_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.UP, _random);
            UpdateCharacters();
        }

        private void btnAttackRight_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.RIGHT, _random);
            UpdateCharacters();
        }

        private void btnAttackDown_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.DOWN, _random);
            UpdateCharacters();
        }

        private void btnAttackLeft_Click(object sender, EventArgs e)
        {
            _game.Attack(Direction.LEFT, _random);
            UpdateCharacters();
        }
        #endregion

        //private void UpdateCharacters()
        //{
        //    lblGamer.Text = _game.PlayerHitPoints.ToString();
        //    picPlayer.Location = _game.PlayerLocation;
        //    picPlayer.Visible = true;

        //    int enemiesShown = 0;
        //    enemiesShown = CountEnemies();

        //    Control weaponControl = null;
        //    SetPictureBoxVisibility();
        //    weaponControl = SetVisibilityToWeaponInRoom(weaponControl);
        //    weaponControl.Visible = true;
        //    CheckPlayerInventory();
        //    weaponControl.Location = _game.WeaponInRoom.Location;

        //    if (_game.WeaponInRoom.PickedUp)
        //    {
        //        weaponControl.Visible = false;
        //    }
        //    else
        //    {
        //        weaponControl.Visible = true;
        //        weaponControl.Location = _game.WeaponInRoom.Location;
        //    }

        //    if (_game.PlayerHitPoints <= 0)
        //    {
        //        MessageBox.Show("Você Morreu", "is dead...");
        //        Application.Exit();
        //    }

        //    if (enemiesShown < 1)
        //    {
        //        MessageBox.Show("Você derrotou os inimigos neste nível.");
        //        _game.NewLevel(_random);
        //        UpdateCharacters();
        //    }
        //}

        private void CheckPlayerInventory()
        {
            SelectInventoryItem(picSwordInventory, "Sword", "Weapon");
            SelectInventoryItem(picBowInventory, "Bow", "Weapon");
            SelectInventoryItem(picMaceInventory, "Mace", "Weapon");
            SelectInventoryItem(picPotionBlue, "Blue Potion", "Potion");
            SelectInventoryItem(picPotionRed, "Red Potion", "Potion");
        }

        private void SetupAttackButtons(string type)
        {
            if (type.ToLower() == "potion")
            {
                btnAttackUp.Text = "Beber";
                btnAttackDown.Visible = false;
                btnAttackLeft.Visible = false;
                btnAttackRight.Visible = false;
            }
            if (type.ToLower() == "weapon")
            {
                btnAttackUp.Text = "↑";
                btnAttackDown.Visible = true;
                btnAttackLeft.Visible = true;
                btnAttackRight.Visible = true;
            }
        }

        private Control SetVisibilityToWeaponInRoom(Control weaponControl)
        {
            switch (_game.WeaponInRoom.Name)
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

            foreach (Enemy enemy in _game.Enemies)
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
                    if (UpdateEnemy(enemy, picGhoul, lblGhoul))
                        enemiesShown++;
                }
            }
            return enemiesShown;
        }

        private bool UpdateEnemy(Enemy enemy, PictureBox picBoxEnemy, Label labelEnemyPoints)
        {
            bool isEnemyUpdated = false;

            labelEnemyPoints.Text = enemy.HitPoints.ToString();
            labelEnemyPoints.Visible = true;
            if (enemy.HitPoints > 0)
            {
                picBoxEnemy.Location = enemy.Location;
                picBoxEnemy.Visible = true;
                isEnemyUpdated = true;
            }
            else
            {
                picBoxEnemy.Visible = false;
                labelEnemyPoints.Visible = false;
            }

            return isEnemyUpdated;
        }
        
        private void SelectInventoryItem(PictureBox picSelectInventory, string name, string type)
        {
            if (_game.CheckPlayerInventory(name))
            {
                _game.Equip(name);
                RemoveInventoryBorders();
                picSelectInventory.BorderStyle = BorderStyle.FixedSingle;
                SetupAttackButtons(type);
            }


            //if (_game.CheckPlayerInventory(name))
            //{
            //    picSelectInventory.Visible = true;
            //    _game.Equip(name);
            //    picSelectInventory.BorderStyle = BorderStyle.FixedSingle;
            //    SetupAttackButtons(type);
            //}
        }

        private void picSwordInventory_Click(object sender, EventArgs e)
        {
            SelectInventoryItem(picSwordInventory, "Sword", "Weapon");
            UpdateCharacters();
        }

        private void picPotionBlueInventory_Click(object sender, EventArgs e)
        {
            SelectInventoryItem(picPotionBlueInventory, "Blue Potion", "Potion");
            UpdateCharacters();
        }

        private void picBowInventory_Click(object sender, EventArgs e)
        {
            SelectInventoryItem(picBowInventory, "Bow", "Weapon");
            UpdateCharacters();
        }

        private void picPotionRedInventory_Click(object sender, EventArgs e)
        {
            SelectInventoryItem(picPotionRedInventory, "Red Potion", "Potion");
            UpdateCharacters();
        }

        private void picMaceInventory_Click(object sender, EventArgs e)
        {
            SelectInventoryItem(picMaceInventory, "Mace", "Weapon");
            UpdateCharacters();
        }

        private void RemoveInventoryBorders()
        {
            picBowInventory.BorderStyle = BorderStyle.None;
            picMaceInventory.BorderStyle = BorderStyle.None;
            picSwordInventory.BorderStyle = BorderStyle.None;
            picPotionBlueInventory.BorderStyle = BorderStyle.None;
            picPotionRedInventory.BorderStyle = BorderStyle.None;

        }

        private void UpdateCharacters()
        {
            picPlayer.Location = _game.PlayerLocation;
            lblGamer.Text = _game.PlayerHitPoints.ToString();
            picPlayer.Visible = true;

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in _game.Enemies)
            {
                if (enemy is Bat)
                {
                    picBat.Location = enemy.Location;
                    lblBat.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                else if (enemy is Ghost)
                {
                    picGhost.Location = enemy.Location;
                    lblGhost.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                else if (enemy is Ghoul)
                {
                    picGhoul.Location = enemy.Location;
                    lblGhoul.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
                else
                {
                    continue;
                }
            }
            /*
             * Once you’ve looped through all the enemies on the level, check the showBatvariable. 
             * If the bat was killed, then showBatwill still be false, so make its PictureBox invisible 
             * and clear its hit points label. Then do the same for showGhostand showGhoul.
             */
            switch (showBat)
            {
                case true:
                    picBat.Visible = true;
                    break;
                case false:
                    picBat.Visible = false;
                    lblBat.Text = String.Empty;
                    break;
            }

            switch (showGhost)
            {
                case true:
                    picGhost.Visible = true;
                    break;
                case false:
                    picGhost.Visible = false;
                    lblGhost.Text = String.Empty;
                    break;
            }

            switch (showGhoul)
            {
                case true:
                    picGhoul.Visible = true;
                    break;
                case false:
                    picGhoul.Visible = false;
                    lblGhoul.Text = String.Empty;
                    break;
            }

            picSword.Visible = false;
            picBow.Visible = false;
            picPotionRed.Visible = false;
            picPotionBlue.Visible = false;
            picMace.Visible = false;
            Control weaponControl = null;

            switch (_game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = picSword;
                    break;
                case "Bow":
                    weaponControl = picBow;
                    break;
                case "Red Potion":
                    weaponControl = picPotionRed;
                    break;
                case "Blue Potion":
                    weaponControl = picPotionBlue;
                    break;
                case "Mace":
                    weaponControl = picMace;
                    break;
            }

            /*
             * Set the Visible property on each inventory icon PictureBox.
             * Check the Gameobject’s CheckPlayerInventory()method to figure out whether
             * or not to display the various inventory icons.
             */
            picSwordInventory.Visible = false;
            picSwordInventory.Enabled = false;
            picPotionRedInventory.Visible = false;
            picPotionRedInventory.Enabled = false;
            picPotionBlueInventory.Visible = false;
            picPotionBlueInventory.Enabled = false;
            picMaceInventory.Visible = false;
            picMaceInventory.Enabled = false;
            picBowInventory.Visible = false;
            picBowInventory.Enabled = false;

            if (_game.CheckPlayerInventory("Sword"))
            {
                picSwordInventory.Visible = true;
                picSwordInventory.Enabled = true;
                            }
            if (_game.CheckPlayerInventory("Bow"))
            {
                picBowInventory.Visible = true;
                picBowInventory.Enabled = true;
                
            }
            if (_game.CheckPlayerInventory("Mace"))
            {
                picMaceInventory.Visible = true;
                picMaceInventory.Enabled = true;
                
            }
            if (_game.CheckPlayerInventory("Blue Potion"))
            {
                picPotionBlueInventory.Visible = true;
                picPotionBlueInventory.Enabled = true;
                
            }
            if (_game.CheckPlayerInventory("Red Potion"))
            {
                picPotionRedInventory.Visible = true;
                picPotionRedInventory.Enabled = true;
                
            }
            weaponControl.Location = _game.WeaponInRoom.Location;
            if (_game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;

            if (_game.PlayerHitPoints <= 0)
            {
                MessageBox.Show(@"Você Morreu", "Is Dead...");
                Application.Exit();
            }
            if (enemiesShown < 1 && _game.Level < 8)
            {
                MessageBox.Show(@"Você derrotou os inimigos neste nível.", "Parabéns!");
                _game.NewLevel(_random);
                UpdateCharacters();
            }
        }

    }
}
