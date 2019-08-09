using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shutta
{
    class Program
    {
        private const int SeedMoney = 600;
        private const int BettingMoney = 100;
        private const int CallBettingMoney = 50;

        static void Main(string[] args)
        {
            Console.WriteLine("룰 타입을 선택하세요. (1:Basic, 2:Develop)");
            int input = int.Parse(Console.ReadLine());
            RuleType ruleType = (RuleType)input;

            Printline();
            List<Player> players = new List<Player>();

            if (ruleType == RuleType.Basic)
            {
                players.Add(new RealPlayer());
                players.Add(new ComputerPlayer());
            }

            else
                for (int i = 0; i < 2; i++)
                    players.Add(new RealPlayer());


            foreach (var player in players)
                player.Money = SeedMoney;

            int round = 1;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                // 한명이 오링이면 게임 종료
                if (IsAnyoneOring(players))
                    break;

                Console.WriteLine($"[Round {round}]을 진행합니다.");
                Printline();
                round++;

                Dealer dealer = new Dealer();

                // 학교 출석
                foreach (var player in players)
                {
                    player.Money -= BettingMoney;
                    dealer.PutMoney(BettingMoney);
                }

                // 카드 돌리기
                foreach (var player in players)
                {
                    player.Cards.Clear();
                    dealer.Cards.Clear();


                    for (int i = 0; i < 2; i++)
                    {
                        player.Cards.Add(dealer.DrawCard());
                    }

                    Console.WriteLine(player.GetCardText());

                }
                Printline();
                Console.WriteLine("게임을 계속하시겠습니까? (1. 콜   2. 다이)");
                Console.WriteLine("[콜] 하면 50원 추가 배팅 후 딜러 패 공개,");
                Console.WriteLine("[다이]하면 모든 패 공개 후 패배로 처리.");

                int sel = int.Parse(Console.ReadLine());

                bool surren = Surren(sel);

                //딜러 패 뽑기
                dealer.Cards.Add(dealer.DrawCard());

                //딜러가 뽑은 패 각자 덱으로 삽입
                foreach (var player in players)
                {
                    player.Cards.Add(dealer.DealerCard());
                }

                Printline();
                //딜러가 뽑은 패 공개
                Console.WriteLine(dealer.GetCardTextDealer());
                Printline();
                
                Console.WriteLine(players[0].GetCardText());

                PrintMyGokbo(players);

                Printline();

                if (!surren)
                {
                    foreach (var player in players)
                    {
                        player.Money -= CallBettingMoney;
                        dealer.PutMoney(CallBettingMoney);
                    }

                    Console.WriteLine("게임을 계속하시겠습니까? (1. 콜   2. 다이)");
                    Console.WriteLine("[콜]하면 모든 패 공개,");
                    Console.WriteLine("[다이]하면 패배로 처리.");

                    int finalsel = int.Parse(Console.ReadLine());

                    surren = Surren(finalsel);

                    Printline();
                    //무승부 찾기                   
                    if (Regame(players)) continue;
                }

               

                // 승자 찾기
                Player winner = FindWinner(players, surren);

                // 승자에게 상금 주기
                winner.Money += dealer.GetMoney();


                // 각 플레이어의 돈 출력
                Printline();
                foreach (var player in players)
                    Console.Write(player.Money + "\t");


                Console.WriteLine();
                Console.WriteLine("다음 라운드 진행을 위해 아무 숫자를 입력해 주세요.");
                int nextRound = int.Parse(Console.ReadLine());

                Printline();

            }
        }

        private static bool Surren(int surren)
        {
            if (surren == 1) return false;
            else return true;
        }
        private static bool Regame(List<Player> players)
        {
            int score0 = players[0].CalculateScore();
            int score1 = players[1].CalculateScore();

            Printline();
            foreach (var player in players)
            {
                Console.WriteLine(player.GetCardTextPublic());
            }
            Printline();
            PrintMyGokbo(players);
            PrintOtherPersonGokbo(players);
     

            if ((score0 == 35 && score1 < 35) || (score1 == 35) && (score0 < 35) ||
                (score0 == 19 && score1 < 19) || (score1 == 19) && (score0 < 19))
            {
                foreach (var player in players)
                {
                    player.Money += (BettingMoney + CallBettingMoney);
                    Console.WriteLine(player.GetCardTextPublic());
                }
                Console.WriteLine("재경기가 발생하였습니다. 무효 처리 후 다음 경기를 진행합니다.");
                return true;
            }

            else if (score0 == score1)
            {
                foreach (var player in players)
                {
                    player.Money += (BettingMoney + CallBettingMoney);
                    Console.WriteLine(player.GetCardTextPublic());
                }
                Console.WriteLine("무승부가 발생하였습니다. 무효 처리 후 다음 경기를 진행합니다.");
                return true;
            }

            return false;
        }
        private static Player FindWinner(List<Player> players, bool surren)
        {

            int score0;
            if (surren) score0 = 100;
            else score0 = players[0].CalculateScore();
            int score1 = players[1].CalculateScore();

            if (score0 > score1)
            {
                Console.WriteLine("승리하였습니다^^");
                return players[0];
            }
            else
            {
                Console.WriteLine("패배하였습니다ㅜ^ㅜ");
                return players[1];
            }
        }

        public static string GetStringScore(int score)
        {
            return Dictionary.Instance.Table[score];
        }

        private static bool IsAnyoneOring(List<Player> players)
        {
            string s = Dictionary.Instance.Table[20];
            
            foreach (Player player in players)
                if (player.Money == 0)
                    return true;

            return false;
        }
        private static void PrintMyGokbo(List<Player> players)
        {
            int score0 = players[0].CalculateScore();
            Console.WriteLine($"나의 족보 : {GetStringScore(score0)}");

        }
        private static void PrintOtherPersonGokbo(List<Player> players)
        {
            int score1 = players[1].CalculateScore();

            Console.WriteLine($"상대 족보 : {GetStringScore(score1)}");
        }

        private static void Printline()
        {
            Console.WriteLine("-----------------------------");
        }


    }
}
