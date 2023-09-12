using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Util : MonoBehaviour
{
     

    //�ϳ��� floor�� 9X9�� ����Ͽ� ���� ���� �Ʒ��� (0,0) ���� ������ ���� (8,8)�� �Ͽ� ���� ���� floor�� ��� ��ġ������ ��Ÿ����.
    //RP�� ���� Room�� Position������ (214(x-4), 214(y-4), 0)�̴�. (�� floor�� positon�� (0,0,0)�̶����Ѵ�.)

    public static Gamemanager gamemanager;
    private void Awake()
    {
        gamemanager = GameObject.FindWithTag("gamemanager").GetComponent<Gamemanager>();
    }

    public struct RP {
        public int x;
        public int y;

        public RP(int x, int y)
        {//RP�� ������
            this.x = x; this.y = y;
        }

        public Vector3 getPosition() {//RP�� Position���� �Լ�
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

    //ü������ ĭ�� ��Ÿ���� ����ü�μ� �������ϴ��� (0,0)�̶� �ϰ� �ֿ�������� (7,7)�̶�� �Ѵ�.
    //�� ��ĭ�� ũ��� 25*25unit�̴�.

    public struct Cp
    {
        public int x;
        public int y;


        //������
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


        public StatSetting(bool n) {//�Է°��� ���� ���� �Ϲ� ������ ������ C#�������� �Ű������� ���� �����ڸ� ��������ʾƼ� bool���� ���� ������ ��ü
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
    } //�÷��̾��� ����

    public struct WeaponOption {
        public float atk; //�ش繫���� ���ݷ�
        public float critical; //�ش繫���� ġ��Ÿ Ȯ��
        public float critical_damage; //�ش繫���� ġ��Ÿ ������
        public int rank; //�ش繫���� Ƽ��� 0~10���� ����
        public float SkillMana; //��ų���� �Һ��� ������ ����
        public float LatkCool;//���������� �ְ������κ����� ����ð�
        public float LatkCoolDown;//�ְ����� ��Ÿ��
        public float SkillCool;//������ ��ų������� ������ ����ð�
        public float SkillCoolDown;//��ų�� ��Ÿ��
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
        public KeyCode WI;//WeaponInteraction �����ȣ�ۿ�
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
        //�Է����ڰ� �������� �ʱⰪ
    }//�÷��̾��� ������ ���� ����


    //���ӿ� �����ϴ� ��� ���⿡���� ���Ǹ� �����ִ�. �׷��Ƿ� ���ο� ���⸦ �߰��ϰų� �����ҋ� �ݵ�� weaponLIst�� �߰��ؾ��Ѵ�.
    public struct WeaponList{
        public GameObject M1;
        public GameObject Pistol;

        public WeaponList(bool n) {
            M1 = null;
            Pistol = null;
        }
    }
}


