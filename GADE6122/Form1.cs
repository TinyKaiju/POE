using System; // Yunus Joosub & Thoriso Tlale
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Security;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GADE6122
{
    public partial class Form1 : Form
    {
        //Question 2.1
        public abstract class Tile
        {
            protected int x;
            protected int y;

            public enum tiletype { Hero, Enemy, Gold, Weapon };
            public tiletype type;

            public Tile(int a, int b) //Constructor
            {
                this.x = a;
                this.y = b;
            }

            public int getX()
            {
                return this.x;
            }
            public int getY()
            {
                return this.y;
            }

            public tiletype getTiletype()
            {
                return type;
            }
        }

        public class Obstacle : Tile
        {
            public Obstacle(int x, int y) : base(x, y)
            { }
        }

        public class EmptyTile : Tile
        {
            public EmptyTile(int x, int y) : base(x, y)
            { }
        }
        //Question 2.2
        public abstract class Character : Tile
        {
            protected Tile targetTile;
            protected int hp;
            protected int maxHp;
            protected int damage;
            protected bool cornerVision = false;
            protected Tile[] visionTiles; //In ArrayVision = North, East, South, West
            public enum movementEnum { None, Up, Down, Left, Right };

            private char symbol;
            protected Weapon currentWeapon;
            protected int goldpurse = 0;
            protected int reach = 1;
            //Get methods
            public int getHp()
            {
                return this.hp;
            }
            public int getMaxHp()
            {
                return this.maxHp;
            }
            public int getDamage()
            {
                return this.damage;
            }

            public char getSymbol()
            {
                return symbol;
            }

            public int getGold()
            {
                return this.goldpurse;
            }

            public Character(int a, int b, char symbol) : base(a, b) // constructor
            {
                this.symbol = symbol;
            }

            public virtual void Attack(Character target)
            { }
            public bool isDead()
            {
                if (this.hp <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public virtual bool CheckRange(Character target)
            {
                if ((DistanceTo(target)) <= this.reach)
                {
                    return true;
                }
                return false;
            }
            private int DistanceTo(Character target) // Incomplete
            {
                int x = target.getX();
                int y = target.getY();

                int distance = (Math.Abs(this.getX() - x)) + Math.Abs((this.getY() - y));
                if (this is Mage)// Check if works properly
                {
                    if ((Math.Abs(this.getX() - x) == 2) && Math.Abs((this.getY() - y)) == 1)
                    {
                        distance = 1;
                    }
                    else if ((Math.Abs(this.getX() - x) == 1) && Math.Abs((this.getY() - y)) == 2)
                    {
                        distance = 1;
                    }
                }

                return distance;
            }
            public void Move(movementEnum move)
            {
                switch (move)
                {
                    case movementEnum.Up:
                        this.x--;
                        break;
                    case movementEnum.Down:
                        this.x++;
                        break;
                    case movementEnum.Right:
                        this.y++;
                        break;
                    case movementEnum.Left:
                        this.y--;
                        break;
                }

            }
            public abstract movementEnum ReturnMove(movementEnum move);
            //public abstract override ToString() { }

            //vision Setting
            public int getVisionSize()
            {
                return visionTiles.Length;
            }
            public void setVisionTiles(Tile[,] map)
            {
                this.visionTiles[0] = map[x - 1, y];
                this.visionTiles[1] = map[x + 1, y];
                this.visionTiles[2] = map[x, y + 1];
                this.visionTiles[3] = map[x, y - 1];
                if (cornerVision)
                {
                    this.visionTiles[4] = map[x - 1, y - 1];
                    this.visionTiles[5] = map[x + 1, y - 1];
                    this.visionTiles[6] = map[x - 1, y + 1];
                    this.visionTiles[7] = map[x + 1, y + 1];
                }


            }
            public void Pickup(Item i)
            {

                if (i is Gold)
                {
                    Gold goldnum;
                    goldnum = (Gold)i;
                    this.goldpurse += goldnum.getGoldAmount();
                }

                if (i is Weapon)
                {
                    Equip((Weapon)i);
                }

            }
            public Tile getVisionTile(int i)
            {
                return visionTiles[i];
            }
            public void damaged(int dmg)
            {
                this.hp -= dmg;
            }

            public void spendGold(int cost)
            {
                this.goldpurse -= cost;
            }

            private void Equip(Weapon w)
            {
                this.currentWeapon = w;
                this.reach = w.GetRange();
                this.damage = w.GetDamage;
            }

            public void Loot(Character target)
            {
                this.goldpurse += target.getGold();
                if ((target.currentWeapon != null) && (this is not Mage))
                {
                    string swap;
                    if (this.currentWeapon == null)
                    {
                        swap = "Swap Bare Hands for enemy's " + target.currentWeapon.ToString();
                        MessageBox.Show(swap, "Looting Enemy");
                        this.Pickup(target.currentWeapon);
                    }
                }
            }
            public virtual void setTarget(int x, int y) { }
        }

        //Question 2.4
        public abstract class Enemy : Character
        {
            protected Random randNum = new Random();
            protected bool friendlyFire = false;
            
            public Enemy(int x, int y, int Damage, int Maxhp, char Symbol) : base(x, y, Symbol) //Constructor
            {
                this.damage = Damage;
                this.maxHp = Maxhp;
                this.hp = Maxhp;
                this.type = tiletype.Enemy;
            }

            public bool getFriendyFire()
            {
                return friendlyFire;
            }
            public override string ToString()
            {
                return "Goblin at [" + x + "," + y + "] (" + damage + ")"; // double check 
            }
        }

        //Question 2.5
        public class Goblin : Enemy
        {
            public Goblin(int x, int y) : base(x, y, 1, 10, 'G')//Constructor
            {
                this.visionTiles = new Tile[4];
                this.currentWeapon = new MeleeWeapon(x, y, MeleeWeapon.Types.Dagger);
                this.goldpurse = 1;
            }
            public override movementEnum ReturnMove(movementEnum move)
            {
                int possible = 4;
                for (int i = 0; i < 4; i++)
                {
                    if (visionTiles[i] is not EmptyTile)
                    {
                        if (visionTiles[i] is not Item)
                        {
                            possible--;
                        }
                        if (visionTiles[i] is Hero)
                        {
                            possible = 0;
                        }
                    }
                }

                if (possible <= 0)
                {
                    return movementEnum.None;
                }
                move = movementEnum.Up;
                int direct = randNum.Next(4);

                Tile temp = new Obstacle(0, 0);
                while (!((temp is EmptyTile) || (temp is Item)))
                {
                    switch (direct)
                    {
                        case 0:
                            temp = visionTiles[0];
                            move = movementEnum.Up;
                            break;
                        case 1:
                            temp = visionTiles[1];
                            move = movementEnum.Down;
                            break;
                        case 2:
                            temp = visionTiles[2];
                            move = movementEnum.Right;
                            break;
                        case 3:
                            temp = visionTiles[3];
                            move = movementEnum.Left;
                            break;
                        default:
                            direct = randNum.Next(4);
                            break;
                    }
                    direct = randNum.Next(4);

                }
                return move;
            }
        }

        public class Mage : Enemy // Task2 Question 2.3
        {
            public Mage(int x, int y) : base(x, y, 5, 5, 'M')
            {
                this.visionTiles = new Tile[8];
                friendlyFire = true;
                this.cornerVision = true;
                this.goldpurse = 4;
            }

            public override movementEnum ReturnMove(movementEnum move)
            {
                return 0;
            }

            public override bool CheckRange(Character target)
            {
                return base.CheckRange(target);
            }

            public override string ToString()
            {
                return "Mage at [" + x + "," + y + "] (" + damage + ")"; // double check 
            }
        }

        public class Leader : Enemy
        {

            public override void setTarget(int targetX, int targetY)
            {
                targetTile = new EmptyTile(targetX, targetY);
            }
            public Leader(int x, int y) : base(x, y, 2, 20, 'L')//Constructor
            {
                this.visionTiles = new Tile[4];
                this.currentWeapon = new MeleeWeapon(x, y, MeleeWeapon.Types.Longsword);
                this.goldpurse = 2;
            }
            public override movementEnum ReturnMove(movementEnum move) // Change to new Method
            {
                int possible = 4;

                move = movementEnum.None;

                for (int i = 0; i < 4; i++)
                {
                    if (visionTiles[i] is not EmptyTile)
                    {
                        if (visionTiles[i] is not Item)
                        {
                            possible--;
                        }
                        if (visionTiles[i] is Hero)
                        {
                            possible = 0;
                        }
                    }
                }

                if (possible <= 0)
                {
                    return move;
                }

                int m = 0;
                Tile temp = new Obstacle(0, 0);
                int distY = y - targetTile.getY();
                int distX = x - targetTile.getX();

                if (targetTile.getY() > y)
                {
                    distY = targetTile.getY() - y;
                }
                if (targetTile.getX() > x)
                {
                    distX = targetTile.getX() - x;
                }

                if (distY == distX)
                {
                    Random rand = new Random();
                    int num = rand.Next(2);
                    for (int i = 0; i < 2; i++)
                    {
                        switch (num)
                        {
                            case 0:
                                if (targetTile.getX() == x)
                                {
                                    if (targetTile.getY() > y)
                                    {
                                        m = 3;
                                        move = movementEnum.Left;
                                    }
                                    else
                                    {
                                        m = 2;
                                        move = movementEnum.Right;
                                    }
                                }
                                else if (targetTile.getX() < x)
                                {
                                    m = 0;
                                    move = movementEnum.Up;
                                }
                                else if (targetTile.getX() > x)
                                {
                                    m = 1;
                                    move = movementEnum.Down;
                                }
                                else if (targetTile.getY() < y)
                                {
                                    m = 3;
                                    move = movementEnum.Left;
                                }
                                else
                                {
                                    m = 2;
                                    move = movementEnum.Right;
                                }
                                break;

                            case 1:
                                if (targetTile.getY() == y)
                                {
                                    if (targetTile.getX() < x)
                                    {
                                        m = 0;
                                        move = movementEnum.Up;
                                    }
                                    else
                                    {
                                        m = 1;
                                        move = movementEnum.Down;
                                    }
                                }
                                else if (targetTile.getY() < y)
                                {
                                    m = 3;
                                    move = movementEnum.Left;
                                }
                                else if (targetTile.getY() > y)
                                {
                                    m = 2;
                                    move = movementEnum.Right;
                                }
                                else if (targetTile.getX() < x)
                                {
                                    m = 0;
                                    move = movementEnum.Up;
                                }
                                else if (targetTile.getX() > x)
                                {
                                    m = 1;
                                    move = movementEnum.Down;
                                }
                                break;
                        }
                        if ((move != movementEnum.None) && ((visionTiles[m] is EmptyTile) || (visionTiles[m] is Item)))
                        {
                            return move;
                        }
                        if (num == 0)
                        {
                            num = 1;
                        }
                        else
                        {
                            num = 0;
                        }
                    }

                }
                if (distY < distX)
                {
                    if (targetTile.getX() == x)
                    {
                        move = movementEnum.None;
                    }
                    else if (targetTile.getX() < x)
                    {
                        m = 0;
                        move = movementEnum.Up;
                    }
                    else
                    {
                        m = 1;
                        move = movementEnum.Down;
                    }

                    if ((move != movementEnum.None) && ((visionTiles[m] is EmptyTile) || (visionTiles[m] is Item)))
                    {
                        return move;
                    }
                }
                if (distY > distX)
                {
                    if (targetTile.getY() == y)
                    {
                        move = movementEnum.None;
                    }
                    else if (targetTile.getY() < y)
                    {
                        m = 3;
                        move = movementEnum.Left;
                    }
                    else
                    {
                        m = 2;
                        move = movementEnum.Right;
                    }

                    if ((move != movementEnum.None) && ((visionTiles[m] is EmptyTile) || (visionTiles[m] is Item)))
                    {
                        return move;
                    }
                }


                int direct = randNum.Next(4);


                while (!((temp is EmptyTile) || (temp is Item)))
                {
                    switch (direct)
                    {
                        case 0:
                            temp = visionTiles[0];
                            move = movementEnum.Up;
                            break;
                        case 1:
                            temp = visionTiles[1];
                            move = movementEnum.Down;
                            break;
                        case 2:
                            temp = visionTiles[2];
                            move = movementEnum.Right;
                            break;
                        case 3:
                            temp = visionTiles[3];
                            move = movementEnum.Left;
                            break;
                        default:
                            direct = randNum.Next(4);
                            break;
                    }
                    direct = randNum.Next(4);

                }
                return move;
            }
            public override string ToString()
            {
                return "Leader at [" + x + "," + y + "] (" + damage + ")"; // double check 
            }
        }

        public class Hero : Character
        {
            public Hero(int x, int y, int hp) : base(x, y, 'H')//Constructor
            {
                this.visionTiles = new Tile[4];
                this.damage = 2;
                this.maxHp = hp;
                this.hp = hp;
                this.type = tiletype.Hero;
            }
            public override movementEnum ReturnMove(movementEnum move)
            {
                return move;
            }
            public override string ToString()
            {
                string weapon;
                if (currentWeapon == null)
                {
                    return ("Player Stats:\n |HP: " + hp + "/" + maxHp + "\n |Current Weapon: Bare Hands \n |Weapon Range: 1" + "\n |Weapon Damage: " + damage + "\n |Gold: " + goldpurse + "\n [" + getX() + "," + getY() + "]");

                }
                weapon = currentWeapon.ToString();
                return ("Player Stats:\n |HP: " + hp + "/" + maxHp + "\n |Current Weapon: " + weapon + "\n |Weapon Range: " + Convert.ToString(currentWeapon.GetRange()) + "\n |Weapon Damage: " + damage + "\n |Gold: " + goldpurse + "\n [" + getX() + "," + getY() + "]");
            }

            public override bool CheckRange(Character target)
            {
                return base.CheckRange(target);
            }

            public override void Attack(Character target)
            {
                target.damaged(this.damage);
            }

            public string getCurrentWeapon()
            {
                if (currentWeapon == null)
                {
                    return "Bare Hands";
                }
                return this.currentWeapon.ToString();
            }
        }

        //Question 2.2.1
        public abstract class Item : Tile
        {
            public Item(int x, int y) : base(x, y)
            {
                this.type = tiletype.Gold;

            }
            public abstract new string ToString();
            protected string ItemType;

        }

        //Qustion 2.2.2
        public class Gold : Item
        {
            private int goldAmount;
            private Random randomGoldAmount = new Random();

            public Gold(int x, int y) : base(x, y) //Constructor
            {
                goldAmount = randomGoldAmount.Next(1, 5);
                this.ItemType = "Gold";
            }

            public int getGoldAmount()
            {
                return this.goldAmount;
            }
            public override string ToString()
            {
                return this.ItemType;
            }

        }
        //Question 3.2.1
        public abstract class Weapon : Item
        {
            public Weapon(int x, int y) : base(x, y)
            {

            }

            protected int Damage;
            public int GetDamage
            {
                get { return Damage; }
            }
            protected int Range; // overridden
            public virtual int GetRange()
            {
                return Range;
            }
            protected int Durability;
            public int GetDurability
            {
                get { return Durability; }
            }
            protected int Cost;
            public int GetCost
            {
                get { return Cost; }
            }
            protected string WeaponType;
            public string GetWeaponType
            {
                get { return WeaponType; }
            }
            protected string WeaponSymbol;
            public string GetWeaponSymbol
            {
                get { return WeaponSymbol; }
            }
            protected string WeaponName;
            public string GetWeaponName
            {
                get { return WeaponName; }
            }
            
            public override string ToString()
            {
                return "";
            }
        }
        //Question 3.2.2
        public class MeleeWeapon : Weapon
        {
            public enum Types { Dagger, Longsword }
            public Types meleeWeapons;
            public override int GetRange()
            {
                return 1;
            }
            public MeleeWeapon(int x, int y, Types weapon) : base(x, y)
            {
                switch (weapon)
                {
                    case Types.Dagger:
                        this.Durability = 10;
                        this.Damage = 3;
                        this.Cost = 3;
                        this.WeaponSymbol = "D";
                        this.WeaponName = "Dagger";

                        break;
                    case Types.Longsword:
                        this.Durability = 6;
                        this.Damage = 4;
                        this.Cost = 5;
                        this.WeaponSymbol = "S";
                        this.WeaponName = "Longsword";
                        break;
                }

            }
            public override string ToString()
            { return WeaponName; }

        }
        //Question 2.2.3
        public class RangeWeapon : Weapon
        {
            public enum Types { Rifle, Longbow }
            public Types RangeWeapons;
            public override int GetRange()
            {
                return base.GetRange();
            }
            public RangeWeapon(int x, int y, Types weapon) : base(x, y)
            {

                switch (weapon)
                {
                    case Types.Rifle:
                        this.Durability = 3;
                        this.Range = 3;
                        this.Damage = 5;
                        this.Cost = 7;
                        this.WeaponSymbol = "R";
                        this.WeaponName = "Rifle";
                        break;
                    case Types.Longbow:
                        this.Durability = 4;
                        this.Range = 2;
                        this.Damage = 4;
                        this.Cost = 6;
                        this.WeaponSymbol = "B";
                        this.WeaponName = "Longbow";
                        break;
                }
            }
            public override string ToString()
            { return WeaponName; }
        }
        public class Map
        {

            private Tile[,] mapTiles;
            private Hero player;
            private Enemy[] enemies;
            private int mapWidth;
            private int mapHeight;
            private Random randomNum = new Random();
            private Item[] Items;
            public string battleBLog = "";
            public int wepnum;


            public Map(int wMin, int wMax, int hMin, int hMax, int enemyNum, int goldNum, int weaponNum)
            {
                wepnum = randomNum.Next(weaponNum+1);
                Items = new Item[wepnum + goldNum];

                mapWidth = randomNum.Next(wMin, wMax) + 2;
                mapHeight = randomNum.Next(hMin, hMax) + 2;

                enemies = new Enemy[enemyNum];
                mapTiles = new Tile[mapWidth, mapHeight];

                fillMap();

                player = (Hero)Create(Tile.tiletype.Hero); //cast
                mapTiles[player.getX(), player.getY()] = player;

                for (int i = 0; i < enemyNum; i++)
                {
                    enemies[i] = (Enemy)Create(Tile.tiletype.Enemy);
                    mapTiles[enemies[i].getX(), enemies[i].getY()] = enemies[i];
                }

                for (int i = 0; i < goldNum; i++)
                {
                    Items[i] = (Gold)Create(Tile.tiletype.Gold);
                    mapTiles[Items[i].getX(), Items[i].getY()] = Items[i];
                }

                for (int i = goldNum; i < (wepnum + goldNum); i++)
                {
                    Items[i] = (Weapon)Create(Tile.tiletype.Weapon);
                    mapTiles[Items[i].getX(), Items[i].getY()] = Items[i];
                }
                UpdateVision();

            }

            public void UpdateVision() // used to set vision after moving
            {
                player.setVisionTiles(mapTiles);
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (enemies[i] is Leader)
                    {
                        //Leader tempEnem = (Leader)enemies[i];
                        enemies[i].setTarget(player.getX(), player.getY());
                        //mapTiles[tempEnem.getX(), tempEnem.getY()] = tempEnem;
                        //enemies[i] = tempEnem;
                    }
                    enemies[i].setVisionTiles(mapTiles);
                }
            }

            private Tile Create(Tile.tiletype type)
            {
                int uniqueX = randomNum.Next(mapWidth - 1);
                int uniqueY = randomNum.Next(mapHeight - 1);
                while ((mapTiles[uniqueX, uniqueY] is not EmptyTile) && (mapTiles[uniqueX, uniqueY] is not EmptyTile))
                {
                    uniqueX = randomNum.Next(mapWidth - 1);
                    uniqueY = randomNum.Next(mapHeight - 1);
                }


                switch (type)  // create tile 
                {
                    case Tile.tiletype.Hero:
                        return new Hero(uniqueX, uniqueY, 50);
                    case Tile.tiletype.Enemy:
                        int rand = randomNum.Next(3);
                        switch (rand) // Randomise enemy type
                        {
                            case 0: return new Goblin(uniqueX, uniqueY);
                            case 1: return new Mage(uniqueX, uniqueY);
                            case 2: return new Leader(uniqueX, uniqueY);
                            default: return new EmptyTile(uniqueX, uniqueY);
                        }
                    case Tile.tiletype.Gold:
                        return new Gold(uniqueX, uniqueY);
                    case Tile.tiletype.Weapon:
                        int randW = randomNum.Next(4);
                        switch (randW) // Randomise enemy type
                        {
                            case 0: return new MeleeWeapon(uniqueX, uniqueY, MeleeWeapon.Types.Dagger);
                            case 1: return new MeleeWeapon(uniqueX, uniqueY, MeleeWeapon.Types.Longsword);
                            case 2: return new RangeWeapon(uniqueX, uniqueY, RangeWeapon.Types.Rifle);
                            case 3: return new RangeWeapon(uniqueX, uniqueY, RangeWeapon.Types.Longbow);
                            default: return new EmptyTile(uniqueX, uniqueY);
                        }
                    default: return new EmptyTile(uniqueX, uniqueY);

                }


            }

            public void fillMap()
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    for (int y = 0; y < mapHeight; y++)
                    {
                        mapTiles[x, y] = new EmptyTile(x, y);
                    }
                }
                for (int x = 0; x < mapWidth; x++)
                {
                    mapTiles[x, 0] = new Obstacle(x, 0);
                    mapTiles[x, mapHeight - 1] = new Obstacle(x, mapHeight - 1);
                }
                for (int y = 0; y < mapHeight; y++)
                {
                    mapTiles[0, y] = new Obstacle(0, y); //top row
                    mapTiles[mapWidth - 1, y] = new Obstacle(mapWidth - 1, y);//bottom row
                }
            }

            public int getWidth()
            {
                return mapWidth;
            }
            public int getHeight()
            {
                return mapHeight;
            }
            public Tile getMapTiles(int x, int y)
            {
                return mapTiles[x, y];
            }

            public int getPlayerX()
            {
                return player.getX();
            }
            public int getPlayerY()
            {
                return player.getY();
            }

            public void Move(Character.movementEnum move)
            {
                int oldX = getPlayerX();
                int oldY = getPlayerY();
                player.Move(move);

                mapTiles[oldX, oldY] = new EmptyTile(oldX, oldY);
                mapTiles[getPlayerX(), getPlayerY()] = player;

                UpdateVision();
            }
            public void Move(Character.movementEnum move, Item pick)
            {
                if (pick is Weapon)
                {

                    string swap = "Swap " + player.getCurrentWeapon() + " for " + pick.ToString();
                    var flag = MessageBox.Show(swap, "Switch Weapons?", MessageBoxButtons.YesNo);

                    if (flag == DialogResult.Yes)
                    {
                        player.Pickup(pick);
                    }
                }
                player.Pickup(pick);
                int oldX = getPlayerX();
                int oldY = getPlayerY();
                player.Move(move);

                mapTiles[oldX, oldY] = new EmptyTile(oldX, oldY);
                mapTiles[getPlayerX(), getPlayerY()] = player;



                UpdateVision();
            }

            public List<Enemy> getTargetEnemies() // Creates list of enemies in range of attack
            {
                int n = 0;
                List<Enemy> enemyTargets = new List<Enemy>();

                for (int t = 0; t < enemies.Length; t++)
                {

                    if (player.CheckRange(enemies[t]))
                    {
                        enemyTargets.Add(enemies[t]);
                        n++;
                    }
                }
                return enemyTargets;
            }

            public string tryAttack(Enemy target) // Check to see if attack is possible and successful
            {
                List<Enemy> enemies = getTargetEnemies();
                if (enemies.Contains(target))
                {
                    player.Attack(target);

                    if (!target.isDead())
                    {
                        return target.ToString() + "HP: " + Convert.ToString(target.getHp());
                    }
                    else
                    {
                        player.Loot(target);
                        int x = target.getX();
                        int y = target.getY();
                        String output = "Killed " + target.ToString();

                        mapTiles[x, y] = new EmptyTile(x, y);
                        removeEnemy(target);

                        return output;
                    }
                }
                else
                {
                    return "Attack failed";
                }
            }

            public void tryEnemyAttack()
            {
                Enemy attacker;
                for (int e = 0; e < enemies.Length; e++)
                {
                    attacker = enemies[e];
                    for (int i = 0; i < attacker.getVisionSize(); i++)
                    {
                        if ((attacker.getFriendyFire()) && (attacker.getVisionTile(i) is Enemy))
                        {
                            Tile temp = attacker.getVisionTile(i);
                            Enemy victim = (Enemy)mapTiles[temp.getX(), temp.getY()];
                            victim.damaged(attacker.getDamage());
                            battleBLog += attacker.ToString() + " attacked " + victim.ToString();
                            if (victim.isDead())
                            {
                                removeEnemy(victim);
                                attacker.Loot(victim);
                                mapTiles[victim.getX(), victim.getY()] = new EmptyTile(victim.getX(), victim.getY());
                                battleBLog += attacker.ToString() + " Killed " + victim.ToString();

                            }
                        }
                        else if (attacker.getVisionTile(i) is Hero)
                        {
                            battleBLog += attacker.ToString() + " attacked YOU\n";
                            player.damaged(attacker.getDamage());
                        }
                        UpdateVision();
                    }

                }
            }
            public void removeEnemy(Enemy target) // Removes enemy from array and resizes it
            {
                int j = 0;
                Enemy[] temp = new Enemy[enemies.Length - 1];

                for (int i = 0; i < enemies.Length; i++)
                {
                    if ((enemies[i] != target) && (j < temp.Length))
                    {
                        temp[j] = enemies[i];
                        j++;
                    }
                }
                enemies = new Enemy[temp.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    enemies[i] = temp[i];
                }
            }
            public void removeItem(Item target) // Removes enemy from array and resizes it
            {
                int j = 0;
                Item[] temp = new Item[Items.Length - 1];

                for (int i = 0; i < Items.Length; i++)
                {
                    if ((Items[i] != target) && (j < temp.Length))
                    {
                        temp[j] = Items[i];
                        j++;
                    }
                }
                Items = new Item[temp.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    Items[i] = temp[i];
                }
            }

            public virtual string getPlayerInfo()
            {
                return player.ToString();
            }

            public virtual string getEnemyInfo(Enemy target)
            {
                return target.ToString() + "\nHP: " + Convert.ToString(target.getHp());
            }

            public int getEnemyarraySize()
            {
                return enemies.Length;
            }
            public Enemy getEnemy(int i)
            {
                return enemies[i];
            }

            public void moveEnemies()
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    int oldX = enemies[i].getX();
                    int oldY = enemies[i].getY();

                    enemies[i].Move(enemies[i].ReturnMove(0));
                    Item j = getItemAtPosition(enemies[i].getX(), enemies[i].getY());
                    if (j is Item)
                    {
                        enemies[i].Pickup(getItemAtPosition(enemies[i].getX(), enemies[i].getY()));
                        if (Items.Contains(j))
                        {
                            battleBLog += enemies[i].ToString() + " picked up " + j.ToString() + "\n";
                        }
                        removeItem(j);
                    }
                    mapTiles[oldX, oldY] = new EmptyTile(oldX, oldY);
                    mapTiles[enemies[i].getX(), enemies[i].getY()] = enemies[i];
                    UpdateVision();
                }
            }
            public string getBlog()
            {
                string output = battleBLog;
                battleBLog = "";
                return output;
            }
            public Item getItemAtPosition(int x, int y)
            {
                if ((mapTiles[x, y] is not Character) && (mapTiles[x, y] is not EmptyTile) && (mapTiles[x, y] is not Obstacle))
                {
                    return (Item)mapTiles[x, y];
                }
                else
                {
                    return null;
                }
            }

        }


        //Question 3.3
        [Serializable]
        public class Shop
        {
            private Weapon[] weaponArray = new Weapon[3];
            private Random randomNum = new Random();
            private Character buyer;

            public Shop(Character buyer)
            {
                this.buyer = buyer;
                for (int i = 0; i < weaponArray.Length; i++)
                {
                    weaponArray[i] = RandomWeapon();
                }
            }
            private Weapon RandomWeapon()
            {
                int randomNumber = randomNum.Next(weaponArray.Length);

                switch (randomNumber)
                {
                    case 0: return new MeleeWeapon(0, 0, MeleeWeapon.Types.Dagger);
                    case 1: return new MeleeWeapon(0, 0, MeleeWeapon.Types.Longsword);
                    case 2: return new RangeWeapon(0, 0, RangeWeapon.Types.Rifle);
                    case 3: return new RangeWeapon(0, 0, RangeWeapon.Types.Longbow);
                    default: return new MeleeWeapon(0, 0, MeleeWeapon.Types.Dagger);
                }

            }

            public bool CanBuy(int num)
            {
                if (buyer.getGold() >= weaponArray[num].GetCost)
                {
                    return true;
                }
                else
                    return false;
            }

            public void Buy(int num)
            {
                buyer.spendGold(weaponArray[num].GetCost);
                buyer.Pickup(weaponArray[num]);
                weaponArray[num] = RandomWeapon();
            }

            public Weapon GetWeapons(int num)
            {
                return (weaponArray[num]);
            }

            public string DisplayWeapon(int num)
            {
                string output = "";
                output += weaponArray[num].GetWeaponName + " Cost:" + weaponArray[num].GetCost;
                return output;
            }

        }
        [Serializable]
        public class GameEngine
        {
            private const char emptyChar = ' ';
            private const char obstacleChar = 'X';
            private const char goldchar = '$';
            private const char meleechar = 'W';
            private const char rangechar = 'R';
            private Map map;
            public Shop shop;


            public GameEngine(int widthMin, int widthMax, int heightMin, int heightMax, int enemyNum, int goldNum, int weaponNum) // constructor
            {
                map = new Map(widthMin, widthMax, heightMin, heightMax, enemyNum, goldNum, weaponNum);
                shop = new Shop((Character)map.getMapTiles(map.getPlayerX(), map.getPlayerY()));
            }

            public void EndGAME()
            {
                Hero temp = (Hero)map.getMapTiles(map.getPlayerX(), map.getPlayerY());
                if (map.getEnemyarraySize() == 0)
                {
                    var again = MessageBox.Show("\tYOU WIN!!!\n\tPLAY AGAIN", "Congratulations", MessageBoxButtons.YesNo);
                    if (again == DialogResult.No)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        Application.Restart();
                    }
                }
                if (temp.isDead())
                {
                    var again = MessageBox.Show("\tPLAY AGAIN", "YOU DIED", MessageBoxButtons.YesNo);
                    if (again == DialogResult.No)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        Application.Restart();
                    }
                }
            }
            public bool MovePlayer(Character.movementEnum moveType)
            {
                int x, y;
                x = map.getPlayerX();
                y = map.getPlayerY();

                switch (moveType)
                {
                    case Character.movementEnum.Up:
                        x--;
                        break;
                    case Character.movementEnum.Down:
                        x++;
                        break;
                    case Character.movementEnum.Right:
                        y++;
                        break;
                    case Character.movementEnum.Left:
                        y--;
                        break;
                }

                if (map.getMapTiles(x, y) is EmptyTile || map.getMapTiles(x, y) is Item) // player can move
                {
                    Item tempItem = map.getItemAtPosition(x, y);

                    if (tempItem != null)
                    {
                        map.Move(moveType, tempItem);
                    }
                    else
                    {
                        map.Move(moveType);
                    }

                    moveEnemy();
                    map.tryEnemyAttack();
                    return true;
                }
                else
                {
                    return false; //nothing
                }

            }




            public string getPlayerInfo()
            {
                return map.getPlayerInfo();
            }
            public string getEnemyInfo(Enemy target)
            {
                return map.getEnemyInfo(target);
            }

            public void moveEnemy()
            {
                map.moveEnemies();
            }
            public override string ToString()
            {

                string output = "";
                for (int x = 0; x < map.getWidth(); x++)
                {
                    for (int y = 0; y < map.getHeight(); y++)
                    {
                        if (map.getMapTiles(x, y) is Gold)
                        {
                            output += '$';
                        }
                        if (map.getMapTiles(x, y) is Weapon)
                        {
                            if (map.getMapTiles(x, y) is MeleeWeapon)
                            {
                                MeleeWeapon temp = (MeleeWeapon)map.getMapTiles(x, y);
                                output += temp.GetWeaponSymbol;
                            }
                            else
                            {
                                RangeWeapon temp = (RangeWeapon)map.getMapTiles(x, y);
                                output += temp.GetWeaponSymbol;
                            }
                        }
                        if (map.getMapTiles(x, y) is Character)
                        {
                            Character temp = (Character)map.getMapTiles(x, y);
                            output += temp.getSymbol();
                        }
                        else
                        {
                            switch (map.getMapTiles(x, y))
                            {
                                case Obstacle:
                                    output += obstacleChar;
                                    break;

                                case EmptyTile:
                                    output += emptyChar;
                                    break;
                            }
                        }
                    }
                    output += "\n";
                }
                return output;
            }

            public List<Enemy> getTargets()
            {
                return map.getTargetEnemies();
            }

            public string tryAttack(Enemy target)
            {
                return map.tryAttack(target);
            }

            public void EnemiesAtk()
            {
                map.tryEnemyAttack();
            }

            public Map getMap()
            {
                return map;
            }

            public void setMap(Map loadedMap)
            {
                map = loadedMap;
            }

            public string getLog()
            {
                return map.getBlog();
            }

        }

        class DataSerializer
        {
            public void BinarySerialize(object data, string path)
            {
                FileStream fileStream;
                BinaryFormatter bf = new BinaryFormatter();
                if (File.Exists(path)) File.Delete(path);
                fileStream = File.Create(path);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                bf.Serialize(fileStream, data);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                fileStream.Close();
            }
            public object BinaryDeserialize(string path)
            {
                object obj = null;

                FileStream fileStream;
                BinaryFormatter bf = new BinaryFormatter();
                if (File.Exists(path))
                {
                    fileStream = File.OpenRead(path);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                    obj = bf.Deserialize(fileStream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                    fileStream.Close();
                }
                return obj;
            }
        }
       

        GameEngine game;
        string battleLog = "";
        public Form1()
        {
            InitializeComponent();
            StartGame();           
            updateForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "data.KaijuAndBees";
            DataSerializer dataSerializer = new DataSerializer();
            GameEngine g = null;
            g = dataSerializer.BinaryDeserialize(path) as GameEngine;
            game = g;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            game.MovePlayer(Character.movementEnum.Up);
            updateForm();
            game.EndGAME();

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            game.MovePlayer(Character.movementEnum.Down);
            updateForm();
            game.EndGAME();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            game.MovePlayer(Character.movementEnum.Left);
            updateForm();
            game.EndGAME();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            game.MovePlayer(Character.movementEnum.Right);
            updateForm();
            game.EndGAME();
        }
        public void displayshop()
        {
            checkedListBox1.Items.Clear();
            for (int i = 0; i < 3; i++)
            {
                checkedListBox1.Items.Add(game.shop.DisplayWeapon(i));
            }
        }


        public void updateAttackList()
        {
            CmbEnemyList.Items.Clear();
            CmbEnemyList.Text = "";
            for (int i = 0; i < game.getTargets().Count(); i++)
            {
                CmbEnemyList.Items.Add(game.getTargets().ElementAt(i));
            }
            if (CmbEnemyList.Items.Count != 0)
            {
                CmbEnemyList.SelectedIndex = 0;
                updateEnemy();
            }
        }

        public void updateForm()
        {
            btnBuy.Enabled = false;
            rtbMap.Clear();
            rtbMap.Text = game.ToString();
            MemoPlayerInfo.Text = game.getPlayerInfo();
            updateAttackList();
            updateEnemy();
            displayshop();
            battleLog += game.getLog();
            richTextBox1.Text = battleLog;
            btnBuy.Text = "-- Buy --";
            lblOutput.Text = "";
        }
        public void StartGame()
        {
            game = new GameEngine(10, 20, 10, 20, 5, 5, 5);
        }
        private void BtnAttack_Click(object sender, EventArgs e)
        {

            if (CmbEnemyList.Items.Count != 0)
            {
                int i = CmbEnemyList.SelectedIndex;
                Enemy target = (Enemy)CmbEnemyList.Items[i];
                lblOutput.Text = game.tryAttack(target);
                game.EnemiesAtk();
                MemoPlayerInfo.Text = game.getPlayerInfo();
                rtbMap.Clear();
                rtbMap.Text = game.ToString();
                updateAttackList();
                updateEnemy();
            }
            else
            {
                lblOutput.Text = "No Targets Available";
                MemoEnemyInfo.Text += "No Targets Available\n";
            }
            game.EndGAME();
        }

        private void CmbEnemyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEnemy();
        }

        public void updateEnemy()
        {
            MemoEnemyInfo.Clear();
            if (CmbEnemyList.Items.Count != 0)
            {
                int i = CmbEnemyList.SelectedIndex;
                Enemy target = (Enemy)CmbEnemyList.Items[i];
                MemoEnemyInfo.Text = game.getEnemyInfo(target);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string path = "data.KaijuAndBees";
            DataSerializer dataSerializer = new DataSerializer();
            dataSerializer.BinarySerialize(game, path);
        }

        private void MemoPlayerInfo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbMap_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDagger_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        


        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            for (int i= 0; i < checkedListBox1.Items.Count; i++)
                if (i != e.Index )
                    checkedListBox1.SetItemChecked(i, false);

            if (game.shop.CanBuy(checkedListBox1.SelectedIndex))
            {

                btnBuy.Enabled = true;
                btnBuy.Text = "-- Buy --";
            }
            else
            {
                btnBuy.Enabled = false;
                btnBuy.Text = "Not enough Gold";
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            game.shop.Buy(checkedListBox1.SelectedIndex);
            updateForm();
        }
    }
}
