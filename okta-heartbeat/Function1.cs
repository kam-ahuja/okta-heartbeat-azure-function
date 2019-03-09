using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Okta.Core;
using Okta.Core.Clients;

namespace oktaheartbeat
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

            var tenant = "https://org.oktapreview.com";
            var username = "username";
            var password = "password";

            try
            {
                var oktaClient = new OktaClient("", new Uri(tenant));
                var authClient = oktaClient.GetAuthClient();
                var response = authClient.Authenticate(username, password);

                log.Info("Response: " + response.Status);
            }
            catch (Exception ex)
            {
                log.Error("Error occured: " + ex.Message);
            }
        }
    }
}
