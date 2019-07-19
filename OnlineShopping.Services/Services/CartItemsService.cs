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
    public class CartItemsService : ICartItemsService
    {
        private IUnitOfWork _unitOfWork;

        public CartItemsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddCartItem(CartItemsDTO cartItemsDTO)
        {
            if (cartItemsDTO != null)
            {
                var cartItems = SMapper.Map(cartItemsDTO);
                var result = _unitOfWork.CartItemsRepository.Add(cartItems);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        public IEnumerable<CartItemsDTO> GetAllCartItemsByUserID(int uid)
        {
            var result = _unitOfWork.CartItemsRepository.GetAllCartItemsByUserID(uid);
            var cartItemsDtoList = SMapper.Map(result.ToList());

            return cartItemsDtoList;
        }

        public IEnumerable<CartItemsDTO> GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10)
        {
            var result = _unitOfWork.CartItemsRepository.GetCartItemsPagingByUserID(uid,pageIndex,pageSize);
            var cartItemsDtoList = SMapper.Map(result.ToList());

            return cartItemsDtoList;
        }

        public bool RemoveCartItems(CartItemsDTO cartItemsDTO)
        {
            var cartItems = _unitOfWork.CartItemsRepository.GetCartItemsByUserAndProductIDs(cartItemsDTO.UserId, cartItemsDTO.ProductId);

            if(cartItems != null)
            {
                var result = _unitOfWork.CartItemsRepository.Remove(cartItems);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        public bool EmptyCartItemsListByUserID(int uid)
        {
            var cartItemsListDTO = GetAllCartItemsByUserID(uid);
            var cartItemsList = SMapper.Map(cartItemsListDTO.ToList());

            if(cartItemsList != null)
            {
                var result = _unitOfWork.CartItemsRepository.EmptyCartItemsList(cartItemsList);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }
    }
}
