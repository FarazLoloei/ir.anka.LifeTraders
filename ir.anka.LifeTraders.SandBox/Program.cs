using Grpc.Core;
using Mt4Grpc;
using mtapi.mt5;
using System.Text.Json;
using System.Text.Json.Serialization;
//using MT4 = TradingAPI.MT4Server;
//using MT5 = TradingAPI.MT5Server;

namespace ir.anka.LifeTraders.SandBox;

public class Program
{
    private static void Main(string[] args)
    {
        
    //var api = new MT5API("45.76.194.231:443", 7371, "mt5api");
    //api.OnConnectStatus += ConnectionStatus;
    //api.Connect();
    //Console.WriteLine("Balance = " + api.Account().Balance);



        //Channel channel = new Channel("mt4grpc.mtapi.io:443", ChannelCredentials.SecureSsl);
        //var connection = new Connection.ConnectionClient(channel);
        //var service = new Service.ServiceClient(channel);
        //var tarding = new Trading.TradingClient(channel);
        //var mt4 = new MT4.MT4Client(channel);
        //var headers = new Metadata();
        //var connectRequest = new ConnectRequest
        //{
        //    Host = "CMS-Demo.CMSPrime.com",
        //    Password = "uEgqH1_q",
        //    Port = 443,
        //    User = 444413537,
        //};
        //var reply = connection.Connect(connectRequest, headers);
        //Console.WriteLine("Response: " + reply);
        //var summaryReq = new AccountSummaryRequest()
        //{
        //    Id = reply.Result
        //};
        //var res = mt4.AccountSummary(summaryReq);
        //Console.WriteLine("AccountBalance: " + res.Result.Balance);
        //channel.ShutdownAsync().Wait();


        //Console.WriteLine("Hello, World!");
        //TradingAPI.MT4Server.QuoteClient quoteClient = new TradingAPI.MT4Server.QuoteClient(444413537, "uEgqH1_q", "78.46.174.221", 443);
        //foreach (var item in quoteClient.DownloadOrderHistory(DateTime.Now.AddMonths(-10), DateTime.Now.AddDays(1)))
        ////Console.WriteLine(item.Type == Op.Balance);
        //Console.WriteLine("Press any key...");

        //MT5API api = new MT5API(5016640277, "V!8pBqIt", "27.111.161.145", 1950);
        MT5API api = new MT5API(2123362, "cQ8imzbU", "137.74.94.238", 443);
        api.Connect();
        Console.WriteLine("Connected");
        Console.WriteLine(api.Account.Balance);
        api.OnOrderHistory += Api_OnOrderHistory;
        api.OnOrderProgress += Api_OnOrderProgress;
        //api.RequestOrderHistory(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(1));
        //api.RequestOrderHistory(new DateTime(2020, 03, 24), new DateTime(2020, 04, 02));
        api.RequestOrderHistory(DateTime.Now.AddDays(-1024), DateTime.Now);
        Console.WriteLine("Press any key...");
        Console.ReadKey();



        //        var remoteServer = new RemoteServer($"https://mt-market-data-client-api-v1.new-york.agiliumtrade.ai");
        //        var accountId = "d0e64d28-3ae3-416b-adb5-af8bc37d82ff";
        //        var _args = new args()
        //        {
        //            authToken = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI3NzQzNzcyMTkwZjA4ZGQxNjUyYjViZTEyNmQ0MTM2ZiIsInBlcm1pc3Npb25zIjpbXSwiYWNjZXNzUnVsZXMiOlt7ImlkIjoidHJhZGluZy1hY2NvdW50LW1hbmFnZW1lbnQtYXBpIiwibWV0aG9kcyI6WyJ0cmFkaW5nLWFjY291bnQtbWFuYWdlbWVudC1hcGk6cmVzdDpwdWJsaWM6KjoqIl0sInJvbGVzIjpbInJlYWRlciIsIndyaXRlciJdLCJyZXNvdXJjZXMiOlsiKjokVVNFUl9JRCQ6KiJdfSx7ImlkIjoibWV0YWFwaS1yZXN0LWFwaSIsIm1ldGhvZHMiOlsibWV0YWFwaS1hcGk6cmVzdDpwdWJsaWM6KjoqIl0sInJvbGVzIjpbInJlYWRlciIsIndyaXRlciJdLCJyZXNvdXJjZXMiOlsiKjokVVNFUl9JRCQ6KiJdfSx7ImlkIjoibWV0YWFwaS1ycGMtYXBpIiwibWV0aG9kcyI6WyJtZXRhYXBpLWFwaTp3czpwdWJsaWM6KjoqIl0sInJvbGVzIjpbInJlYWRlciIsIndyaXRlciJdLCJyZXNvdXJjZXMiOlsiKjokVVNFUl9JRCQ6KiJdfSx7ImlkIjoibWV0YWFwaS1yZWFsLXRpbWUtc3RyZWFtaW5nLWFwaSIsIm1ldGhvZHMiOlsibWV0YWFwaS1hcGk6d3M6cHVibGljOio6KiJdLCJyb2xlcyI6WyJyZWFkZXIiLCJ3cml0ZXIiXSwicmVzb3VyY2VzIjpbIio6JFVTRVJfSUQkOioiXX0seyJpZCI6Im1ldGFzdGF0cy1hcGkiLCJtZXRob2RzIjpbIm1ldGFzdGF0cy1hcGk6cmVzdDpwdWJsaWM6KjoqIl0sInJvbGVzIjpbInJlYWRlciJdLCJyZXNvdXJjZXMiOlsiKjokVVNFUl9JRCQ6KiJdfSx7ImlkIjoicmlzay1tYW5hZ2VtZW50LWFwaSIsIm1ldGhvZHMiOlsicmlzay1tYW5hZ2VtZW50LWFwaTpyZXN0OnB1YmxpYzoqOioiXSwicm9sZXMiOlsicmVhZGVyIiwid3JpdGVyIl0sInJlc291cmNlcyI6WyIqOiRVU0VSX0lEJDoqIl19LHsiaWQiOiJjb3B5ZmFjdG9yeS1hcGkiLCJtZXRob2RzIjpbImNvcHlmYWN0b3J5LWFwaTpyZXN0OnB1YmxpYzoqOioiXSwicm9sZXMiOlsicmVhZGVyIiwid3JpdGVyIl0sInJlc291cmNlcyI6WyIqOiRVU0VSX0lEJDoqIl19LHsiaWQiOiJtdC1tYW5hZ2VyLWFwaSIsIm1ldGhvZHMiOlsibXQtbWFuYWdlci1hcGk6cmVzdDpkZWFsaW5nOio6KiIsIm10LW1hbmFnZXItYXBpOnJlc3Q6cHVibGljOio6KiJdLCJyb2xlcyI6WyJyZWFkZXIiLCJ3cml0ZXIiXSwicmVzb3VyY2VzIjpbIio6JFVTRVJfSUQkOioiXX1dLCJ0b2tlbklkIjoiMjAyMTAyMTMiLCJpbXBlcnNvbmF0ZWQiOmZhbHNlLCJyZWFsVXNlcklkIjoiNzc0Mzc3MjE5MGYwOGRkMTY1MmI1YmUxMjZkNDEzNmYiLCJpYXQiOjE2OTM2NTQ1MDV9.g8ZfG_CjhrsajAxYHabGE2HuE5WGZ2XEpixhrHKIpzgdEj4mWtRQpNI7eh9xDSp1CJYmGZPUwoT6gihiMFy-Xrp3eKsitJzZOpJ1o-YE8ws9MDgkdLAgZWBPjGTop25hPgPMwQKMXKsa6NTdTzIal89UL18foMCEEvJp3uP39qwwirgu34y_u7lKGnPc9dXrhV7qc_7wP37NNGW8jBF3jyzz9aep5SklNfLUR4p8CUr2qg5fg5SfAcC8RdmQxA-iZ7yF-zC5w1_3XofnH_hVzv9onegK08spIz7D94H--1yk44pMz222H7cfl-hMeltMAVzJG2xiE3mRcYCjkqVdUmhdrPHl7KVCKsQselDUDnlZGlSWjNr-QST27tAmgQEX2yURvNueCEv7DG0Qd6ymmfXtKiZNqDTOtJRF7-tmzSrwtNDFT5FmdKYbhq3r4o4loQcSOIw1DVbA_Lip4XMERDk3HIcNbjzEzVpSvzughMo9gjMEY3xPNoE3qt5iJclW_rj4rU9GjbYaWXtfsP4Ck2xROT9mf3NErCjO7M8zH6sx4iYS4E9kA8vuf9STdiEe43n9wAvLUjqpH8CPNdMO54wNcdU-AxRM5OlmJBc2eIyRwIFgGRualEJUoZTTxdcVmPRA8bbAfcTMSzb0awr8O9jbiXUTmtbR3h2__MxhkYo",
        //            accountId = accountId,
        //        };

        //        var result = remoteServer.SendAsync<object>($"/users/current/accounts/{accountId}/account-information",
        //            HttpMethod.Post,
        //            _args
        //            ).GetAwaiter().GetResult();
        //Console.WriteLine(result.ToString());
        Console.ReadKey();
    }

