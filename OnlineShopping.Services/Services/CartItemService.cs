﻿using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Mapper;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Repositories.UnitOfWork;
using OnlineShopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Services.Services
{
    public class CartItemService : ICartItemService
    {
        private IUnitOfWork _unitOfWork;

        public CartItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private bool IsCartItemExists(int uid, int pid)
        {
            var cartItem = GetCartItemByUserAndProductIDs(uid, pid);
            if (cartItem != null)
            {
                return true;
            }

            return false;
        }

        private CartItem GetCartItemByUserAndProductIDs(int uid, int pid)
        {
            return _unitOfWork.CartItemRepository.GetCartItemByUserAndProductIDs(uid, pid);
        }

        public async Task<bool> AddCartItem(CartItemDTO cartItemDTO)
        {
            if (cartItemDTO != null)
            {
                var cartItem = SMapper.Map(cartItemDTO);

                bool result = false;

                if (!IsCartItemExists(cartItemDTO.UserId, cartItemDTO.ProductId))
                {
                    result = await _unitOfWork.CartItemRepository.Add(cartItem);
                }
                else
                {
                    cartItem = GetCartItemByUserAndProductIDs(cartItemDTO.UserId, cartItemDTO.ProductId);
                    cartItem.Quantity = cartItemDTO.Quantity + cartItem.Quantity;

                    result = true;
                }

                await _unitOfWork.SaveChanges();

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

        public int GetNumberOfCartItemsByUserID(int uid)
        {
            var result = _unitOfWork.CartItemRepository.GetAllCartItemsByUserID(uid);

            var count = result.Sum(ci => ci.Quantity);
            return count;
        }

        public IEnumerable<CartItemDTO> GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10)
        {
            var result = _unitOfWork.CartItemRepository.GetCartItemsPagingByUserID(uid, pageIndex, pageSize);
            var cartItemsDTO = SMapper.Map(result.ToList());

            return cartItemsDTO;
        }

        public async Task<bool> Remove(CartItemDTO cartItemDTO)
        {
            var cartItem = _unitOfWork.CartItemRepository.GetCartItemByUserAndProductIDs(cartItemDTO.UserId, cartItemDTO.ProductId);

            if(cartItem != null)
            {
                var result = _unitOfWork.CartItemRepository.Remove(cartItem);
                await _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }
    }
}
