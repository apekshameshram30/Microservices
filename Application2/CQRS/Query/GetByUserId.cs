//using Application.DTO;
//using AutoMapper;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using System.Net.Http;


//namespace Application2.CQRS.Query
//{
//    public class GetByUserId : IRequest<List<ProductDTO>>
//    {
//        public int Id { get; set; }
//    }
//    public class GetByUserIdHandler : IRequestHandler<GetByUserId, List<ProductDTO>>
//    {
//        private readonly IHttpClientFactory _httpClientFactory;

//        public GetByUserIdHandler(IHttpClientFactory httpClientFactory)
//        {
//            _httpClientFactory = httpClientFactory;
//        }

//        public async Task<List<ProductDTO>> Handle(GetByUserId request, CancellationToken cancellationToken)
//        {
//            using (var httpClient = _httpClientFactory.CreateClient())
//            {
//                var response = await httpClient.GetAsync($"https://localhost:7247/api/Gateway/controller/GetProductByUserId?id={request.Id}");

//                if (response.IsSuccessStatusCode)
//                {
//                    var responseBody = await response.Content.ReadAsStringAsync();
//                    var products = JsonSerializer.Deserialize<List<ProductDTO>>(responseBody);
//                    if(products == null)
//                    {
//                        return null;
//                    }
//                    return products;
//                }
//                else
//                {
//                    return null;
//                }
//            }
//        }
//    }
//}