    private static void Api_OnOrderProgress(MT5API sender, OrderProgress progress)
    {
        
        throw new NotImplementedException();
    }

    //    private void ConnectionStatus(MT5API sender, ConnectStatus e)
    //{
    //    Console.WriteLine(e);
    //}

    public record args
    {
        [JsonPropertyName("auth-token")]
        public string authToken { get; set; }
        public string accountId { get; set; }

        public bool refreshTerminalState { get; set; } = true;
    }

    private void Api_OnOrderHistory1(MT5API sender, OrderHistoryEventArgs args)
    {
        Console.WriteLine(args.Orders.Count + " " + args.Orders.First().OpenTime + " " + args.Orders.Last().OpenTime);
        if (args.Action == 14)
        {
            Console.WriteLine("need to request more data");
            sender.RequestOrderHistory(args.InternalDeals.Last().OpenTimeAsDateTime.Year, args.InternalDeals.Last().OpenTimeAsDateTime.Month,
                args.InternalDeals);
        }
    }

    private static void Api_OnOrderHistory(MT5API sender, OrderHistoryEventArgs args)
    {
        foreach (var item in args.Orders)
            Console.WriteLine(item.Ticket
                + " " + item.DealInternalIn?.PlacedType + " " + item.DealInternalIn?.Comment
                + " " + item.DealInternalOut?.PlacedType + " " + item.DealInternalOut?.Comment);
        Console.WriteLine(args.Action);
        if (args.Action == 14)
        {
            Console.WriteLine(args.Orders.Last().CloseTime);
            sender.RequestOrderHistory(args.Orders.Last().CloseTime, DateTime.Now);
        }
    }


}



//Demo Account Info
//Username: 5016640277
//Password: V!8pBqIt
//Investor: NxJsWe!8
//
//MetaQuotes-Demo

//Name     : Faraz Lo
//Type     : Forex Hedged USD
//Server   : MetaQuotes-Demo
//Login    : 5016640277
//Password : V!8pBqIt
//Investor : NxJsWe!8

