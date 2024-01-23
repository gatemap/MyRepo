using System;

namespace Console_State_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GumballMachine gumballMachine = new GumballMachine(5);
            Console.WriteLine(gumballMachine);

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            Console.WriteLine(gumballMachine);

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            Console.WriteLine(gumballMachine);
        }
    }

    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
    }

    public class GumballMachine
    {
        public IState hasQuarterState { get; private set; }
        public IState noQuarterState { get; private set; }
        public IState soldState { get; private set; }
        public IState soldOutState { get; private set; }

        IState state;
        public int count { get; private set; } = 0;

        public GumballMachine(int numberGumballs)
        {
            hasQuarterState = new HasQuarterState(this);
            noQuarterState = new NoQuarterState(this);
            soldOutState = new SoldOutState(this);
            soldState = new SoldState(this);
            state = soldOutState;

            this.count = numberGumballs;
            state = numberGumballs > 0 ? noQuarterState : soldOutState;
        }

        public void SetState(IState state)
        {
            this.state = state;
        }

        public void ReleaseBall()
        {
            Console.WriteLine("A gumball comes rolling out the slot");
            if (count > 0) count--;
        }

        public void InsertQuarter()
        {
            state.InsertQuarter();
        }

        public void EjectQuarter()
        {
            state.EjectQuarter();
        }

        public void TurnCrank()
        {
            state.TurnCrank();
            state.Dispense();
        }
    }

    public class HasQuarterState : IState
    {
        GumballMachine gumballMachine;

        public HasQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("동전은 한 개만 넣어주세요.");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("동전이 반환됩니다.");
            gumballMachine.SetState(gumballMachine.noQuarterState);
        }

        public void TurnCrank()
        {
            Console.WriteLine("손잡이를 돌리셨습니다.");
            gumballMachine.SetState(gumballMachine.soldState);
        }

        public void Dispense()
        {
            Console.WriteLine("알맹이가 나갈 수 없습니다.");
        }
    }

    public class NoQuarterState : IState
    {
        GumballMachine gumballMachine;

        public NoQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("동전을 넣으셨습니다.");
            gumballMachine.SetState(gumballMachine.hasQuarterState);
        }

        public void EjectQuarter()
        {
            Console.WriteLine("동전을 넣어주세요.");
        }

        public void TurnCrank()
        {
            Console.WriteLine("동전을 넣어주세요.");
        }

        public void Dispense()
        {
            Console.WriteLine("동전을 넣어주세요.");
        }
    }

    public class SoldState : IState
    {
        GumballMachine gumballMachine;

        public SoldState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("잠깐만 기다려 주세요. 알맹이가 나가고 있습니다");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("이미 알맹이를 뽑으셨습니다.");
        }

        public void TurnCrank()
        {
            Console.WriteLine("손잡이는 한 번만 돌려주세요.");
        }

        public void Dispense()
        {
            gumballMachine.ReleaseBall();

            if (gumballMachine.count > 0)
                gumballMachine.SetState(gumballMachine.noQuarterState);
            else
            {
                Console.WriteLine("Oops, out of gumballs.");
                gumballMachine.SetState(gumballMachine.soldOutState);
            }
        }
    }

    public class SoldOutState : IState
    {
        GumballMachine gumballMachine;

        public SoldOutState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("매진되었습니다. 다음 기회에 이용해주세요.");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("동전을 넣지 않으셨습니다. 동전이 반환되지 않습니다.");
        }

        public void TurnCrank()
        {
            Console.WriteLine("매진되었습니다.");
        }

        public void Dispense()
        {
            Console.WriteLine("매진입니다.");
        }
    }
}
