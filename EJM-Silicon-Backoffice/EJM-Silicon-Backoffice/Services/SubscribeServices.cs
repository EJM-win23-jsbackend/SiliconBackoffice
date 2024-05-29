using EJM_Silicon_Backoffice.Components.Account.Pages.Manage;
using EJMSiliconBackoffice.Models;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;

namespace EJMSiliconBackoffice.Services
{
    public class SubscribeServices
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ServiceBusHandler _serviceBusHandler;

        public SubscribeServices(HttpClient httpClient, IConfiguration configuration, ServiceBusHandler serviceBusHandler)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _serviceBusHandler = serviceBusHandler;
        }

        public async Task<List<SubscriberEntity>> GetAllSubscriberAsync()
        {
            try
            {
                var result = await _httpClient.GetAsync(_configuration.GetConnectionString("GetSubscribers"));

                if (result.IsSuccessStatusCode)
                {
                    var body = await result.Content.ReadAsStringAsync();
                    
                    if(!string.IsNullOrEmpty(body))
                    {
                        var subscriberList = JsonConvert.DeserializeObject<List<SubscriberEntity>>(body);

                        if(subscriberList != null && subscriberList.Count() > 0)
                        {

                            return subscriberList;
                        }
                    }
                }
                return null!;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DeleteSubscriber::" + ex.Message);
                return null!;
            }
        }

        public async Task<SubscriberEntity> GetASubscriberAsync(string id)
        {
            try
            {
                var jsonEntity = JsonConvert.SerializeObject(id);

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(_configuration.GetConnectionString("GetASubscriber")!),
                    Content = new StringContent(jsonEntity, Encoding.UTF8, "application/json")
                };

                var result = await _httpClient.SendAsync(request);

                if (result.IsSuccessStatusCode)
                {
                    var body = await result.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(body))
                    {
                        var subscriber = JsonConvert.DeserializeObject<SubscriberEntity>(body);

                        if (subscriber != null)
                        {
                            return subscriber;
                        }
                    }
                }
                return null!;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DeleteSubscriber::" + ex.Message);
                return null!;
            }
        }

        public async Task<IActionResult> DeleteSubscriberAsync(SubscriberEntity subscriber)
        {
            try
            {
                if(subscriber != null)
                {
                    var result = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("UnSubscribe"), subscriber);

                    if(result.IsSuccessStatusCode)
                    {
                        await _serviceBusHandler.NotifyUserDeletionAsync(subscriber.Email);

                        return new OkObjectResult(new { Status = 200, Message = "Email was successfully removed from subscription"});
                    }
                    if(result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return new UnauthorizedObjectResult(new { Status = 401, Message = "You're not authorized to do this action" });
                    }
                    if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return new NotFoundObjectResult(new { Status = 404, Message = "This email is not up for subscription" });
                    }
                }
                return new BadRequestObjectResult(new { Status = 400, Message = "Email input was empty..." });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DeleteSubscriber::" + ex.Message);
                return new BadRequestObjectResult(new { Status = 400, Message = "Email input was empty..." });
            }
        }

        public async Task<IActionResult> CreateUpdateSubscriberAsync(SubscriberEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    var result = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString("Subscribe"), entity);

                    if (result.IsSuccessStatusCode)
                    {
                        //var confirmationEmail = await _httpClient.PostAsJsonAsync(_configuration.GetConnectionString(""), confirmationEmail);

                        return new OkObjectResult(new { Status = 200, Message = "Email was successfully updated" });
                    }
                    if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return new UnauthorizedObjectResult(new { Status = 401, Message = "You're not authorized to do this action" });
                    }
                    if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return new NotFoundObjectResult(new { Status = 404, Message = "This email is not up for subscription" });
                    }
                }
                return new BadRequestObjectResult(new { Status = 400, Message = "Email input was empty..." });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DeleteSubscriber::" + ex.Message);
                return new BadRequestObjectResult(new { Status = 400, Message = "Email input was empty..." });
            }
        }
    }
}
