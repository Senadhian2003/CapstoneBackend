using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Models.DTO;
using CoffeeStoreManagementApp.Repositories.Interface;
using CoffeeStoreManagementApp.Services.Interfaces;

namespace CoffeeStoreManagementApp.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IRepository<int, Order> _orderRepository;
        private readonly IRepository<int, OrderDetail> _orderDetailRepository;
        private readonly IRepository<int, OrderDetailStatus> _orderDetailStatusRepository;
        public OrderServices(IRepository<int, Order> orderRepository, IRepository<int, OrderDetail> orderDetailRepository, IRepository<int, OrderDetailStatus> orderDetailStatusRepository) { 
        
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _orderDetailStatusRepository = orderDetailStatusRepository;

        }

        public async Task<List<Order>> ViewAllActiveOrders()
        {
            var orders = await _orderRepository.GetAll();

            var activeOrders = orders.Where(o => o.OrderStatus == "Pending");

            if (activeOrders.Count() == 0)
            {
                throw new EmptyListException("Order");
            }

            return activeOrders.ToList();

        }

        public async Task<List<Order>> ViewAllMyOrders(int userId)
        {

            var orders = await _orderRepository.GetAll();

            var myOrders = orders.Where(o => o.UserId == userId);

            if (myOrders.Count() == 0)
            {
                throw new EmptyListException("Order");
            }

            return myOrders.ToList();


        }

        public async Task<List<Order>> ViewAllOrders()
        {
            var orders = await _orderRepository.GetAll();

            if (orders.Count() == 0)
            {
                throw new EmptyListException("Order");
            }

            return orders.ToList();

        }

        public async Task<List<Order>> ViewMyActiveOrders(int userId)
        {
            var orders = await _orderRepository.GetAll();

            var myActiveOrders = orders.Where(o =>o.UserId == userId && o.OrderStatus == "Pending");

            if (myActiveOrders.Count() == 0)
            {
                throw new EmptyListException("Order");
            }

            return myActiveOrders.ToList();
        }

        public async Task<OrderDetailStatus> UpdateOrderDetail(UpdateOrderDetailDTO dto)
        {
            

            Order order = await _orderRepository.GetByKey(dto.OrderId);

            if (order == null)
            {
                throw new ElementNotFoundException("Order");
            }

            OrderDetailStatus orderDetailStatus = await _orderDetailStatusRepository.GetByKey(dto.StatusId);

            string currentStatus = orderDetailStatus.Status;

            if(currentStatus == "Collected" && dto.Status == "Collected")
            {
                throw new OrderAlreadyCollectedException();
            }

            if (dto.Status == "Collected")
            {
                orderDetailStatus.Status = dto.Status;
                order.ItemsServed += 1;
                if(order.ItemsServed == order.TotalItems)
                {
                    order.OrderStatus = "Collected";
                    await _orderRepository.Update(order);
                }

                await _orderDetailStatusRepository.Update(orderDetailStatus);


            }
            else
            {
                if(currentStatus== "Collected")
                {
                    order.ItemsServed -= 1;
                    order.OrderStatus = "Pending";
                    await _orderRepository.Update(order) ;
                }

                orderDetailStatus.Status = dto.Status;

                await _orderDetailStatusRepository.Update(orderDetailStatus) ;

            }

            return orderDetailStatus;


        }



    }
}
