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

        #region ProductImage

        public static ProductImage Map(ProductImageDTO from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new ProductImage
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

        public static ProductImageDTO Map(ProductImage from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new ProductImageDTO
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

        #region CartItem

        public static CartItem Map(CartItemDTO from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new CartItem
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

        public static CartItemDTO Map(CartItem from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new CartItemDTO
                {
                    ProductId = from.ProductId,
                    UserId = from.UserId,
                    Quantity = from.Quantity,
                    Product = Map(from.Product),
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

        #region OrderItem

        public static OrderItem Map(OrderItemDTO from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new OrderItem
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

        public static OrderItemDTO Map(OrderItem from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new OrderItemDTO
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

        #region CartItem - OrderItem & Lists

        public static OrderItem MapTypes(CartItem from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new OrderItem
                {
                    ProductId = from.ProductId,
                    Quantity = from.Quantity
                };

                return to;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static ICollection<OrderItem> MapTypes(ICollection<CartItem> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<OrderItem>();

                foreach (var item in from)
                {
                    to.Add(MapTypes(item));
                }

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

        #region ProductImage-List

        public static ICollection<ProductImage> Map(ICollection<ProductImageDTO> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<ProductImage>();

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

        public static ICollection<ProductImageDTO> Map(ICollection<ProductImage> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<ProductImageDTO>();

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

        #region CartItem-List

        public static ICollection<CartItem> Map(ICollection<CartItemDTO> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<CartItem>();

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

        public static ICollection<CartItemDTO> Map(ICollection<CartItem> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<CartItemDTO>();

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

        #region OrderItem-List

        public static ICollection<OrderItem> Map(ICollection<OrderItemDTO> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<OrderItem>();

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

        public static ICollection<OrderItemDTO> Map(ICollection<OrderItem> from)
        {
            try
            {
                if (from.Count == 0 && from == null)
                    return null;

                var to = new List<OrderItemDTO>();

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
