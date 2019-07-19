using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Mapper;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Repositories.UnitOfWork;
using OnlineShopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Services.Services
{
    public class CartItemService : ICartItemService
    {
        private IUnitOfWork _unitOfWork;

        public CartItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddCartItem(CartItemDTO cartItemDTO)
        {
            if (cartItemDTO != null)
            {
                var cartItem = SMapper.Map(cartItemDTO);
                var result = _unitOfWork.CartItemRepository.Add(cartItem);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        public IEnumerable<CartItemDTO> GetAllCartItemsByUserID(int uid)
        {
            var result = _unitOfWork.CartItemRepository.GetAllCartItemsByUserID(uid);
            var cartItemsDTO = SMapper.Map(result.ToList());

            return cartItemsDTO;
        }

        public IEnumerable<CartItemDTO> GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10)
        {
            var result = _unitOfWork.CartItemRepository.GetCartItemsPagingByUserID(uid,pageIndex,pageSize);
            var cartItemsDTO = SMapper.Map(result.ToList());

            return cartItemsDTO;
        }

        public bool RemoveCartItem(CartItemDTO cartItemDTO)
        {
            var cartItems = _unitOfWork.CartItemRepository.GetCartItemByUserAndProductIDs(cartItemDTO.UserId, cartItemDTO.ProductId);

            if(cartItems != null)
            {
                var result = _unitOfWork.CartItemRepository.Remove(cartItems);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        public bool EmptyCartItemsByUserID(int uid)
        {
            var cartItemsDTO = GetAllCartItemsByUserID(uid);
            var cartItems = SMapper.Map(cartItemsDTO.ToList());

            if(cartItems != null)
            {
                var result = _unitOfWork.CartItemRepository.EmptyCartItems(cartItems);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }
    }
}
