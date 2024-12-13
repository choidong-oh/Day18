using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    //규율을 강제하는 interface라는 것이 있음
    //이 인터페이스는 한 클래스에도 여러개 적용 가능
    //공통된 기능을 추려내서 인터페이스로 만들면 편함
    //다형성을 활용하여 필요 시 인터페이스 형으로 바꿀 수도 있음

    //인터페이스 : 일종의 약속, 강제로 제약을 만들어 냄
    //구현 약속 모음집
    //interface linteractable 
    //{
    //    void 반드시 구현 해야할 함수();
    //}

    interface IAttackable
    {
        void Attack();
        
    }

    class Sword : IAttackable
    {
        public void MeleeAttack()
        {

        }
        public void Attack()
        {
            Console.WriteLine("칼 공격");
        }
    }
    class Bow : IAttackable
    {
        public void Snipe()
        {
            Console.WriteLine("저격을 수행합니다");
        }


        public void Attack()
        {
            Console.WriteLine("활 공격");
        }
    }

    class Player
    {
        IAttackable _weapon;
        public void EquipWeapon(IAttackable weapon)
        {
            _weapon = weapon;
            Console.WriteLine("무기 장착 완료");
        }

        public void PerformAttack()
        {
            if(_weapon != null)
            {
                Console.WriteLine("무기가 없습니다. 기본 공격을 수행합니다");
            }
            else if (_weapon is Bow)//만약 웨펀이 보우라면
            {
                //_weapon.Attack();
                //is 확인 캐스팅 가능한지 확인할 떄
                //as 대입해보고 안돼면 null
                (_weapon as Bow).Snipe();//웨펀을 보우형으로 바꾸고, 스나이프 실행
            }
            else if(_weapon is Sword)//만약 웨펀이 들고있는 애가 칼이라면
            {
                (_weapon as Sword).MeleeAttack();
            }

            else
            {
                _weapon.Attack();
            }


        }

    }






    abstract class Car//하나만 상속 시킬 수 있다. 필드를 가질 수 있다.
    {
        int x;
        public abstract void Run();
        public virtual void Run2()//기본적으로 행동할 내용을 만들 수도 있음
        {
            Console.WriteLine("아무것도 재정의 안했으면 자동 이거 실행");
        }

    }

    interface IDrivable//인터페이스 : 여러개를 한 클래스에 적용시킬 수 있다.
    {
        //int a; //선언 안됌
        void Drive();//함수를 적용 받은 대상에서 무조건 거기서 구현해야함
    }

    interface ITakeOff
    {
        void TakeOff();
    }

    class Plane : IDrivable
    {
        float _x;
        float _y;

        public void Drive()
        {
            Console.WriteLine("활주로로 이동");
        }

        public void Fly()
        {
            Console.WriteLine("비행기 타고 가요");
        }

    }

    class Vehicle : IDrivable
    {
        int x;
        int y;

        public void Drive()
        {
            Console.WriteLine("어디로 가야 하오");
        }

        public void LoadPeople()
        {
            Console.WriteLine("길거리서 승객 태우기");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //Plane plane = new Plane();   
            //Vehicle vehicle = new Vehicle();

            //IDrivable[] Autobots = new IDrivable[2];

            //Autobots[0] = plane;
            //Autobots[1] = vehicle;


            ////인터페이스를 적용받은 애들은, 인터페이스에 정의된 함수를 구현했을거란 보장이 있음
            //foreach (var robots in Autobots)
            //{
            //    robots.Drive();
            //}


            Player realPlayer = new Player();
            realPlayer.EquipWeapon(new Sword());







        }
    }
}
