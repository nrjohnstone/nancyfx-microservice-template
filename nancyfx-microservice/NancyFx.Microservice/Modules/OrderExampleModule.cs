using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Nancy;
using Nancy.ModelBinding;

namespace NancyFx.Microservice.Modules
{
    public class NewOrderDto
    {
        public string Supplier { get; set; }
    }

    public class OrderDto
    {
        public string Supplier { get; set; }
    }

    public class OrderExampleModule : NancyModule
    {
        public OrderExampleModule()
        {
            Post["/orders"] = _ => CreateNewOrder();
            Get["/orders"] = _ => GetOrders();
        }

        private Response GetOrders()
        {
            string supplierFilter = this.Request.Query["supplier"];

            List<OrderDto> orders = new List<OrderDto>();
            orders.Add(new OrderDto() { Supplier = "Foo"});
            orders.Add(new OrderDto() { Supplier = "Bar" });

            return Response.AsJson(orders.Where(x => x.Supplier.Equals(supplierFilter)));
        }

        private object CreateNewOrder()
        {
            NewOrderDto newOrderDto = this.Bind();

            if (newOrderDto == null)
                throw new Exception();

            if (String.IsNullOrEmpty(newOrderDto.Supplier))
                throw new Exception();
            
            return HttpStatusCode.Created;
        }
    }
}