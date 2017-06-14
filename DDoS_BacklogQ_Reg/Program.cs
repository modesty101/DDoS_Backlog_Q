using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDoS_BacklogQ_Reg
{
    class Program
    {
        // DDoS 공격 대응 - 백로그 큐
        static void Main(string[] args)
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\AFD\Parameters\", true);

            if (reg != null)
            {
                // 다이나믹 백로그 기능 활성화
                reg.SetValue("EnableDynamicBacklog", 1, RegistryValueKind.DWord);

                // 사용 가능한 최소 소켓 개수로, 여기 지정한 값으로 TCP 연결에 이용할 수 있게 생성함
                reg.SetValue("MinimumDynamicBacklog", 20, RegistryValueKind.DWord);

                // 최대값은 유지할 수 있는 최대 Half-open 상태의 소켓 개수이다.
                reg.SetValue("MaximumDynamicBacklog", 20000, RegistryValueKind.DWord);

                // 백 로그에 추가해야 할 때 한번에 생성할 소켓 개수
                reg.SetValue("DynamicBacklogGrowthDelta", 10, RegistryValueKind.DWord);

                Console.WriteLine("레지스트리 설정 성공!");
            }
            else
            {
                Console.WriteLine("레지스트리 설정 실패!");
            }

            Console.ReadKey();
        }
    }
}
