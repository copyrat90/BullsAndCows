using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;


namespace BullsAndCows
{
    class BullsAndCows
    {
        Random random = new Random();
        int digit;
        int round;
        string answer;

        public void Setup()
        {
            while (true)
            {
                Console.Write("몇 자리로 할까요? : ");
                digit = int.Parse(Console.ReadLine());
                if (digit <= 0)
                {
                    Console.WriteLine("0자리 이하는 게임이 안 되잖아요...\n");
                    continue;
                }
                if (digit > 10)
                {
                    Console.WriteLine("10자리 초과로는 숫자가 중복되어 불가능합니다.\n");
                    continue;
                }
                Console.WriteLine("{0}자리로 합니다.\n", digit);
                break;
            }

            answer = RNG(digit);

            while (true)
            {
                Console.Write("횟수를 지정해주세요 : ");
                round = int.Parse(Console.ReadLine());
                if (round <= 0)
                {
                    Console.WriteLine("0회 이하로는 게임이 안 되는데요...\n");
                    continue;
                }
                Console.WriteLine("{0}회로 합니다.\n", round);
                break;
            }
        }

        public void Play()
        {
            int strikeNum;
            int ballNum;

            for (int i = 1; i <= round; i++)
            {
                strikeNum = 0;
                ballNum = 0;

                Console.WriteLine("{0}회입니다.\n", i);
                while (true)
                {
                    ERROR:;
                    Console.Write("답을 입력해주세요 : ");
                    string input = Console.ReadLine();
                    if (input.Length != digit)
                    {
                        Console.WriteLine("자리수를 확인해주세요.\n");
                        continue;
                    }

                    for (int j = 0; j < digit; j++)
                    {
                        for (int k = 0; k < digit; k++)
                        {
                            if (input[j] == input[k] && j != k)
                            {
                                Console.WriteLine("중복된 숫자가 있습니다.\n");
                                goto ERROR;
                            }
                        }
                    }

                    for (int j = 0; j < digit; j++)
                    {
                        for (int k = 0; k < digit; k++)
                        {
                            if (input[j] == answer[k])
                                if (j == k)
                                    strikeNum++;
                                else
                                    ballNum++;
                        }
                    }

                    Console.WriteLine("{0}스트라이크 {1}볼입니다.\n", strikeNum, ballNum);

                    if (strikeNum == digit)
                    {
                        Console.WriteLine("축하드립니다! 정답을 맞추셨습니다!\n");
                        goto GAME_EXIT;
                    }
                    break;
                }
            }

            GAME_EXIT:;
        }

        string RNG(int digit)
        {
            ArrayList Order = new ArrayList();
            string result = "";

            for (int i = 0; i < 10; i++) // shuffling number 0 to 9 on ArrayList by random indexing method
                Order.Insert(random.Next(0, i + 1), i); // 0 에서 9 까지 ArrayList 에 랜덤하게 끼워넣는 방식으로 구현

            for (int i = 0; i < digit; i++)
                result += Order[i];

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("숫자야구 프로그램\n");
            BullsAndCows game = new BullsAndCows();
            bool gameContinue = true;

            while (gameContinue == true)
            {
                game.Setup();
                game.Play();
                while (true)
                {
                    Console.Write("계속하시겠습니까? (y/n) : ");
                    string input = Console.ReadLine();
                    if (input == "y")
                    {
                        gameContinue = true;
                        break;
                    }
                    else if (input == "n")
                    {
                        gameContinue = false;
                        break;
                    }
                    else
                        Console.WriteLine("잘못된 입력입니다.\n");
                }
            }
        }
    }
}
