using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopping.Mapper
{
    public static class SMapper
    {
        /// Mapping Objects

        #region User

        public static User Map(UserDTO from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new User
                {
                    Id = from.Id,
                    Username = from.Username,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static UserDTO Map(User from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new UserDTO
                {
                    Id = from.Id,
                    Username = from.Username,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region Order

        public static Order Map(OrderDTO from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Order
                {
                    Id = from.Id,
                    UserId = from.UserId,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static OrderDTO Map(Order from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new OrderDTO
                {
                    Id = from.Id,
                    UserId = from.UserId,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region Product

        public static Product Map(ProductDTO from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Product
                {
                    Id = from.Id,
                    Name = from.Name,
                    Description = from.Description,
                    Price = from.Price,
                    Quantity = from.Quantity,
                    ImagePosterUrl = from.ImagePosterUrl,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static ProductDTO Map(Product from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new ProductDTO
                {
                    Id = from.Id,
                    Name = from.Name,
                    Description = from.Description,
                    Price = from.Price,
                    Quantity = from.Quantity,
                    ImagePosterUrl = from.ImagePosterUrl,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region ProductImages

        public static ProductImages Map(ProductImagesDTO from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new ProductImages
                {
                    Id = from.Id,
                    ProductId = from.ProductId,
                    ImageUrl = from.ImageUrl,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static ProductImagesDTO Map(ProductImages from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new ProductImagesDTO
                {
                    Id = from.Id,
                    ProductId = from.ProductId,
                    ImageUrl = from.ImageUrl,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region CartItems

        public static CartItems Map(CartItemsDTO from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new CartItems
                {
                    ProductId = from.ProductId,
                    UserId = from.UserId,
                    Quantity = from.Quantity,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static CartItemsDTO Map(CartItems from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new CartItemsDTO
                {
                    ProductId = from.ProductId,
                    UserId = from.UserId,
                    Quantity = from.Quantity,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region OrderItems

        public static OrderItems Map(OrderItemsDTO from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new OrderItems
                {
                    ProductId = from.ProductId,
                    OrderId = from.OrderId,
                    Quantity = from.Quantity,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static OrderItemsDTO Map(OrderItems from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new OrderItemsDTO
                {
                    ProductId = from.ProductId,
                    OrderId = from.OrderId,
                    Quantity = from.Quantity,
                    CreatedDate = from.CreatedDate
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        /// Mapping Lists

        #region User-List

        public static ICollection<User> Map(ICollection<UserDTO> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<User>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static ICollection<UserDTO> Map(ICollection<User> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<UserDTO>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region Order-List

        public static ICollection<Order> Map(ICollection<OrderDTO> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<Order>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static ICollection<OrderDTO> Map(ICollection<Order> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<OrderDTO>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region Product-List

        public static ICollection<Product> Map(ICollection<ProductDTO> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<Product>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static ICollection<ProductDTO> Map(ICollection<Product> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<ProductDTO>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region ProductImages-List

        public static ICollection<ProductImages> Map(ICollection<ProductImagesDTO> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<ProductImages>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static ICollection<ProductImagesDTO> Map(ICollection<ProductImages> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<ProductImagesDTO>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region CartItems-List

        public static ICollection<CartItems> Map(ICollection<CartItemsDTO> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<CartItems>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static ICollection<CartItemsDTO> Map(ICollection<CartItems> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<CartItemsDTO>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region OrderItems-List

        public static ICollection<OrderItems> Map(ICollection<OrderItemsDTO> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<OrderItems>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static ICollection<OrderItemsDTO> Map(ICollection<OrderItems> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<OrderItemsDTO>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion
    }
}
