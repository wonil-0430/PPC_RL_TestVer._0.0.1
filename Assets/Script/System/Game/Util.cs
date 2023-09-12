using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Util : MonoBehaviour
{
     

    //하나의 floor를 9X9로 등분하여 가장 왼쪽 아래를 (0,0) 가장 오른쪽 위를 (8,8)라 하여 현재 방이 floor의 어디에 위치한지를 나타낸다.
    //RP에 따란 Room의 Position계산식은 (214(x-4), 214(y-4), 0)이다. (단 floor의 positon을 (0,0,0)이라가정한다.)

    public static Gamemanager gamemanager;
    private void Awake()
    {
        gamemanager = GameObject.FindWithTag("gamemanager").GetComponent<Gamemanager>();
    }

    public struct RP {
        public int x;
        public int y;

        public RP(int x, int y)
        {//RP의 생성자
            this.x = x; this.y = y;
        }

        public Vector3 getPosition() {//RP의 Position리턴 함수
            return new Vector3(214*(x-4), 214*(y-4), 0);
        }

        public static RP operator +(RP r1, RP r2)
        {
            return new RP(r1.x + r2.x, r1.y + r2.y);
        }

        public static bool operator ==(RP r1, RP r2)
        {
            if (r1.x == r2.x && r1.y == r2.y)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public static bool operator !=(RP r1, RP r2)
        {
            if (r1.x != r2.x || r1.y != r2.y)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static RP unitRP(int a) {
            if (a % 4 == 0)
            {
                return new RP(1, 0);
            }
            else if (a % 4 == 1)
            {
                return new RP(0, -1);
            }
            else if (a % 4 == 2)
            {
                return new RP(-1, 0);
            }
            else {
                return new RP(0, 1);
            }
        }

        public bool RangCheek() {
            if (this.x <= 8 && 0 < this.x && 0 <= this.y && this.y <= 8) {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //체스방의 칸을 나타내는 구조체로서 최좌측하단을 (0,0)이라 하고 최우측상단을 (7,7)이라고 한다.
    //방 한칸의 크기는 25*25unit이다.

    public struct Cp
    {
        public int x;
        public int y;


        //생성자
        public Cp(int x, int y)
        {
            this.x = x; this.y = y;
        }

        public Cp(Vector2 v) {
            this.x = (int)v.x;
            this.y = (int)v.y;
        }

        public Vector3 getpositon()
        {
            return new Vector3(25 * (x - 4) + 12.5f, 25 * (y - 4) + 12.5f, 0);
        }

        public bool rangecheek() {
            if (0 <= this.x && this.x < 8 && 0 <= this.y && this.y < 8)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static Cp Right() {
            return new Cp(1, 0);
        }
        public static Cp Down()
        {
            return new Cp(0, -1);
        }
        public static Cp Left()
        {
            return new Cp(-1, 0);
        }
        public static Cp Up() {
            return new Cp(0, 1);
        }
        public static Cp unitCp(int a) {
            if (a%4 == 1)
            {
                return Right();
            }
            else if (a % 4 == 2)
            {
                return Down();
            }
            else if (a % 4 == 3)
            {
                return Left();
            }
            else {
                return Up();
            }
        }
        public Cp abs() {
            return new Cp(Mathf.Abs(this.x), Mathf.Abs(this.y));
        }

        public override string ToString()
        {
            return this.x.ToString() + ", " + this.y.ToString();
        }

        public static Cp operator +(Cp r1, Cp r2)
        {
            return new Cp(r1.x + r2.x, r1.y + r2.y);
        }

        public static Cp operator *(Cp r1, Cp r2) {
            return new Cp(r1.x * r2.x, r1.y * r2.y);
        }

        public static Vector2 operator *(Cp r1, Vector2 v1)
        {
            return new Vector2((float)r1.x * v1.x, (float)r1.y * v1.y);
        }

        public static bool operator ==(Cp r1, Cp r2)
        {
            if (r1.x == r2.x && r1.y == r2.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static bool operator !=(Cp r1, Cp r2)
        {
            if (r1.x != r2.x || r1.y != r2.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public struct StatSetting {
        public float hp;
        public float mp;
        public float hp_Gen;
        public float mp_Gen;
        public float speed;
        public float damage_Coefficient;
        public float atk_Speed;
        public float critical;
        public float P_passive;
        public float P_Active;
        public float DashCoolDown;
        public float DashCool;
        public float df;


        public StatSetting(bool n) {//입력값이 없을 때의 일반 생성자 현재의 C#버전에서 매개변수가 없는 생성자를 허용하지않아서 bool형이 들어가는 것으로 대체
            this.hp = 200;
            this.mp = 200;
            this.hp_Gen = 1;
            this.mp_Gen = 10;
            this.speed = 100;
            this.damage_Coefficient = 1;
            this.atk_Speed = 1;
            this.critical = 10f;
            this.P_passive = 1;
            this.P_Active = 1;
            this.DashCoolDown = 15f;
            this.DashCool = 15f;
            this.df = 0f;
        }
    } //플레이어의 스텟

    public struct WeaponOption {
        public float atk; //해당무기의 공격력
        public float critical; //해당무기의 치명타 확률
        public float critical_damage; //해당무기의 치명타 데미지
        public int rank; //해당무기의 티어로 0~10까지 존재
        public float SkillMana; //스킬사용시 소비할 마나의 설정
        public float LatkCool;//마지막으로 주공격으로부터의 경과시간
        public float LatkCoolDown;//주공격의 쿨타임
        public float SkillCool;//마지막 스킬사용으로 부터의 경과시간
        public float SkillCoolDown;//스킬의 쿨타임
        public WeaponOption(bool i) {
            atk = 100;
            critical = 10f;
            critical_damage = 0.2f;
            rank = 0;
            SkillMana = 10;
            LatkCool = 0;
            LatkCoolDown = 0;
            SkillCool = 0;
            SkillCoolDown = 0;
        }
    }

    public struct KeySetting
    {
        public KeyCode UpKey;
        public KeyCode DownKey;
        public KeyCode LeftKey;
        public KeyCode Rightkey;
        public KeyCode Dash;
        public KeyCode Useitem;
        public KeyCode Interaction;
        public KeyCode WI;//WeaponInteraction 무기상호작용
        public KeyCode Wp1;
        public KeyCode Wp2;
        public KeyCode Wp3;


        public KeySetting(bool n)
        {
            this.UpKey = KeyCode.W;
            this.DownKey = KeyCode.S;
            this.LeftKey = KeyCode.A;
            this.Rightkey = KeyCode.D;
            this.Dash = KeyCode.LeftShift;
            this.WI = KeyCode.R;
            this.Useitem = KeyCode.E;
            this.Wp1 = KeyCode.Alpha1;
            this.Wp2 = KeyCode.Alpha2;
            this.Wp3 = KeyCode.Alpha3;
            this.Interaction = KeyCode.F;
        }
        //입력인자가 없을때의 초기값
    }//플레이어의 움직임 관련 설정


    //게임에 존재하는 모든 무기에대한 정의를 맏고있다. 그러므로 새로운 무기를 추가하거나 구현할떄 반드시 weaponLIst에 추가해야한다.
    public struct WeaponList{
        public GameObject M1;
        public GameObject Pistol;

        public WeaponList(bool n) {
            M1 = null;
            Pistol = null;
        }
    }
}


